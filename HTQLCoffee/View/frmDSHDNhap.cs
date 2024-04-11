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
    public partial class frmDSHDNhap : Form
    {
        private readonly NhanVienController _nhanVienController;
        private readonly PhieuNhapController _phieuNhapController;
        string connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;
        private int selectedPhieuNhapID = -1;
        public frmDSHDNhap()
        {
            InitializeComponent();
            _phieuNhapController = new PhieuNhapController(connectionString);
            _nhanVienController = new NhanVienController(connectionString);
            HienThiDanhSachHDNhap();
            HienThiDSComboBox();
            viewDetail.Enabled = false;
            InHDNhap.Enabled=false;
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
            List<PhieuNhap> danhSachPhieuNhap = _phieuNhapController.LayDanhSachPhieuNhap();
            listPhieuNhap.DataSource = danhSachPhieuNhap;
            listPhieuNhap.Columns["PhieuNhapID"].HeaderText = "Mã phiếu";
            listPhieuNhap.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            listPhieuNhap.Columns["TenNhaCungCap"].HeaderText = "Nhà cung cấp";
            listPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày tạo";
            listPhieuNhap.Columns["TongTien"].HeaderText = "Tổng tiền";
        }

        private void searchHD_Click(object sender, EventArgs e)
        {
            int nhanvienID = (int)comboboxNhanVien.SelectedValue;
            DateTime ngayLap = dateTimePickerNgayTao.Value;
            List<PhieuNhap> ketQuaTimKiem = _phieuNhapController.TimKiemPhieuNhap(nhanvienID, ngayLap.ToString("yyyy-MM-dd"));
            listPhieuNhap.DataSource = ketQuaTimKiem;
            listPhieuNhap.Columns["PhieuNhapID"].HeaderText = "Mã phiếu";
            listPhieuNhap.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            listPhieuNhap.Columns["TenNhaCungCap"].HeaderText = "Nhà cung cấp";
            listPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày tạo";
            listPhieuNhap.Columns["TongTien"].HeaderText = "Tổng tiền";
        }

        private void addDSHDNhap_Click(object sender, EventArgs e)
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
            frmChiTietHDNhap formChiTiet = new frmChiTietHDNhap(selectedPhieuNhapID);
            formChiTiet.Show();
        }

        private void InHDNhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Usp_LayChiTietPhieuNhap", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PhieuNhapID", selectedPhieuNhapID);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    chiTietHDNhap report = new chiTietHDNhap();
                    report.SetDataSource(dataTable);
                    report.SetParameterValue("@PhieuNhapID", selectedPhieuNhapID);
                    frmInBaoCao frm = new frmInBaoCao();
                    frm.crystalReportViewer1.ReportSource = report;
                    frm.Show();
                }
            }
        }
    }
}
