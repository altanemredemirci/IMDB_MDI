namespace Odev_1
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.mtxt_username = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_password = new MetroFramework.Controls.MetroTextBox();
            this.mbtn_login = new MetroFramework.Controls.MetroButton();
            this.mbtn_register = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mbtn_register);
            this.panel1.Controls.Add(this.mtxt_username);
            this.panel1.Controls.Add(this.mtxt_password);
            this.panel1.Controls.Add(this.mbtn_login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 183);
            this.panel1.TabIndex = 0;
            // 
            // mtxt_username
            // 
            // 
            // 
            // 
            this.mtxt_username.CustomButton.Image = null;
            this.mtxt_username.CustomButton.Location = new System.Drawing.Point(228, 1);
            this.mtxt_username.CustomButton.Name = "";
            this.mtxt_username.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtxt_username.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_username.CustomButton.TabIndex = 1;
            this.mtxt_username.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_username.CustomButton.UseSelectable = true;
            this.mtxt_username.CustomButton.Visible = false;
            this.mtxt_username.DisplayIcon = true;
            this.mtxt_username.Icon = ((System.Drawing.Image)(resources.GetObject("mtxt_username.Icon")));
            this.mtxt_username.IconRight = true;
            this.mtxt_username.Lines = new string[0];
            this.mtxt_username.Location = new System.Drawing.Point(86, 29);
            this.mtxt_username.MaxLength = 32767;
            this.mtxt_username.Name = "mtxt_username";
            this.mtxt_username.PasswordChar = '\0';
            this.mtxt_username.PromptText = "Enter your username";
            this.mtxt_username.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_username.SelectedText = "";
            this.mtxt_username.SelectionLength = 0;
            this.mtxt_username.SelectionStart = 0;
            this.mtxt_username.ShortcutsEnabled = true;
            this.mtxt_username.Size = new System.Drawing.Size(250, 23);
            this.mtxt_username.TabIndex = 7;
            this.mtxt_username.UseSelectable = true;
            this.mtxt_username.WaterMark = "Enter your username";
            this.mtxt_username.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_username.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_password
            // 
            // 
            // 
            // 
            this.mtxt_password.CustomButton.Image = null;
            this.mtxt_password.CustomButton.Location = new System.Drawing.Point(228, 1);
            this.mtxt_password.CustomButton.Name = "";
            this.mtxt_password.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtxt_password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_password.CustomButton.TabIndex = 1;
            this.mtxt_password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_password.CustomButton.UseSelectable = true;
            this.mtxt_password.CustomButton.Visible = false;
            this.mtxt_password.DisplayIcon = true;
            this.mtxt_password.Icon = ((System.Drawing.Image)(resources.GetObject("mtxt_password.Icon")));
            this.mtxt_password.IconRight = true;
            this.mtxt_password.Lines = new string[0];
            this.mtxt_password.Location = new System.Drawing.Point(86, 71);
            this.mtxt_password.MaxLength = 32767;
            this.mtxt_password.Name = "mtxt_password";
            this.mtxt_password.PasswordChar = '\0';
            this.mtxt_password.PromptText = "Enter your password";
            this.mtxt_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_password.SelectedText = "";
            this.mtxt_password.SelectionLength = 0;
            this.mtxt_password.SelectionStart = 0;
            this.mtxt_password.ShortcutsEnabled = true;
            this.mtxt_password.Size = new System.Drawing.Size(250, 23);
            this.mtxt_password.TabIndex = 8;
            this.mtxt_password.UseSelectable = true;
            this.mtxt_password.WaterMark = "Enter your password";
            this.mtxt_password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbtn_login
            // 
            this.mbtn_login.BackColor = System.Drawing.Color.CornflowerBlue;
            this.mbtn_login.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mbtn_login.Location = new System.Drawing.Point(261, 112);
            this.mbtn_login.Name = "mbtn_login";
            this.mbtn_login.Size = new System.Drawing.Size(75, 23);
            this.mbtn_login.TabIndex = 10;
            this.mbtn_login.Text = "LOGIN";
            this.mbtn_login.UseCustomBackColor = true;
            this.mbtn_login.UseCustomForeColor = true;
            this.mbtn_login.UseSelectable = true;
            this.mbtn_login.UseStyleColors = true;
            this.mbtn_login.Click += new System.EventHandler(this.mbtn_login_Click);
            // 
            // mbtn_register
            // 
            this.mbtn_register.BackColor = System.Drawing.Color.CornflowerBlue;
            this.mbtn_register.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mbtn_register.Location = new System.Drawing.Point(86, 112);
            this.mbtn_register.Name = "mbtn_register";
            this.mbtn_register.Size = new System.Drawing.Size(75, 23);
            this.mbtn_register.TabIndex = 11;
            this.mbtn_register.Text = "REGISTER";
            this.mbtn_register.UseCustomBackColor = true;
            this.mbtn_register.UseCustomForeColor = true;
            this.mbtn_register.UseSelectable = true;
            this.mbtn_register.UseStyleColors = true;
            this.mbtn_register.Click += new System.EventHandler(this.mbtn_register_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 263);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Login";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton mbtn_login;
        private MetroFramework.Controls.MetroTextBox mtxt_password;
        private MetroFramework.Controls.MetroTextBox mtxt_username;
        private MetroFramework.Controls.MetroButton mbtn_register;
    }
}