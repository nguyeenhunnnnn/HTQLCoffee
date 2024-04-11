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
    public partial class frmHDBan : Form
    {
        private readonly NhanVienController _nhanVienController;
        private readonly DouongController _doUongController;
        private readonly HoaDonController _hoaDonController;
        string connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;
        public frmHDBan()
        {
            _nhanVienController = new NhanVienController(connectionString);
            _doUongController = new DouongController(connectionString);
            _hoaDonController = new HoaDonController(connectionString);
            InitializeComponent();
            this.Size = new Size(1000, 500); 
            delNL.Enabled = false;
            HienThiComboBox();
        }
        public class SelectedProduct
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public float Price { get; set; }
            public int Quantity { get; set; }
        }
        // Danh sách lưu trữ các sản phẩm đã chọn tạm thời
        List<SelectedProduct> selectedProducts = new List<SelectedProduct>();
        private void HienThiComboBox()
        {
            List<NhanVienModel> danhSachNhanVien = _nhanVienController.LayDanhSachNhanVien();
            comboboxNhanVien.DataSource = danhSachNhanVien;
            comboboxNhanVien.DisplayMember = "TenNhanVien";
            comboboxNhanVien.ValueMember = "NhanVienID";
            List<DouongModel> danhSachDoUong = _doUongController.DanhSachDoUong();
            cbbDoUong.DataSource=danhSachDoUong;
            cbbDoUong.DisplayMember = "sTenDouong";
            cbbDoUong.ValueMember = "PK_iDouongID";

        }

        private void addDU_Click(object sender, EventArgs e)
        {
            string productName = cbbDoUong.Text;
            float price;
            int quantity;
            if (cbbDoUong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int productID = (int)cbbDoUong.SelectedValue;

            // Kiểm tra và chuyển đổi dữ liệu nhập vào từ người dùng cho Đơn giá
            if (!float.TryParse(txtDongia.Text, out price))
            {
                MessageBox.Show("Đơn giá phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra và chuyển đổi dữ liệu nhập vào từ người dùng cho Số lượng
            if (!int.TryParse(numericUpDownSoluong.Text, out quantity))
            {
                MessageBox.Show("Số lượng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra dữ liệu hợp lệ (ví dụ: số lượng và đơn giá không âm)
            if (quantity <= 0 || price <= 0)
            {
                MessageBox.Show("Số lượng và đơn giá phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo một đối tượng SelectedProduct mới và thêm vào danh sách
            bool productExists = false;
            foreach (SelectedProduct product in selectedProducts)
            {
                if (product.ProductID == productID)
                {
                    // Cập nhật thông tin sản phẩm nếu đã tồn tại
                    product.Price = price;
                    product.Quantity = quantity;
                    productExists = true;
                    MessageBox.Show("Cập nhật nguyên liệu thành công");
                    // Hiển thị danh sách sản phẩm đã chọn trong DataGridView
                    dataGridViewSelectedProducts.DataSource = null;
                    dataGridViewSelectedProducts.DataSource = selectedProducts;
                    dataGridViewSelectedProducts.Columns["ProductID"].HeaderText = "Mã đồ uống";
                    dataGridViewSelectedProducts.Columns["ProductName"].HeaderText = "Tên đồ uống";
                    dataGridViewSelectedProducts.Columns["Price"].HeaderText = "Đơn giá";
                    dataGridViewSelectedProducts.Columns["Quantity"].HeaderText = "Số lượng";
                    cbbDoUong.SelectedIndex = -1;
                    txtDongia.Text = string.Empty;
                    numericUpDownSoluong.Value = 0;
                    break;
                }
            }

            // Nếu sản phẩm chưa tồn tại trong danh sách, thêm mới vào
            if (!productExists)
            {
                selectedProducts.Add(new SelectedProduct
                {
                    ProductID = productID,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                });
                // Hiển thị danh sách sản phẩm đã chọn trong DataGridView
                dataGridViewSelectedProducts.DataSource = null;
                dataGridViewSelectedProducts.DataSource = selectedProducts;
                dataGridViewSelectedProducts.Columns["ProductID"].HeaderText = "Mã đồ uống";
                dataGridViewSelectedProducts.Columns["ProductName"].HeaderText = "Tên đồ uống";
                dataGridViewSelectedProducts.Columns["Price"].HeaderText = "Đơn giá";
                dataGridViewSelectedProducts.Columns["Quantity"].HeaderText = "Số lượng";
                cbbDoUong.SelectedIndex = -1;
                txtDongia.Text = string.Empty;
                numericUpDownSoluong.Value = 0;
            }
        }
        private void dataGridViewSelectedProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSelectedProducts.SelectedRows.Count > 0)
            {
                delNL.Enabled = true;
            }
            else
            {
                delNL.Enabled = false;
            }
        }

        private void delNL_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewSelectedProducts.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewSelectedProducts.SelectedRows[0].Index;
                int productIDToRemove = selectedProducts[selectedIndex].ProductID;
                selectedProducts.RemoveAt(selectedIndex);
                dataGridViewSelectedProducts.DataSource = null;
                dataGridViewSelectedProducts.DataSource = selectedProducts;
                delNL.Enabled = false;
            }
        }

        private void addHDBan_Click(object sender, EventArgs e)
        {
            if (comboboxNhanVien.SelectedIndex == -1  || selectedProducts.Count == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn ít nhất một sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nhanvienID = (int)comboboxNhanVien.SelectedValue;
            DateTime ngaylap = dateTimePickerNgaylap.Value;

            // Kiểm tra ngày lập có lớn hơn ngày hiện tại không
            if (ngaylap > DateTime.Today)
            {
                MessageBox.Show("Ngày lập không thể là ngày tương lai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo DataTable để chứa dữ liệu chi tiết phiếu nhập
            DataTable chitietHoadonDetails = new DataTable();
            chitietHoadonDetails.Columns.Add("PK_iDouongID", typeof(int));
            chitietHoadonDetails.Columns.Add("fSoluong", typeof(float));
            chitietHoadonDetails.Columns.Add("fDongia", typeof(float));
            // Thêm dữ liệu từ danh sách sản phẩm đã chọn vào DataTable
            foreach (SelectedProduct product in selectedProducts)
            {
                chitietHoadonDetails.Rows.Add(product.ProductID, product.Quantity, product.Price);
            }
            // Tạo đối tượng PhieuNhap và gọi phương thức để thêm mới phiếu nhập
            HoaDonChung phieuNhap = new HoaDonChung();
            phieuNhap.NhanvienID = nhanvienID;
            phieuNhap.Ngaylap = ngaylap;
            _hoaDonController.ThemMoiHoaDon(phieuNhap, chitietHoadonDetails);
            MessageBox.Show("Thêm hóa đơn nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            selectedProducts.Clear();
            dataGridViewSelectedProducts.DataSource = null;
            cbbDoUong.SelectedIndex = -1;
            comboboxNhanVien.SelectedIndex = -1;
            delNL.Enabled = false;
        }
        private void resetHDban_Click(object sender, EventArgs e)
        {
            cbbDoUong.SelectedIndex = -1;
            txtDongia.Text = string.Empty;
            numericUpDownSoluong.Value = 0;
            comboboxNhanVien.SelectedIndex = -1;
            selectedProducts.Clear();
            dataGridViewSelectedProducts.DataSource = null;
            delNL.Enabled = false;
        }

        private void xemDSHDBan_Click(object sender, EventArgs e)
        {
            frmDSHDBan dSHDban = new frmDSHDBan();
            dSHDban.ShowDialog();
        }
    }
}
