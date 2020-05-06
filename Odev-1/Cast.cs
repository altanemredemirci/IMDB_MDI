using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Odev_1
{
    public class Cast
    {
        public Cast()
        {
            Roles = new List<Role>();
            Images = new List<string>();
            Filmographies = new List<Movie>();
            KnownFor = new List<string>();
            FilmographiesRoles = new List<string>();
        }
        
        public int ID { get; set; }
        public string ImdbId { get; set; }
        public string Name { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string Description { get; set; }
        public string ProfileImage { get; set; }
        public string OtherPhotos { get; set; }
        public List<Role> Roles { get; set; }
        public List<string> Images { get; set; }
        public List<Movie> Filmographies { get; set; }
        public List<string> FilmographiesRoles { get; set; }
        public List<string> KnownFor { get; set; }

        string html = "";
        int start, end;
        public string HtmlToString(string url)
        {
            WebClient webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;
            html = webclient.DownloadString("https://www.imdb.com/" + url);
            return html;
        }
        public Cast Desc(Cast person)
        {
            string html = HtmlToString(person.ImdbId);
            if (html.Contains("class=\"inline\">\n"))
            {
                string[] desc = html.Split(new string[] { "class=\"inline\">\n" }, StringSplitOptions.None);

                string[] desc1 = desc[1].Split(new string[] { "</div>" }, StringSplitOptions.None);

                #region description
                string[] desc2 = desc1[0].Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);

                string descfull = "";
                for (int i = 0; i < desc2.Length; i++)
                {
                    if (desc2[i].Contains("See") == false)
                    {
                        if (desc2[i].Contains("<span") == false)
                        {
                            if (desc2[i].Contains('>'))
                            {
                                start = desc2[i].IndexOf('>');

                                descfull = descfull + desc2[i].Substring(start + 1);
                            }
                            else
                            {
                                descfull = descfull + desc2[i];
                            }
                        }
                        else
                        {
                            end = desc2[i].IndexOf(".");
                            descfull = descfull + desc2[i].Substring(0, end);
                        }

                    }
                    else
                    {
                        descfull = descfull + "...";
                    }
                }

                person.Description = descfull.TrimStart();
                #endregion

                #region Born
                string[] born = desc1[3].Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
                string bornfull = "";
                for (int i = 0; i < born.Length; i++)
                {
                    if (born[i].Contains("search"))
                    {
                        start = born[i].IndexOf('>') + 1;

                        bornfull = bornfull + born[i].Substring(start) + " ";
                    }
                }
                person.Born = bornfull;
                #endregion
            }


            return person;
        }
        public Cast Poster(Cast person)
        {
            string html = HtmlToString(person.ImdbId);
            if (html.Contains("<div class=\"image\">"))
            {
                start = html.IndexOf("<div class=\"image\">");
                string poster = html.Substring(start);
                start = poster.IndexOf("src=") + 5;
                if (poster.IndexOf(".jpg") > poster.IndexOf(".png")) { end = poster.IndexOf(".png"); }
                else { end = poster.IndexOf(".jpg"); }
                person.ProfileImage = poster.Substring(start, end - start + 5);

            }
            return person;

        }
        public List<string> Photos(Cast person)
        {
            string[] article = html.Split(new string[] { "<div class=\"article\"" }, StringSplitOptions.None);

            foreach (var item in article)
            {
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
                            person.Images.Add(photo);
                        }
                    }

                    start = item.IndexOf("<div class=\"see-more\">");
                    end = item.IndexOf("photo") + 7;
                    string seeAll = item.Substring(start, end - start);
                    string[] otherPhotos = seeAll.Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
                    for (int i = 0; i < otherPhotos.Length; i++)
                    {
                        if (otherPhotos[i].Contains("photos"))
                        {
                            start = otherPhotos[i].IndexOf("/name");
                            end = otherPhotos[i].IndexOf('>');
                            person.OtherPhotos = otherPhotos[i].Substring(start, end - start);
                        }
                    }
                }
            }
            return person.Images;
        }
        public List<string> GetKnownFor(Cast person)
        {
            string[] article = html.Split(new string[] { "<div class=\"article\"" }, StringSplitOptions.None);

            foreach (var item in article)
            {
                if (item.Contains("<div id=\"knownfor\">"))
                {
                    start = item.IndexOf("<div id=\"knownfor\">");                   
                    string knownfor = item.Substring(start);
                    start = knownfor.IndexOf("<div id=\"knownfor\">");
                    end = knownfor.IndexOf("<script>");
                    knownfor = knownfor.Substring(start, end - start);
                    string[] knownfortitle = knownfor.Split(new string[] { "<div class=\"knownfor-title" }, StringSplitOptions.None);
                 
                    for (int i = 0; i < knownfortitle.Length; i++)
                    {
                        if (knownfortitle[i].Contains("src"))
                        {

                            start = knownfortitle[i].IndexOf("src=\"") + 5;
                            if(knownfortitle[i].IndexOf(".jpg")> knownfortitle[i].IndexOf(".png")) { end = knownfortitle[i].IndexOf(".jpg"); }
                            else { end = knownfortitle[i].IndexOf(".png"); }
                            string photo = knownfortitle[i].Substring(start, end - start + 5);
                            person.KnownFor.Add(photo);
                        }
                    }
                }
            }
            return person.KnownFor;
        }
        public Cast Filmography(Cast person)
        {
            Movie filmography;
            string html = person.HtmlToString(person.ImdbId);
            string response = html.Substring(html.IndexOf("<div id=\"filmography\">"));
            response = response.Substring(0, response.IndexOf("<script>"));
            string[] filmohead = response.Split(new string[] { "<div class=\"filmo-category-section\"" }, StringSplitOptions.None);
            foreach (var item in filmohead)
            {

                if (item.Contains("<div class=\"filmo-row"))
                {
                    string[] job = item.Split(new string[] { "<div class=\"filmo-row\"", "</div>" }, StringSplitOptions.None);
                    foreach (var flmname in job)
                    {
                        filmography = new Movie();
                        if (flmname.Contains("id=\"actor"))
                        {
                            start = flmname.IndexOf("<a href=\"") + 9;
                            end = flmname.IndexOf("</a>");
                            string lnkname = flmname.Substring(start, end - start);
                            filmography.ImdbId = lnkname.Substring(0, lnkname.IndexOf('?'));
                            filmography.Name = lnkname.Substring(lnkname.IndexOf('>') + 1);
                            person.FilmographiesRoles.Add("Actor");
                            person.Filmographies.Add(filmography);
                        }
                        else if (flmname.Contains("id=\"director"))
                        {
                            start = flmname.IndexOf("<a href=\"") + 9;
                            end = flmname.IndexOf("</a>");
                            string lnkname = flmname.Substring(start, end - start);
                            filmography.ImdbId = lnkname.Substring(0, lnkname.IndexOf('?'));
                            filmography.Name = lnkname.Substring(lnkname.IndexOf('>') + 1);
                            person.FilmographiesRoles.Add("Director");
                            person.Filmographies.Add(filmography);
                        }
                        else if (flmname.Contains("id=\"writer"))
                        {
                            start = flmname.IndexOf("<a href=\"") + 9;
                            end = flmname.IndexOf("</a>");
                            string lnkname = flmname.Substring(start, end - start);
                            filmography.ImdbId = lnkname.Substring(0, lnkname.IndexOf('?'));
                            filmography.Name = lnkname.Substring(lnkname.IndexOf('>') + 1);
                            person.FilmographiesRoles.Add("Writer");
                            person.Filmographies.Add(filmography);
                        }
                        else if (flmname.Contains("id=\"actress"))
                        {
                            start = flmname.IndexOf("<a href=\"") + 9;
                            end = flmname.IndexOf("</a>");
                            string lnkname = flmname.Substring(start, end - start);
                            filmography.ImdbId = lnkname.Substring(0, lnkname.IndexOf('?'));
                            filmography.Name = lnkname.Substring(lnkname.IndexOf('>') + 1);
                            person.FilmographiesRoles.Add("Actress");
                            person.Filmographies.Add(filmography);
                        }
                        else if (flmname.Contains("id=\"producer"))
                        {
                            start = flmname.IndexOf("<a href=\"") + 9;
                            end = flmname.IndexOf("</a>");
                            string lnkname = flmname.Substring(start, end - start);
                            filmography.ImdbId = lnkname.Substring(0, lnkname.IndexOf('?'));
                            filmography.Name = lnkname.Substring(lnkname.IndexOf('>') + 1);
                            person.FilmographiesRoles.Add("Producer");
                            person.Filmographies.Add(filmography);
                        }
                        else if (flmname.Contains("id=\"production"))
                        {
                            start = flmname.IndexOf("<a href=\"") + 9;
                            end = flmname.IndexOf("</a>");
                            string lnkname = flmname.Substring(start, end - start);
                            filmography.ImdbId = lnkname.Substring(0, lnkname.IndexOf('?'));
                            filmography.Name = lnkname.Substring(lnkname.IndexOf('>') + 1);
                            person.FilmographiesRoles.Add("Production Designer");
                            person.Filmographies.Add(filmography);
                        }
                        else if (flmname.Contains("id=\"thanks"))
                        {
                            start = flmname.IndexOf("<a href=\"") + 9;
                            end = flmname.IndexOf("</a>");
                            string lnkname = flmname.Substring(start, end - start);
                            filmography.ImdbId = lnkname.Substring(0, lnkname.IndexOf('?'));
                            filmography.Name = lnkname.Substring(lnkname.IndexOf('>') + 1);
                            person.FilmographiesRoles.Add("Thanks");
                            person.Filmographies.Add(filmography);
                        }
                        else if (flmname.Contains("id=\"self"))
                        {
                            start = flmname.IndexOf("<a href=\"") + 9;
                            end = flmname.IndexOf("</a>");
                            string lnkname = flmname.Substring(start, end - start);
                            filmography.ImdbId = lnkname.Substring(0, lnkname.IndexOf('?'));
                            filmography.Name = lnkname.Substring(lnkname.IndexOf('>') + 1);
                            person.FilmographiesRoles.Add("Self");
                            person.Filmographies.Add(filmography);
                        }
                        else if (flmname.Contains("id=\"archive"))
                        {
                            start = flmname.IndexOf("<a href=\"") + 9;
                            end = flmname.IndexOf("</a>");
                            string lnkname = flmname.Substring(start, end - start);
                            filmography.ImdbId = lnkname.Substring(0, lnkname.IndexOf('?'));
                            filmography.Name = lnkname.Substring(lnkname.IndexOf('>') + 1);
                            person.FilmographiesRoles.Add("Archive Footage");
                            person.Filmographies.Add(filmography);
                        }
                    }
                }


            }

            return person;
        }
        public Cast FilmRole(Cast person)
        {
            string html = person.HtmlToString(person.ImdbId);
            string response = html.Substring(html.IndexOf("<div id=\"filmography\">"));
            response = response.Substring(0, response.IndexOf("<script>"));
            string[] filmohead = response.Split(new string[] { "<div class=\"filmo-category-section\"" }, StringSplitOptions.None);
            foreach (var item in filmohead)
            {

                if (item.Contains("<div class=\"filmo-row"))
                {
                    string[] job = item.Split(new string[] { "<div class=\"filmo-row\"", "</div>" }, StringSplitOptions.None);
                    foreach (var flmname in job)
                    {
                        if (flmname.Contains("id=\"actor"))
                        {
                            person.FilmographiesRoles.Add("Actor");
                        }
                        else if (flmname.Contains("id=\"director"))
                        {
                            person.FilmographiesRoles.Add("Director");
                        }
                        else if (flmname.Contains("id=\"writer"))
                        {
                            person.FilmographiesRoles.Add("Writer");
                        }
                        else if (flmname.Contains("id=\"actress"))
                        {
                            person.FilmographiesRoles.Add("Actress");
                        }
                        else if (flmname.Contains("id=\"producer"))
                        {
                            person.FilmographiesRoles.Add("Producer");
                        }
                        else if (flmname.Contains("id=\"production"))
                        {
                            person.FilmographiesRoles.Add("Production Designer");
                        }
                        else if (flmname.Contains("id=\"thanks"))
                        {
                            person.FilmographiesRoles.Add("Thanks");
                        }
                        else if (flmname.Contains("id=\"self"))
                        {
                            person.FilmographiesRoles.Add("Self");
                        }
                        else if (flmname.Contains("id=\"archive"))
                        {
                            person.FilmographiesRoles.Add("Archive Footage");
                        }
                    }
                }
            }

            return person;
        }
    }
}
