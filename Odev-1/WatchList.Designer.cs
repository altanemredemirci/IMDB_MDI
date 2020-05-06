namespace Odev_1
{
    partial class WatchList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatchList));
            this.mpanel_movie = new MetroFramework.Controls.MetroPanel();
            this.lst_star = new System.Windows.Forms.ListBox();
            this.lst_director = new System.Windows.Forms.ListBox();
            this.lbl_moviename = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.btn_raiting = new System.Windows.Forms.Button();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.pct_poster = new System.Windows.Forms.PictureBox();
            this.cmb_watchlist = new System.Windows.Forms.ComboBox();
            this.lbl_watchlist = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mbtn_watchdelete = new MetroFramework.Controls.MetroButton();
            this.mpanel_movie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_poster)).BeginInit();
            this.SuspendLayout();
            // 
            // mpanel_movie
            // 
            this.mpanel_movie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mpanel_movie.Controls.Add(this.mbtn_watchdelete);
            this.mpanel_movie.Controls.Add(this.lst_star);
            this.mpanel_movie.Controls.Add(this.lst_director);
            this.mpanel_movie.Controls.Add(this.lbl_moviename);
            this.mpanel_movie.Controls.Add(this.label3);
            this.mpanel_movie.Controls.Add(this.label1);
            this.mpanel_movie.Controls.Add(this.txt_description);
            this.mpanel_movie.Controls.Add(this.btn_raiting);
            this.mpanel_movie.Controls.Add(this.pct_poster);
            this.mpanel_movie.HorizontalScrollbarBarColor = true;
            this.mpanel_movie.HorizontalScrollbarHighlightOnWheel = false;
            this.mpanel_movie.HorizontalScrollbarSize = 10;
            this.mpanel_movie.Location = new System.Drawing.Point(7, 156);
            this.mpanel_movie.Name = "mpanel_movie";
            this.mpanel_movie.Size = new System.Drawing.Size(604, 320);
            this.mpanel_movie.TabIndex = 0;
            this.mpanel_movie.UseCustomBackColor = true;
            this.mpanel_movie.UseCustomForeColor = true;
            this.mpanel_movie.VerticalScrollbarBarColor = true;
            this.mpanel_movie.VerticalScrollbarHighlightOnWheel = false;
            this.mpanel_movie.VerticalScrollbarSize = 10;
            this.mpanel_movie.Visible = false;
            // 
            // lst_star
            // 
            this.lst_star.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lst_star.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lst_star.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lst_star.FormattingEnabled = true;
            this.lst_star.ItemHeight = 15;
            this.lst_star.Location = new System.Drawing.Point(238, 200);
            this.lst_star.Name = "lst_star";
            this.lst_star.Size = new System.Drawing.Size(348, 64);
            this.lst_star.TabIndex = 14;
            // 
            // lst_director
            // 
            this.lst_director.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lst_director.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lst_director.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lst_director.FormattingEnabled = true;
            this.lst_director.ItemHeight = 15;
            this.lst_director.Location = new System.Drawing.Point(238, 151);
            this.lst_director.Name = "lst_director";
            this.lst_director.Size = new System.Drawing.Size(348, 34);
            this.lst_director.TabIndex = 13;
            // 
            // lbl_moviename
            // 
            this.lbl_moviename.AutoSize = true;
            this.lbl_moviename.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_moviename.ForeColor = System.Drawing.Color.DarkOrchid;
            this.lbl_moviename.Location = new System.Drawing.Point(180, 10);
            this.lbl_moviename.Name = "lbl_moviename";
            this.lbl_moviename.Size = new System.Drawing.Size(15, 23);
            this.lbl_moviename.TabIndex = 12;
            this.lbl_moviename.Text = "l";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(180, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Stars:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(181, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Director:";
            // 
            // txt_description
            // 
            this.txt_description.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_description.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_description.Location = new System.Drawing.Point(183, 80);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_description.Size = new System.Drawing.Size(403, 55);
            this.txt_description.TabIndex = 5;
            // 
            // btn_raiting
            // 
            this.btn_raiting.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_raiting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_raiting.ImageKey = "star.png";
            this.btn_raiting.ImageList = this.iconList;
            this.btn_raiting.Location = new System.Drawing.Point(183, 45);
            this.btn_raiting.Name = "btn_raiting";
            this.btn_raiting.Size = new System.Drawing.Size(56, 27);
            this.btn_raiting.TabIndex = 4;
            this.btn_raiting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_raiting.UseVisualStyleBackColor = true;
            this.btn_raiting.UseWaitCursor = true;
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "star.png");
            // 
            // pct_poster
            // 
            this.pct_poster.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pct_poster.Location = new System.Drawing.Point(10, 3);
            this.pct_poster.Name = "pct_poster";
            this.pct_poster.Size = new System.Drawing.Size(164, 261);
            this.pct_poster.TabIndex = 2;
            this.pct_poster.TabStop = false;
            // 
            // cmb_watchlist
            // 
            this.cmb_watchlist.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_watchlist.FormattingEnabled = true;
            this.cmb_watchlist.Location = new System.Drawing.Point(212, 83);
            this.cmb_watchlist.Name = "cmb_watchlist";
            this.cmb_watchlist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmb_watchlist.Size = new System.Drawing.Size(292, 26);
            this.cmb_watchlist.TabIndex = 1;
            this.cmb_watchlist.SelectedIndexChanged += new System.EventHandler(this.cmb_watchlist_SelectedIndexChanged);
            // 
            // lbl_watchlist
            // 
            this.lbl_watchlist.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_watchlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_watchlist.Font = new System.Drawing.Font("Cambria", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_watchlist.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbl_watchlist.Location = new System.Drawing.Point(0, 0);
            this.lbl_watchlist.Name = "lbl_watchlist";
            this.lbl_watchlist.Size = new System.Drawing.Size(622, 49);
            this.lbl_watchlist.TabIndex = 2;
            this.lbl_watchlist.Text = "WatchList";
            this.lbl_watchlist.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(76, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your Movies :";
            // 
            // mbtn_watchdelete
            // 
            this.mbtn_watchdelete.BackColor = System.Drawing.Color.CornflowerBlue;
            this.mbtn_watchdelete.ForeColor = System.Drawing.SystemColors.Window;
            this.mbtn_watchdelete.Location = new System.Drawing.Point(483, 279);
            this.mbtn_watchdelete.Name = "mbtn_watchdelete";
            this.mbtn_watchdelete.Size = new System.Drawing.Size(103, 23);
            this.mbtn_watchdelete.TabIndex = 15;
            this.mbtn_watchdelete.Text = "WATCHED";
            this.mbtn_watchdelete.UseCustomBackColor = true;
            this.mbtn_watchdelete.UseCustomForeColor = true;
            this.mbtn_watchdelete.UseSelectable = true;
            this.mbtn_watchdelete.Click += new System.EventHandler(this.mbtn_watchdelete_Click);
            // 
            // WatchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(622, 488);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_watchlist);
            this.Controls.Add(this.cmb_watchlist);
            this.Controls.Add(this.mpanel_movie);
            this.Name = "WatchList";
            this.Text = "WatchList";
            this.Load += new System.EventHandler(this.WatchList_Load);
            this.mpanel_movie.ResumeLayout(false);
            this.mpanel_movie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_poster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mpanel_movie;
        private System.Windows.Forms.PictureBox pct_poster;
        private System.Windows.Forms.Button btn_raiting;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_moviename;
        private System.Windows.Forms.ListBox lst_star;
        private System.Windows.Forms.ListBox lst_director;
        private System.Windows.Forms.ComboBox cmb_watchlist;
        private System.Windows.Forms.Label lbl_watchlist;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton mbtn_watchdelete;
    }
}