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
    public partial class frm_Writer : Form
    {
        Cast person;
        DataAccessLayer DAL;
        public frm_Writer(Cast cast)
        {
            person = cast;
            DAL = new DataAccessLayer();
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void frm_Writer_Load(object sender, EventArgs e)
        {
            person = DAL.CastControl(person);
            if (person.Born == "" || person.Description == "")
            {
                person = person.Desc(person);
                txt_born.Text = person.Born;
                txt_desc.Text = person.Description;
                lbl_name.Text = person.Name.Contains('(') ? person.Name.Substring(0, person.Name.IndexOf('(')) : person.Name;
                person = person.Poster(person);
                pct_poster.Load(person.ProfileImage);
                ImagesList(person.Photos(person));
                KnownList(person.GetKnownFor(person));
                person = person.Filmography(person);
                
                DAL.CastUpdate(person);
            }
            else
            {
                txt_born.Text = person.Born;
                txt_desc.Text = person.Description;
                lbl_name.Text = person.Name.Contains('(') ? person.Name.Substring(0, person.Name.IndexOf('(')) : person.Name;
                pct_poster.Load(person.ProfileImage);
                ImagesList(person.Images);
                KnownList(person.KnownFor); person.Filmographies.Clear();
                person = person.Filmography(person);
            }
            List<string> lstrole = new List<string>();
            for (int i = 0; i < person.Filmographies.Count; i++)
            {
                if (lstrole.Contains(person.FilmographiesRoles[i]) == false)
                {
                    lstrole.Add(person.FilmographiesRoles[i]);
                }
            }

            foreach (string item in lstrole)
            {
                TreeNode roles = new TreeNode(item);
                treeview_roles.Nodes.Add(roles);
            }
        }
        private void treeview_roles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lst_filmography.Items.Clear();
            string rolename = e.Node.Text.ToString();
            List<string> lstfilmography = DAL.Filmography(person.ID, rolename);
            foreach (string item in lstfilmography)
            {
                lst_filmography.Items.Add(item);
            }
            lst_filmography.Visible = true;
        }
        public void KnownList(List<string> list)
        {
            int x = 20, y = 20, maxHeight = -1;
            foreach (var item in list)
            {
                PictureBox pic = new PictureBox();
                pic.Size = new System.Drawing.Size(140, 160);
                pic.Load(item);
                pic.Location = new Point(x, y);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                x += pic.Width + 10;
                maxHeight = Math.Max(pic.Height, maxHeight);
                if (x > this.ClientSize.Width - 100)
                {
                    x = 20;
                    y += maxHeight + 10;
                }
                this.panelKnownFor.Controls.Add(pic);
            }


        }
        public void ImagesList(List<string> list)
        {
            int x = 10, y = 10, maxHeight = -1;
            foreach (var item in list)
            {
                PictureBox pic = new PictureBox();
                pic.Load(item);
                pic.Location = new Point(x, y);
                pic.Size = new System.Drawing.Size(100, 170);
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

        private void lbl_lnk_seeall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Photos frmphoto = new Photos(person);
            frmphoto.Show();
        }
        private void lst_filmography_SelectedIndexChanged(object sender, EventArgs e)
        {
            string moviename = lst_filmography.SelectedItem.ToString();
            foreach (var item in person.Filmographies)
            {
                if (item.Name == moviename)
                {
                    string url = item.ImdbId;
                    this.Hide();
                    MovieDetails frm_movies = new MovieDetails(url);
                    frm_movies.Show();
                    break;
                }
            }
        }
    }
}
