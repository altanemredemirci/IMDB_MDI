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
    public partial class MovieDetails : Form
    {
        DataAccessLayer DAL;
        public MovieDetails(string url)
        {
            DAL = new DataAccessLayer();
            key = url.ToLower();
            InitializeComponent();
            
        }
        string html, key;
        int start, end;
        string[] response;
        public static string link; //SeeAll 
        public static Cast person; // Cast url(Director,Writer,Star)
        Movie movie = new Movie();
        Movie film = new Movie();
        private void MovieDetails_Load(object sender, EventArgs e)
        {
            film.ImdbId = key;
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
                    start = subtext[0].LastIndexOf("<h1 class=\"\">")+12;
                    end = subtext[0].LastIndexOf("&")-1;
                    string name = subtext[0].Substring(start+1,end-start);
                    film.Name = name;
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
                Poster(film);
                Ratings();
                Cast();
                if (film.Poster != null)
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
                    Poster(movie);
                }
                else
                {
                    pct_poster.Load(movie.Poster);
                }                
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

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void lbl_lnk_seeall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Photos frmphoto = new Photos(person);
            frmphoto.Show();
        }

        private void lst_director_SelectedIndexChanged(object sender, EventArgs e)
        {
            string director = lst_director.SelectedItem.ToString();
            person = movie.Casts.FirstOrDefault(x => x.Name == director);
            this.Hide();
            frm_Director frm_director = new frm_Director(person);
            frm_director.Show();
        }
        private void lst_writer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string writer = lst_writer.SelectedItem.ToString();
            person = movie.Casts.FirstOrDefault(x => x.Name == writer);
            this.Hide();
            frm_Writer frm_writer = new frm_Writer(person);
            frm_writer.Show();
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
            start = 0;
            end = 0;
            Cast person;
            string[] desc = html.Split(new string[] { "div class=\"summary_text\">\n" }, StringSplitOptions.None);
            end = desc[1].IndexOf("</div>");
            film.Description = desc[1].Substring(0, end - start).Trim();
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
                            person.Name = director1[y].Substring(start);

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
            int x = 20, y = 20, maxHeight = -1;
            foreach (var item in list)
            {
                PictureBox pic = new PictureBox();
                pic.Load(item);
                pic.Location = new Point(x, y);
                pic.SizeMode = PictureBoxSizeMode.CenterImage;
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
        public void Poster(Movie mov)
        {
            html=person.HtmlToString(key);
            if (html.Contains("<div class=\"poster\">"))
            {
                start = html.IndexOf("<div class=\"poster\">");
                string poster = html.Substring(start);
                start = poster.IndexOf("src=") + 5;
                end = poster.IndexOf(".jpg");
                poster = poster.Substring(start, end - start + 5);
                pct_poster.Load(poster);
                mov.Poster=poster;
            }

        }
        
    }
}
