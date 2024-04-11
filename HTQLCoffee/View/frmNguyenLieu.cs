using HTQLCoffee.Controller;
using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.View
{
    public partial class frmNguyenLieu : Form
    {
        private readonly NguyenLieuController _nguyenLieuController;
        string connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;
        public frmNguyenLieu()
        {
            InitializeComponent();
            _nguyenLieuController = new NguyenLieuController(connectionString);
            HienThiDanhSachNguyenLieu();
        }
        private void HienThiDanhSachNguyenLieu()
        {
            List<NguyenLieuModel> danhSachNguyenLieu = _nguyenLieuController.LayDanhSachNguyenLieu();
            listNguyenLieu.DataSource = danhSachNguyenLieu;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
