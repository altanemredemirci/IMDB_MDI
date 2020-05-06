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
    public partial class Register : MetroFramework.Forms.MetroForm 
    { 
        DataAccessLayer DAL;

        public Register()
        {
            DAL = new DataAccessLayer();
            InitializeComponent();
        }

        private void mbtn_register_Click(object sender, EventArgs e)
        {
            int karsilastirma = String.Compare(mtxt_regpassword.Text, mtxt_regpassword2.Text);
            if (karsilastirma == -1)
            {
                MessageBox.Show("Girdiğiniz şifreler uyuşmamaktadır.","Important Note",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxt_regpassword.Text = "";
                mtxt_regpassword2.Text = "";
            }
            else
            {
                int emailcntrl = EmailKontrol(mtxt_regmail.Text);
                if (emailcntrl == 1)
                {
                    User user = new User();
                    user.Username = mtxt_regusername.Text;
                    user.Password = mtxt_regpassword.Text;
                    user.Email = mtxt_regmail.Text;
                    int result = DAL.Register(user);
                    if (result > 0)
                    {
                        switch (result)
                        {
                            case 1:
                                MessageBox.Show("Kayıt İşlemi Başarılı", "Important",MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                Login lgn = new Login();
                                lgn.Show();
                                break;
                            case 2:
                                this.Hide();
                                Login login = new Login();
                                login.Show();
                                break;

                            case 3:
                                this.Hide();
                                Register register = new Register();
                                register.Show();
                                break;

                            case 4:
                                MessageBox.Show("System failure");
                                Application.Exit();
                                break;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Email adresiniz standart mail şablonuna uymamaktadır.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
         
        }
    
        public int EmailKontrol(string email)
        {
            #region "@" kontrolü
            bool varmi = false;
            int sayac = 0;
            int result=1;
            for (int i = 0; i < email.Length; i++)
            {
                if (email.Substring(i, 1) == "@")
                {
                    varmi = true;
                    sayac++;
                }
            }
            if (varmi == false || sayac != 1)
            {
                result = 0;
            }
            #endregion

            #region "." kontrolü
            bool varmi2 = false;
            for (int i = 0; i < email.Length; i++)
            {
                if (email.Substring(i, 1) == ".")
                {
                    varmi2 = true;
                }
            }
            if (varmi2 == false)
            {
                result = 0;
            }
            #endregion

            string[] dizi = email.Split('@');

            #region karakter kontrolü
            if (dizi[0] == "")
            {
                result = 0;
            }
            #endregion

            #region @ sonrası kontrol
            bool varmi3 = false;
            if (dizi.Length > 1)
            {
                for (int i = 0; i < dizi[1].Length; i++)
                {
                    if (dizi[1].Substring(i, 1) == ".")
                    {
                        varmi3 = true;
                    }
                }
                if (varmi3 == false)
                {
                    result = 0;
                }
                #endregion

                string[] dizi2 = dizi[1].Split('.');

                #region @ sonrası '.' kontrolü
                bool varmi4 = false;
                for (int i = 0; i < dizi2[dizi2.Length - 1].Length; i++)
                {
                    if (dizi2[dizi2.Length - 1].Substring(i, 1) != "")
                    {
                        varmi4 = true;
                    }
                }
                if (varmi4 == false)
                {
                    result = 0;
                }

                #endregion
            }


            #region ' ' kontrolü
            bool varmi5 = true;
            char[] dizi3 = email.ToCharArray();

            for (int i = 0; i < dizi3.Length; i++)
            {
                if (dizi3[i] == ' ')
                {
                    varmi5 = false;
                }
            }
            if (varmi5 == false)
            {
            }
            else
            {
                email = string.Concat(dizi3);
            }

            return result;
        #endregion

      
        }
    }
}
