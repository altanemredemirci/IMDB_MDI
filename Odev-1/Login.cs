using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev_1
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        DataAccessLayer DAL;
        Movie movie;
        public Login()
        {
            DAL = new DataAccessLayer();
            InitializeComponent();
        }
        public Login(Movie film)
        {
            DAL = new DataAccessLayer();
            movie = film;
            InitializeComponent();
        }
        User user;
        private void mbtn_login_Click(object sender, EventArgs e)
        {
            user = new User();
            user.Username = mtxt_username.Text;
            user.Password = mtxt_password.Text;
            user = DAL.Login(user);
            if (user==null)
            {
                DialogResult result = MessageBox.Show("Kayıtlı Bulunamadı. Kayıt olmak ister misiniz?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Register register = new Register();
                    this.Hide();
                    register.Show();
                }
                else if (result == DialogResult.No)
                {
                    Login login = new Login();
                    this.Hide();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("System failure");
                    Application.Exit();
                }
            }
            else
            {
                if(movie == null)
                {
                    WatchList watchList = new WatchList(user);
                    watchList.Show();
                    this.Hide();
                }
                else
                {
                    WatchList watchList = new WatchList(user, movie);
                    watchList.Show();
                    this.Hide();
                }
            }
        }

        private void mbtn_register_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
