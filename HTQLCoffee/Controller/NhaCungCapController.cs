using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Controller
{
    public class NhaCungCapController
    {
        private readonly NhaCungCapDAO _nhaCungCapDAO;

        public NhaCungCapController(string connectionString)
        {
            _nhaCungCapDAO = new NhaCungCapDAO(connectionString);
        }

        public List<NhaCungCapModel> LayDanhSachNhaCungCap()
        {
            return _nhaCungCapDAO.LayDanhSachNhaCungCap();
        }
    }
}
