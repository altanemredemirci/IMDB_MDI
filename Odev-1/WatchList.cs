using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev_1
{
    public partial class WatchList : Form
    {
        DataAccessLayer DAL;
        Movie movie;
        User user;
        int end;
        Movie watch;
        public WatchList(User member, Movie film )
        {
            DAL = new DataAccessLayer();
            movie = film;
            user = member;
            InitializeComponent();
        }

        public WatchList(User member)
        {
            DAL = new DataAccessLayer();
            user = member;
            InitializeComponent();
        }
        private void WatchList_Load(object sender, EventArgs e)
        {
            if (movie != null)
            {
                DAL.WatchListSave(user, movie.ID);
            }
                       
            List<Movie> lstMovie = DAL.WatchListControl(user);
            foreach (Movie film in lstMovie)
            {
                cmb_watchlist.Items.Add(film);
            }
        }
       
        private void txt_moviename_Click(object sender, EventArgs e)
        {

        }

        private void cmb_watchlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            lst_director.Items.Clear();
            lst_star.Items.Clear();
            string name = cmb_watchlist.SelectedItem.ToString();
            watch = DAL.WatchListSelect(name);

            pct_poster.Load(watch.Poster);
            txt_description.Text = watch.Description;
            btn_raiting.Text = " " + watch.Raiting;
            lbl_moviename.Text = watch.Name;
            txt_description.BorderStyle = BorderStyle.None;
            lst_star.BorderStyle = BorderStyle.None;
            lst_director.BorderStyle = BorderStyle.None;
            List<string> lstdirectors = DAL.WatchListRole(watch.ID, 1);
            List<string> lststars = DAL.WatchListRole(watch.ID, 3);

            foreach (string item in lstdirectors)
            {
                end = item.IndexOf("(");
                if (end > 0)
                {
                    lst_director.Items.Add(item.Substring(0, end));
                }
                else
                {
                    lst_director.Items.Add(item);
                }
            }

            foreach (string item in lststars)
            {
                end = item.IndexOf("(");
                if (end > 0)
                {
                    lst_star.Items.Add(item.Substring(0, end));
                }
                else
                {
                    lst_star.Items.Add(item);
                }
            }
            mpanel_movie.Visible = true;
        }

        private void mbtn_watchdelete_Click(object sender, EventArgs e)
        {
            cmb_watchlist.Text = "";
            cmb_watchlist.Items.Clear();
            DAL.WatchListDelete(user, watch.ID);
            List<Movie> lstMovie = DAL.WatchListControl(user);
            foreach (Movie film in lstMovie)
            {
                cmb_watchlist.Items.Add(film);
            }
            mpanel_movie.Visible = false;
        }
    }
}
