namespace Odev_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox_movie = new System.Windows.Forms.GroupBox();
            this.btn_watchlist = new System.Windows.Forms.Button();
            this.imglst_icon = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_categories = new System.Windows.Forms.ComboBox();
            this.lbl_category = new System.Windows.Forms.Label();
            this.btn_addwatchlist = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pct_poster = new System.Windows.Forms.PictureBox();
            this.lst_casts = new System.Windows.Forms.ListBox();
            this.lbl_photos = new System.Windows.Forms.Label();
            this.panelImage = new System.Windows.Forms.Panel();
            this.lst_star = new System.Windows.Forms.ListBox();
            this.lst_writer = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lst_director = new System.Windows.Forms.ListBox();
            this.lbl_rating = new System.Windows.Forms.Label();
            this.lbl_moviename = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.lst_movies = new System.Windows.Forms.ListBox();
            this.txt_moviename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_movie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_poster)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_movie
            // 
            this.groupBox_movie.AutoSize = true;
            this.groupBox_movie.Controls.Add(this.btn_watchlist);
            this.groupBox_movie.Controls.Add(this.label8);
            this.groupBox_movie.Controls.Add(this.cmb_categories);
            this.groupBox_movie.Controls.Add(this.lbl_category);
            this.groupBox_movie.Controls.Add(this.btn_addwatchlist);
            this.groupBox_movie.Controls.Add(this.label7);
            this.groupBox_movie.Controls.Add(this.pct_poster);
            this.groupBox_movie.Controls.Add(this.lst_casts);
            this.groupBox_movie.Controls.Add(this.lbl_photos);
            this.groupBox_movie.Controls.Add(this.panelImage);
            this.groupBox_movie.Controls.Add(this.lst_star);
            this.groupBox_movie.Controls.Add(this.lst_writer);
            this.groupBox_movie.Controls.Add(this.label5);
            this.groupBox_movie.Controls.Add(this.label4);
            this.groupBox_movie.Controls.Add(this.label3);
            this.groupBox_movie.Controls.Add(this.label2);
            this.groupBox_movie.Controls.Add(this.lst_director);
            this.groupBox_movie.Controls.Add(this.lbl_rating);
            this.groupBox_movie.Controls.Add(this.lbl_moviename);
            this.groupBox_movie.Controls.Add(this.txt_description);
            this.groupBox_movie.Controls.Add(this.lst_movies);
            this.groupBox_movie.Controls.Add(this.txt_moviename);
            this.groupBox_movie.Controls.Add(this.label1);
            this.groupBox_movie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_movie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox_movie.Location = new System.Drawing.Point(0, 0);
            this.groupBox_movie.Name = "groupBox_movie";
            this.groupBox_movie.Size = new System.Drawing.Size(1924, 948);
            this.groupBox_movie.TabIndex = 0;
            this.groupBox_movie.TabStop = false;
            this.groupBox_movie.Text = "IMDB";
            // 
            // btn_watchlist
            // 
            this.btn_watchlist.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_watchlist.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_watchlist.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_watchlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_watchlist.ImageKey = "Movies-Oscar-icon.png";
            this.btn_watchlist.ImageList = this.imglst_icon;
            this.btn_watchlist.Location = new System.Drawing.Point(1641, 461);
            this.btn_watchlist.Name = "btn_watchlist";
            this.btn_watchlist.Size = new System.Drawing.Size(253, 45);
            this.btn_watchlist.TabIndex = 29;
            this.btn_watchlist.Text = "WatchList";
            this.btn_watchlist.UseVisualStyleBackColor = false;
            this.btn_watchlist.Visible = false;
            this.btn_watchlist.Click += new System.EventHandler(this.btn_watchlist_Click_1);
            // 
            // imglst_icon
            // 
            this.imglst_icon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglst_icon.ImageStream")));
            this.imglst_icon.TransparentColor = System.Drawing.Color.Transparent;
            this.imglst_icon.Images.SetKeyName(0, "plus.png");
            this.imglst_icon.Images.SetKeyName(1, "Movies-Oscar-icon.png");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(23, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "Movies";
            // 
            // cmb_categories
            // 
            this.cmb_categories.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_categories.FormattingEnabled = true;
            this.cmb_categories.Location = new System.Drawing.Point(26, 119);
            this.cmb_categories.Name = "cmb_categories";
            this.cmb_categories.Size = new System.Drawing.Size(278, 26);
            this.cmb_categories.TabIndex = 27;
            this.cmb_categories.SelectedIndexChanged += new System.EventHandler(this.cmb_categories_SelectedIndexChanged);
            // 
            // lbl_category
            // 
            this.lbl_category.AutoSize = true;
            this.lbl_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_category.Location = new System.Drawing.Point(23, 97);
            this.lbl_category.Name = "lbl_category";
            this.lbl_category.Size = new System.Drawing.Size(130, 16);
            this.lbl_category.TabIndex = 26;
            this.lbl_category.Text = "Movie Categories";
            // 
            // btn_addwatchlist
            // 
            this.btn_addwatchlist.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_addwatchlist.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_addwatchlist.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_addwatchlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addwatchlist.ImageKey = "plus.png";
            this.btn_addwatchlist.ImageList = this.imglst_icon;
            this.btn_addwatchlist.Location = new System.Drawing.Point(1641, 528);
            this.btn_addwatchlist.Name = "btn_addwatchlist";
            this.btn_addwatchlist.Size = new System.Drawing.Size(253, 45);
            this.btn_addwatchlist.TabIndex = 25;
            this.btn_addwatchlist.Text = "Add to WatchList";
            this.btn_addwatchlist.UseVisualStyleBackColor = false;
            this.btn_addwatchlist.Visible = false;
            this.btn_addwatchlist.Click += new System.EventHandler(this.btn_addwatchlist_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(368, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Casts";
            // 
            // pct_poster
            // 
            this.pct_poster.Location = new System.Drawing.Point(1641, 87);
            this.pct_poster.Name = "pct_poster";
            this.pct_poster.Size = new System.Drawing.Size(246, 297);
            this.pct_poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_poster.TabIndex = 22;
            this.pct_poster.TabStop = false;
            // 
            // lst_casts
            // 
            this.lst_casts.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lst_casts.FormattingEnabled = true;
            this.lst_casts.ItemHeight = 15;
            this.lst_casts.Location = new System.Drawing.Point(371, 387);
            this.lst_casts.Name = "lst_casts";
            this.lst_casts.Size = new System.Drawing.Size(226, 199);
            this.lst_casts.TabIndex = 21;
            this.lst_casts.SelectedIndexChanged += new System.EventHandler(this.lst_casts_SelectedIndexChanged);
            // 
            // lbl_photos
            // 
            this.lbl_photos.AutoSize = true;
            this.lbl_photos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_photos.Location = new System.Drawing.Point(653, 356);
            this.lbl_photos.Name = "lbl_photos";
            this.lbl_photos.Size = new System.Drawing.Size(62, 18);
            this.lbl_photos.TabIndex = 19;
            this.lbl_photos.Text = "Photos";
            this.lbl_photos.Visible = false;
            // 
            // panelImage
            // 
            this.panelImage.Location = new System.Drawing.Point(656, 387);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(903, 186);
            this.panelImage.TabIndex = 18;
            // 
            // lst_star
            // 
            this.lst_star.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lst_star.FormattingEnabled = true;
            this.lst_star.ItemHeight = 18;
            this.lst_star.Location = new System.Drawing.Point(1222, 87);
            this.lst_star.Name = "lst_star";
            this.lst_star.Size = new System.Drawing.Size(337, 112);
            this.lst_star.TabIndex = 17;
            this.lst_star.SelectedIndexChanged += new System.EventHandler(this.lst_star_SelectedIndexChanged);
            // 
            // lst_writer
            // 
            this.lst_writer.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lst_writer.FormattingEnabled = true;
            this.lst_writer.ItemHeight = 18;
            this.lst_writer.Location = new System.Drawing.Point(798, 87);
            this.lst_writer.Name = "lst_writer";
            this.lst_writer.Size = new System.Drawing.Size(337, 112);
            this.lst_writer.TabIndex = 16;
            this.lst_writer.SelectedIndexChanged += new System.EventHandler(this.lst_writer_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(368, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(1219, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Stars";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(795, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Writers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(368, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Directors";
            // 
            // lst_director
            // 
            this.lst_director.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lst_director.FormattingEnabled = true;
            this.lst_director.ItemHeight = 18;
            this.lst_director.Location = new System.Drawing.Point(371, 87);
            this.lst_director.Name = "lst_director";
            this.lst_director.Size = new System.Drawing.Size(337, 112);
            this.lst_director.TabIndex = 10;
            this.lst_director.SelectedIndexChanged += new System.EventHandler(this.lst_director_SelectedIndexChanged);
            // 
            // lbl_rating
            // 
            this.lbl_rating.AutoSize = true;
            this.lbl_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_rating.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_rating.Location = new System.Drawing.Point(794, 27);
            this.lbl_rating.Name = "lbl_rating";
            this.lbl_rating.Size = new System.Drawing.Size(0, 24);
            this.lbl_rating.TabIndex = 9;
            // 
            // lbl_moviename
            // 
            this.lbl_moviename.AutoSize = true;
            this.lbl_moviename.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_moviename.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_moviename.Location = new System.Drawing.Point(376, 27);
            this.lbl_moviename.Name = "lbl_moviename";
            this.lbl_moviename.Size = new System.Drawing.Size(0, 24);
            this.lbl_moviename.TabIndex = 8;
            // 
            // txt_description
            // 
            this.txt_description.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_description.Location = new System.Drawing.Point(371, 256);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(1188, 82);
            this.txt_description.TabIndex = 4;
            // 
            // lst_movies
            // 
            this.lst_movies.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lst_movies.FormattingEnabled = true;
            this.lst_movies.ItemHeight = 17;
            this.lst_movies.Location = new System.Drawing.Point(26, 246);
            this.lst_movies.Name = "lst_movies";
            this.lst_movies.Size = new System.Drawing.Size(278, 344);
            this.lst_movies.TabIndex = 2;
            this.lst_movies.SelectedIndexChanged += new System.EventHandler(this.lst_movies_SelectedIndexChanged);
            // 
            // txt_moviename
            // 
            this.txt_moviename.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_moviename.Location = new System.Drawing.Point(26, 60);
            this.txt_moviename.Name = "txt_moviename";
            this.txt_moviename.Size = new System.Drawing.Size(278, 26);
            this.txt_moviename.TabIndex = 3;
            this.txt_moviename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_moviename_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movie Search";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1924, 948);
            this.Controls.Add(this.groupBox_movie);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_movie.ResumeLayout(false);
            this.groupBox_movie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_poster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_movie;
        private System.Windows.Forms.ListBox lst_movies;
        private System.Windows.Forms.TextBox txt_moviename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label lbl_rating;
        private System.Windows.Forms.Label lbl_moviename;
        private System.Windows.Forms.ListBox lst_director;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lst_star;
        private System.Windows.Forms.ListBox lst_writer;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.Label lbl_photos;
        private System.Windows.Forms.ListBox lst_casts;
        private System.Windows.Forms.PictureBox pct_poster;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ImageList imglst_icon;
        private System.Windows.Forms.Button btn_addwatchlist;
        private System.Windows.Forms.ComboBox cmb_categories;
        private System.Windows.Forms.Label lbl_category;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_watchlist;
    }
}