using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Controller
{
    internal class DouongController
    {
        private readonly DoUongDAO _doUongDAO;

        public DouongController(string connectionString)
        {
            _doUongDAO = new DoUongDAO(connectionString);
        }

        public List<DouongModel> DanhSachDoUong()
        {
            return _doUongDAO.GetDouongs();
        }
    }
}
