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
    public partial class frmChiTietHDNhap : Form
    {
        private int phieuNhapID;
        private readonly PhieuNhapController _phieuNhapController;
        string connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;
        public frmChiTietHDNhap(int phieuNhapID)
        {
            InitializeComponent();
            _phieuNhapController = new PhieuNhapController(connectionString);
            this.phieuNhapID = phieuNhapID;
            HienThiChiTietPhieuNhap();
        }
        private void HienThiChiTietPhieuNhap()
        {
            List<ChiTietPhieuNhap> danhSachPhieuNhap = _phieuNhapController.LayDanhSachChiTietPhieuNhap(phieuNhapID);
            listChiTietNhap.DataSource = danhSachPhieuNhap;
        }
    }
}
