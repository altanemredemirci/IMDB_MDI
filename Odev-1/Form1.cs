using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev_1
{
    public partial class Form1 : Form
    {
        DataAccessLayer DAL;
        public Form1()
        {
            DAL = new DataAccessLayer();
            InitializeComponent();
        }
        public Form1(string url)
        {
            DAL = new DataAccessLayer();
            InitializeComponent();
            key = url;
            txt_moviename.Text = key.ToLower();

        }

        List<Movie> movielst = new List<Movie>();

        string html, key;
        int start, end;
        string[] response;
        public static string link; //SeeAll 
        public static Cast person; // Cast url(Director,Writer,Star)
        Movie film = new Movie();
        Movie movie = new Movie();
        private void txt_moviename_KeyPress(object sender, KeyPressEventArgs e)
        {
            lst_movies.Items.Clear();
            panelImage.Controls.Clear();

            key = txt_moviename.Text.ToLower();

            if (e.KeyChar == 13)
            {
                int start, end;
                string[] response;
                WebClient webclient = new WebClient();
                webclient.Encoding = Encoding.UTF8;
                html = webclient.DownloadString("https://www.imdb.com/find?q=" + key);

                string[] movies = html.Split(new string[] { "<div class=\"findSection\">\n" }, StringSplitOptions.None);
                for (int i = 0; i < movies.Length; i++)
                {
                    if (movies[i].Contains("a name=\"tt\""))
                    {
                        response = movies[i].Split(new string[] { "<td class=\"result_text\">" }, StringSplitOptions.None);//<td class="result_text">

                        for (int j = 1; j < response.Length; j++)
                        {
                            Movie movie = new Movie();
                            start = response[j].IndexOf('/');
                            end = response[j].IndexOf('?') - 1;
                            movie.ImdbId = response[j].Substring(start, end - start);
                            start = response[j].IndexOf('>') + 1;
                            end = response[j].IndexOf("</td>");
                            movie.Name = (response[j].Substring(start, end - start)).Replace("</a>", " ");
                            movie.Name = movie.Name.Replace("<br/>", " ").Replace("<i>", "").Replace("</i>", "");
                            lst_movies.Items.Add(movie);
                            movielst.Add(movie);
                        }
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lst_movies.SelectedValue = "ImdbId";
            lst_movies.Items.Clear();
            panelImage.Controls.Clear();

            key = txt_moviename.Text.ToLower();

            int start, end;
            string[] response;
            WebClient webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;
            html = webclient.DownloadString("https://www.imdb.com/find?q=" + key);

            string[] movies = html.Split(new string[] { "<div class=\"findSection\">\n" }, StringSplitOptions.None);
            for (int i = 0; i < movies.Length; i++)
            {
                if (movies[i].Contains("a name=\"tt\""))
                {
                    response = movies[i].Split(new string[] { "<td class=\"result_text\">" }, StringSplitOptions.None);//<td class="result_text">

                    for (int j = 1; j < response.Length; j++)
                    {
                        Movie movie = new Movie();
                        start = response[j].IndexOf('/');
                        end = response[j].IndexOf('?') - 1;
                        movie.ImdbId = response[j].Substring(start, end - start);
                        start = response[j].IndexOf('>') + 1;
                        end = response[j].IndexOf("</td>");
                        movie.Name = (response[j].Substring(start, end - start)).Replace("</a>", " ");
                        movie.Name = movie.Name.Replace("<br/>", " ").Replace("<i>", "").Replace("</i>", "");
                        lst_movies.Items.Add(movie);
                        movielst.Add(movie);
                    }
                }
            }

            foreach (Category item in DAL.CategoryList())
            {
                cmb_categories.Items.Add(item);
            }
        }
        private void lst_movies_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_addwatchlist.Visible = true;
            btn_watchlist.Visible = true;
            lbl_photos.Visible = true;
            lbl_moviename.Text = "";
            lbl_rating.Text = "";
            lst_star.Items.Clear();
            lst_director.Items.Clear();
            lst_writer.Items.Clear();
            lst_casts.Items.Clear();
            panelImage.Controls.Clear();
            pct_poster.Image = null;
            film.Casts.Clear();
            film = (Movie)lst_movies.SelectedItem;
            person = new Cast();
            movie = DAL.DBControl(film);
            if (movie == null)
            {
                WebClient webclient = new WebClient();
                webclient.Encoding = Encoding.UTF8;
                html = webclient.DownloadString("https://www.imdb.com" + film.ImdbId);
                if (html.Contains("<div class=\"combined-see-more see-more\">"))
                {
                    string[] article = html.Split(new string[] { "<div class=\"article\"" }, StringSplitOptions.None);
                    string[] subtext = article[0].Split(new string[] { "<div class=\"subtext\"" }, StringSplitOptions.None);
                    end = subtext[1].IndexOf("</div>");
                    string categorylink = subtext[1].Substring(0, end);
                    string[] category = categorylink.Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
                    foreach (var item in category)
                    {
                        Category cat;
                        if (item.Contains("\n>"))
                        {
                            cat = new Category();
                            start = item.IndexOf(">") + 1;
                            cat.Type = item.Substring(start);
                            DAL.CategorySave(cat.Type);
                            film.Categories.Add(cat);
                        }
                    }
                    foreach (var item in article)
                    {
                        #region Photos
                        if (item.Contains("<div class=\"mediastrip\">"))
                        {
                            start = item.IndexOf("<div class=\"mediastrip\">");
                            string picdiv = item.Substring(start);
                            start = picdiv.IndexOf("<a");
                            end = picdiv.IndexOf("</div>");

                            picdiv = picdiv.Substring(start, end - start);
                            string[] picture = picdiv.Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);

                            for (int i = 0; i < picture.Length; i++)
                            {
                                if (picture[i].Contains("src"))
                                {
                                    start = picture[i].IndexOf("loadlate=\"") + 10;
                                    end = picture[i].IndexOf(".jpg");
                                    string photo = picture[i].Substring(start, end - start + 5);
                                    film.Images.Add(photo);
                                }
                            }
                            ImagesList(film.Images);
                            start = item.IndexOf("<div class=\"combined-see-more see-more\">");
                            end = item.IndexOf("See all") + 7;
                            string seeAll = item.Substring(start, end - start);
                            string[] otherPhotos = seeAll.Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
                            for (int i = 0; i < otherPhotos.Length; i++)
                            {
                                if (otherPhotos[i].Contains("See all"))
                                {
                                    start = otherPhotos[i].IndexOf("/title");
                                    end = otherPhotos[i].IndexOf('>');
                                    person.OtherPhotos = otherPhotos[i].Substring(start, end - start);
                                }
                            }
                        }
                        #endregion

                        #region Casts
                        else if (item.Contains("<table class=\"cast_list\">"))
                        {
                            string[] a = item.Split(new string[] { "<tr>", "</tr>" }, StringSplitOptions.None);
                            a = item.Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
                            for (int i = 0; i < a.Length; i++)
                            {
                                if (a[i].Contains("/name"))
                                {
                                    start = a[i].IndexOf('>') + 1;
                                    end = a[i].LastIndexOf('\n');
                                    if (end > start)
                                    {
                                        lst_casts.Items.Add(a[i].Substring(start, end - start));
                                    }

                                }
                            }
                        }
                        #endregion


                    }
                }
                else
                {
                    #region TV Series Casts
                    string[] article = html.Split(new string[] { "<div class=\"article\"" }, StringSplitOptions.None);

                    foreach (var item in article)
                    {

                        if (item.Contains("<table class=\"cast_list\">"))
                        {
                            string[] a = item.Split(new string[] { "<tr>", "</tr>" }, StringSplitOptions.None);
                            a = item.Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
                            for (int i = 0; i < a.Length; i++)
                            {
                                if (a[i].Contains("/name"))
                                {
                                    start = a[i].IndexOf('>') + 1;
                                    end = a[i].LastIndexOf('\n');
                                    if (end > start)
                                    {
                                        lst_casts.Items.Add(a[i].Substring(start, end - start));
                                    }

                                }
                            }

                        }
                    }
                    #endregion
                }
                Poster();
                Ratings();
                Cast();
                if (film.Poster == "")
                {
                    pct_poster.Image = Image.FromFile(@"C:\Users\ALTAN EMRE\Desktop\Odev-1-Rol-MDI\No-image-found.jpg");
                }
                else
                {
                    pct_poster.Load(film.Poster);
                }

                lbl_moviename.Text = film.Name;
                lbl_rating.Text = film.Raiting + " Imdb Point";
                DAL.MovieSave(film);
            }
            else
            {
                //Cast person;
                lbl_moviename.Text = movie.Name;
                lbl_rating.Text = movie.Raiting + " Imdb Point";
                txt_description.Text = movie.Description;
                if (movie.Poster == "")
                {
                    pct_poster.Image = Image.FromFile(@"C:\Users\ALTAN EMRE\Desktop\Odev-1-Rol-MDI\No-image-found.jpg");
                }
                else
                {
                    pct_poster.Load(movie.Poster);
                }
                CastList();
                ImagesList(movie.Images);
                foreach (Cast item in movie.Casts)
                {
                    foreach (Role role in item.Roles)
                    {
                        if (role.RoleName == "Director")
                        {
                            lst_director.Items.Add(item.Name);
                        }
                        else if (role.RoleName == "Writer")
                        {
                            lst_writer.Items.Add(item.Name);
                        }
                        else if (role.RoleName == "Actor")
                        {
                            lst_star.Items.Add(item.Name);
                        }
                    }
                }
            }
        }
        private void lst_director_SelectedIndexChanged(object sender, EventArgs e)
        {

            string director = lst_director.SelectedItem.ToString();
            person = film.Casts.FirstOrDefault(x => x.Name == director);
            if (person == null)
            {
                person = movie.Casts.FirstOrDefault(x => x.Name == director);
            }
            this.Hide();
            frm_Director frm_director = new frm_Director(person);
            frm_director.Show();
        }
        private void lst_writer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string writer = lst_writer.SelectedItem.ToString();
            person = film.Casts.FirstOrDefault(x => x.Name == writer);
            if (person == null)
            {
                person = movie.Casts.FirstOrDefault(x => x.Name == writer);
            }
            this.Hide();
            frm_Writer frm_writer = new frm_Writer(person);
            frm_writer.Show();
        }
        private void lst_star_SelectedIndexChanged(object sender, EventArgs e)
        {
            string star = lst_star.SelectedItem.ToString();
            person = film.Casts.FirstOrDefault(x => x.Name == star);
            if (person == null)
            {
                person = movie.Casts.FirstOrDefault(x => x.Name == star);
            }
            this.Hide();
            frm_Star frm_star = new frm_Star(person);
            frm_star.Show();
        }
        private void lst_casts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string star = lst_casts.SelectedItem.ToString().Trim();
            person = film.Casts.FirstOrDefault(x => x.Name == star);
            if (person == null)
            {
                person = movie.Casts.FirstOrDefault(x => x.Name == star);
            }
            this.Hide();
            frm_Star frm_star = new frm_Star(person);
            frm_star.Show();
        }
        private void lbl_lnk_seeall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Photos frmphoto = new Photos(person);
            frmphoto.Show();
        }
        private void cmb_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = cmb_categories.SelectedItem.ToString();
            foreach (Movie item in DAL.MovieSelect(cat))
            {
                lst_movies.Items.Add(item);
            }

        }

        private void btn_addwatchlist_Click_1(object sender, EventArgs e)
        {

            if (movie == null)
            {
                Login login = new Login(film);
                login.Show();
                //WatchList watch = new WatchList(film);
                //watch.Show();
            }
            else
            {
                Login login = new Login(movie);
                login.Show();
                //WatchList watch = new WatchList(movie);
                //watch.Show();
            }
        }
        private void btn_watchlist_Click_1(object sender, EventArgs e)
        {
           
                Login login = new Login();
                login.Show();
                //WatchList watch = new WatchList(film);
                //watch.Show();
           
        }

        public void Ratings()
        {
            string[] rate = html.Split(new string[] { "<span itemprop=\"ratingValue\"" }, StringSplitOptions.None);
            if (rate.Length > 1)
            {
                start = rate[1].IndexOf('>') + 1;
                end = rate[1].IndexOf('<');
                film.Raiting = rate[1].Substring(start, end - start);
            }
        }
        public void Cast()
        {
            Cast person;
            string[] desc = html.Split(new string[] { "div class=\"summary_text\">\n" }, StringSplitOptions.None);
            end = desc[1].IndexOf('<');
            film.Description = desc[1].Substring(0, end - start).TrimStart();
            txt_description.Text = film.Description;
            response = html.Split(new string[] { "<div class=\"credit_summary_item\">\n" }, StringSplitOptions.None);
            for (int i = 1; i < response.Length; i++)
            {
                string[] director = response[i].Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
                if (director[0].Contains(">Director") == true)
                {
                    string result = String.Concat(director);
                    start = result.IndexOf("</div>");
                    result = result.Remove(start);
                    string[] director1 = result.Split(',');

                    for (int y = 0; y < director1.Length; y++)
                    {
                        person = new Cast();

                        if (director1[y].Contains("<span") == true)
                        {
                            start = director1[y].IndexOf('>') + 1;
                            end = director1[y].IndexOf("<span");
                            person.Name = director1[y].Substring(start, end - start).TrimEnd();


                            start = director1[y].IndexOf("/name/");
                            end = director1[y].IndexOf("?");
                            person.ImdbId = director1[y].Substring(start, end - start);

                        }
                        else
                        {
                            start = director1[y].LastIndexOf('>') + 1;
                            person.Name = director1[y].Substring(start).TrimEnd();

                            start = director1[y].IndexOf("/name/");
                            end = director1[y].IndexOf("?");
                            person.ImdbId = director1[y].Substring(start, end - start);
                        }

                        AddRole(person, "Director");
                    }
                    AddList("Director", lst_director);
                }
                else if (director[0].Contains(">Writer") == true)
                {
                    string result = String.Concat(director);
                    start = result.IndexOf("</div>");
                    result = result.Remove(start);
                    string[] director1 = result.Split(',');

                    for (int y = 0; y < director1.Length; y++)
                    {
                        person = new Cast();

                        if (director1[y].Contains("<span") == true)
                        {
                            start = director1[y].IndexOf('>') + 1;
                            end = director1[y].IndexOf("<span");
                            person.Name = director1[y].Substring(start, end - start);


                            start = director1[y].IndexOf("/name/");
                            end = director1[y].IndexOf("?");
                            person.ImdbId = director1[y].Substring(start, end - start);
                        }
                        else
                        {
                            start = director1[y].LastIndexOf('>') + 1;
                            person.Name = director1[y].Substring(start).TrimEnd();

                            start = director1[y].IndexOf("/name/");
                            end = director1[y].IndexOf("?");
                            person.ImdbId = director1[y].Substring(start, end - start);
                        }
                        AddRole(person, "Writer");
                    }
                    AddList("Writer", lst_writer);
                }
                else if (director[0].Contains(">Star") == true)
                {
                    string result = String.Concat(director);
                    start = result.IndexOf("</div>");
                    result = result.Remove(start);
                    string[] director1 = result.Split(',');

                    for (int y = 0; y < director1.Length; y++)
                    {
                        person = new Cast();

                        if (director1[y].Contains("<span") == true)
                        {
                            start = director1[y].IndexOf('>') + 1;
                            end = director1[y].IndexOf("<span");
                            person.Name = director1[y].Substring(start, end - start);

                            start = director1[y].IndexOf("/name/");
                            end = director1[y].IndexOf("?");
                            person.ImdbId = director1[y].Substring(start, end - start);

                        }
                        else
                        {
                            start = director1[y].LastIndexOf('>') + 1;
                            person.Name = director1[y].Substring(start);

                            start = director1[y].IndexOf("/name/");
                            end = director1[y].IndexOf("?");
                            person.ImdbId = director1[y].Substring(start, end - start);

                        }

                        AddRole(person, "Actor");
                    }

                    AddList("Actor", lst_star);

                }
                else if (director[0].Contains(">Creator") == true)
                {
                    string result = String.Concat(director);
                    start = result.IndexOf("</div>");
                    result = result.Remove(start);
                    string[] director1 = result.Split(',');

                    for (int y = 0; y < director1.Length; y++)
                    {
                        person = new Cast();

                        if (director1[y].Contains("<span") == true)
                        {
                            start = director1[y].IndexOf('>') + 1;
                            end = director1[y].IndexOf("<span");
                            person.Name = director1[y].Substring(start);


                            start = director1[y].IndexOf("/name/");
                            person.ImdbId = director1[y].Substring(start);
                            Role role = new Role();
                            role.RoleName = "Director";
                            person.Roles.Add(role);

                        }
                        else
                        {
                            start = director1[y].LastIndexOf('>') + 1;
                            person.Name = director1[y].Substring(start).Trim();

                            start = director1[y].IndexOf("/name/");
                            end = director1[y].IndexOf("?");
                            person.ImdbId = director1[y].Substring(start, end - start);
                            Role role = new Role();
                            role.RoleName = "Director";
                            person.Roles.Add(role);
                        }

                        film.Casts.Add(person);
                    }
                    AddList("Director", lst_director);
                }
            }
        }
        public void AddRole(Cast person, string rol)
        {
            Role role;
            Cast p = film.Casts.FirstOrDefault(x => x.Name == person.Name);
            if (p != null)
            {
                role = new Role();
                role.RoleName = rol;
                p.Roles.Add(role);
                film.Casts.Remove(p);
                film.Casts.Add(p);
            }
            else
            {
                role = new Role();
                role.RoleName = rol;
                person.Roles.Add(role);
                film.Casts.Add(person);
            }
        }
        public void AddList(string rol, ListBox lst)
        {
            foreach (var item in film.Casts)
            {
                foreach (Role role in item.Roles)
                {
                    if (role.RoleName == rol)
                    {
                        lst.Items.Add(item.Name);
                    }
                }

            }
        }
        public void ImagesList(List<string> list)
        {
            int x = 0, y = 20, maxHeight = -1;
            foreach (var item in list)
            {
                PictureBox pic = new PictureBox();
                pic.Load(item);
                pic.Location = new Point(x, y);
                pic.Size = new System.Drawing.Size(140, 140);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                x += pic.Width + 10;
                maxHeight = Math.Max(pic.Height, maxHeight);
                if (x > this.ClientSize.Width - 100)
                {
                    x = 20;
                    y += maxHeight + 10;
                }
                this.panelImage.Controls.Add(pic);
            }
        }


        public void Poster()
        {
            if (html.Contains("<div class=\"poster\">"))
            {
                start = html.IndexOf("<div class=\"poster\">");
                string poster = html.Substring(start);
                start = poster.IndexOf("src=") + 5;
                end = poster.IndexOf(".jpg");
                poster = poster.Substring(start, end - start + 5);
                film.Poster = poster;
            }

        }
        public void CastList()
        {
            WebClient webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;
            html = webclient.DownloadString("https://www.imdb.com" + film.ImdbId);
            if (html.Contains("<div class=\"combined-see-more see-more\">"))
            {
                string[] article = html.Split(new string[] { "<div class=\"article\"" }, StringSplitOptions.None);
                foreach (var item in article)
                {
                    #region Casts
                    if (item.Contains("<table class=\"cast_list\">"))
                    {
                        string[] a = item.Split(new string[] { "<tr>", "</tr>" }, StringSplitOptions.None);
                        a = item.Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (a[i].Contains("/name"))
                            {
                                start = a[i].IndexOf('>') + 1;
                                end = a[i].LastIndexOf('\n');
                                if (end > start)
                                {
                                    lst_casts.Items.Add(a[i].Substring(start, end - start));
                                }

                            }
                        }
                    }
                    #endregion
                }
            }
            else
            {
                #region TV Series Casts
                string[] article = html.Split(new string[] { "<div class=\"article\"" }, StringSplitOptions.None);

                foreach (var item in article)
                {

                    if (item.Contains("<table class=\"cast_list\">"))
                    {
                        string[] a = item.Split(new string[] { "<tr>", "</tr>" }, StringSplitOptions.None);
                        a = item.Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (a[i].Contains("/name"))
                            {
                                start = a[i].IndexOf('>') + 1;
                                end = a[i].LastIndexOf('\n');
                                if (end > start)
                                {
                                    lst_casts.Items.Add(a[i].Substring(start, end - start));
                                }
                            }
                        }
                    }
                }
                #endregion
            }

        }
    }
}
