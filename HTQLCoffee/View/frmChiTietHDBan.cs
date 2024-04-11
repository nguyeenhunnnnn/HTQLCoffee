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
    public partial class frmChiTietHDBan : Form
    {
        private int phieuNhapID;
        private readonly HoaDonController _hoaDonController;
        string connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;
        public frmChiTietHDBan(int phieuNhapID)
        {
            InitializeComponent();
            _hoaDonController = new HoaDonController(connectionString);
            this.phieuNhapID = phieuNhapID;
            HienThiChiTietPhieuNhap();
        }
        private void HienThiChiTietPhieuNhap()
        {
            List<ChiTietHoaDon> danhSachPhieuNhap = _hoaDonController.LayDanhSachChiTietPhieuBan(phieuNhapID);
            listChiTietBan.DataSource = danhSachPhieuNhap;
        }
    }
}
