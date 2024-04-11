using HTQLCoffee.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.View
{
    public partial class LoginView : Form
    {
        LoginController logincontroller;
        public LoginView()
        {
            InitializeComponent();
            logincontroller = new LoginController();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            string username = textUsername.Text;
            string password = textPassword.Text;
            if (!validateAccount(username, password))
            {
                return;
            }

            bool isCheckAccount = logincontroller.login(username, password);
             
            if (isCheckAccount)
            {
                Form home = new MainForm();
                this.Hide();
                home.ShowDialog();
                this.Close();
            }
        }
        private bool validateAccount(string username, string password)
        {
            if (username == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {
            textPassword.PasswordChar = '\u25CF';
        }
    }
}
