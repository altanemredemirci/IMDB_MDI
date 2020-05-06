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
    public partial class Photos : Form
    {
        string url;
        public Photos(Cast person)
        {
            InitializeComponent();
            url = person.OtherPhotos;
        }

        string html;
        int start, end;
        List<string> Pictures = new List<string>();
        
        private void Photos_Load(object sender, EventArgs e)
        {
            WebClient webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;
            html = webclient.DownloadString("https://www.imdb.com" + url);
            string[] media = html.Split(new string[] { "id=\"media_index_thumbnail_grid\"" }, StringSplitOptions.None);
            string[] photos = media[1].Split(new string[] { "<a href=", "</a>" }, StringSplitOptions.None);
            for (int i = 0; i < 60; i++)
            {
                if (photos[i].Contains("src"))
                {
                    start = photos[i].IndexOf("src=\"")+5;
                    end = photos[i].IndexOf(".jpg");
                    string photo = photos[i].Substring(start, end - start + 5);
                    Pictures.Add(photo);
                }
            }
            ImagesList(Pictures);

       
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
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
                x += pic.Width + 30;
                maxHeight = Math.Max(pic.Height, maxHeight);
                if (x > this.ClientSize.Width - 100)
                {
                    x = 20;
                    y += maxHeight + 10;
                }
                this.panelImage.Controls.Add(pic);
            }

        }
    }
}
