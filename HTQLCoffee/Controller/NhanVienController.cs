using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Controller
{
    public class NhanVienController
    {
        private readonly NhanVienDAO _nhanVienDAO;

        public NhanVienController(string connectionString)
        {
            _nhanVienDAO = new NhanVienDAO(connectionString);
        }

        public List<NhanVienModel> LayDanhSachNhanVien()
        {
            return _nhanVienDAO.LayDanhSachNhanVien();
        }
    }
}
