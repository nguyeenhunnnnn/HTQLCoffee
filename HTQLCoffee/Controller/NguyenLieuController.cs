using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Controller
{
    internal class NguyenLieuController
    {
        private readonly NguyenLieuDAO _nguyenLieuDAO;

        public NguyenLieuController(string connectionString)
        {
            _nguyenLieuDAO = new NguyenLieuDAO(connectionString);
        }

        public List<NguyenLieuModel> LayDanhSachNguyenLieu()
        {
            return _nguyenLieuDAO.LayDanhSachNguyenLieu();
        }
    }
}
