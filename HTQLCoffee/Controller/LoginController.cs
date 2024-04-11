using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Controller
{
    class LoginController
    {
        private LoginModel loginModel;
        public LoginController()
        {
            this.loginModel = new LoginModel();
        }
        public bool login(string username, string password)
        {
            return this.loginModel.isCheckAccount(username, password);
        }

        public bool changePassword(String oldPassword, String newPassword)
        {
            return this.loginModel.changePassword(Authorize.Instance.MaNV, oldPassword, newPassword);
        }
    }
}
