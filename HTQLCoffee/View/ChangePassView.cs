using HTQLCoffee.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.View
{
    public partial class ChangePassView : Form
    {
        private LoginController loginController;
        public ChangePassView()
        {
            InitializeComponent();
            this.loginController = new LoginController();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string reNewPassword = txtReNewPassword.Text;

            if (!validatePassword(oldPassword, newPassword, reNewPassword))
            {
                return;
            }
            bool rowsAffected = loginController.changePassword(oldPassword, newPassword);
            if (!rowsAffected)
            {
                MessageBox.Show("Có lỗi xảy ra khi đổi mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Authorize.Instance.clearSession();
            Form login = new LoginView();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
        private bool validatePassword(string oldPassword, string newPassword, string reNewPassword)
        {
            if (oldPassword == string.Empty || newPassword == string.Empty || reNewPassword == string.Empty)
            {
                MessageBox.Show("Thiếu thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (reNewPassword != newPassword)
            {
                MessageBox.Show("Xác nhận mật khẩu mới không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            txtOldPassword.PasswordChar = '\u25CF';
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = '\u25CF';
        }

        private void txtReNewPassword_TextChanged(object sender, EventArgs e)
        {
            txtReNewPassword.PasswordChar = '\u25CF';
        }
    }
}