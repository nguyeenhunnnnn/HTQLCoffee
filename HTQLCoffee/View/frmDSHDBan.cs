using HTQLCoffee.Controller;
using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.View
{
    public partial class frmDSHDBan : Form
    {
        private readonly NhanVienController _nhanVienController;
        private readonly HoaDonController _hoaDonController;
        string connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;
        private int selectedPhieuNhapID = -1;
        public frmDSHDBan()
        {
            InitializeComponent();
            _hoaDonController = new HoaDonController(connectionString);
            _nhanVienController = new NhanVienController(connectionString);
            HienThiDanhSachHDNhap();
            HienThiDSComboBox();
            viewDetail.Enabled = false;
            InHDNhap.Enabled = false;
        }
        private void HienThiDSComboBox()
        {
            List<NhanVienModel> danhSachNhanVien = _nhanVienController.LayDanhSachNhanVien();
            comboboxNhanVien.DataSource = danhSachNhanVien;
            comboboxNhanVien.DisplayMember = "TenNhanVien";
            comboboxNhanVien.ValueMember = "NhanVienID";
        }
        private void HienThiDanhSachHDNhap()
        {
            List<HoaDon> danhSachPhieuNhap = _hoaDonController.LayDanhSachHoaDon();
            listPhieuNhap.DataSource = danhSachPhieuNhap;
            listPhieuNhap.Columns["PhieuNhapID"].HeaderText = "Mã hóa đơn";
            listPhieuNhap.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            listPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày tạo";
            listPhieuNhap.Columns["TongTien"].HeaderText = "Tổng tiền";
        }
        private void searchHD_Click(object sender, EventArgs e)
        {
            int nhanvienID = (int)comboboxNhanVien.SelectedValue;
            DateTime ngayLap = dateTimePickerNgayTao.Value;
            List<HoaDon> ketQuaTimKiem = _hoaDonController.TimKiemPhieuNhap(nhanvienID, ngayLap.ToString("yyyy-MM-dd"));
            listPhieuNhap.DataSource = ketQuaTimKiem;
            listPhieuNhap.Columns["PhieuNhapID"].HeaderText = "Mã hóa đơn";
            listPhieuNhap.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            listPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày tạo";
            listPhieuNhap.Columns["TongTien"].HeaderText = "Tổng tiền";
        }
        private void allDSHD_Click(object sender, EventArgs e)
        {
            HienThiDanhSachHDNhap();
        }
        private void DSHDNhapCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = listPhieuNhap.Rows[e.RowIndex];
                selectedPhieuNhapID = Convert.ToInt32(selectedRow.Cells["PhieuNhapID"].Value);
                viewDetail.Enabled = true;
                InHDNhap.Enabled = true;
            }
        }
        private void viewDetail_Click(object sender, EventArgs e)
        {
            frmChiTietHDBan formChiTiet = new frmChiTietHDBan(selectedPhieuNhapID);
            formChiTiet.Show();
        }

        private void InHDNhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Usp_LayChiTietHoaDon", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@HoaDonID", selectedPhieuNhapID);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    chiTietHDBan report = new chiTietHDBan();
                    report.SetDataSource(dataTable);
                    report.SetParameterValue("@HoaDonID", selectedPhieuNhapID);
                    frmInBaoCao frm = new frmInBaoCao();
                    frm.crystalReportViewer1.ReportSource = report;
                    frm.Show();
                }
            }
        }
    }
}
