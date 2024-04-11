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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
            LoadData();
        }
        private string connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;


        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT 
                            PK_iNhanvienID AS 'Mã Nhân Viên', 
                            sTenNhanvien AS 'Tên Nhân Viên', 
                            sSodienthoai AS 'Số Điện Thoại', 
                            sDiachi AS 'Địa Chỉ', 
                            dNgaysinh AS 'Ngày Sinh', 
                            CASE WHEN bGioitinh = 1 THEN N'Nam' ELSE N'Nữ' END AS 'Giới Tính' 
                        FROM tblNhanvien";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);



                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void ResetForm()
        {
            // Xóa nội dung của các control trên form và đặt giá trị mặc định
            tbmanv.Text = ""; // Đặt mã nhân viên về giá trị rỗng
            tb_tennv.Text = "";
            tb_sdt.Text = "";
            tb_diachi.Text = "";
            dateTimePickerngaysinh.Value = DateTime.Now; // Đặt ngày sinh mặc định là ngày hiện tại
            radionam.Checked = true; // Đặt giới tính mặc định là Nam
                                     // Các thiết lập khác tùy thuộc vào yêu cầu cụ thể của form

            // Đặt lại dữ liệu trong DataGridView về rỗng

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //lấy dữ liệu từ datagridview

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy dữ liệu từ dòng được chọn và hiển thị lên các ô nhập
                tbmanv.Text = selectedRow.Cells["Mã Nhân Viên"].Value.ToString();
                tb_tennv.Text = selectedRow.Cells["Tên Nhân Viên"].Value.ToString();
                tb_sdt.Text = selectedRow.Cells["Số Điện Thoại"].Value.ToString();
                tb_diachi.Text = selectedRow.Cells["Địa Chỉ"].Value.ToString();
                dateTimePickerngaysinh.Value = Convert.ToDateTime(selectedRow.Cells["Ngày Sinh"].Value);

                // Giới tính
                string gioiTinh = selectedRow.Cells["Giới Tính"].Value.ToString();
                if (gioiTinh == "Nam")
                    radionam.Checked = true;
                else
                    radionu.Checked = true;
            }
        }


        private bool CheckDuplicateSoDienThoai(string soDienThoai)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM tblNhanvien WHERE sSodienthoai = @SoDienThoai";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các ô nhập trên form
                string maNhanVien = tbmanv.Text;
                string tenNhanVien = tb_tennv.Text;
                string soDienThoai = tb_sdt.Text;
                string diaChi = tb_diachi.Text;
                DateTime ngaySinh = dateTimePickerngaysinh.Value;
                bool gioiTinh = radionam.Checked; // true nếu là Nam, false nếu là Nữ

                // Kiểm tra xem đã nhập đủ các thuộc tính chưa
                if (maNhanVien == "" || tenNhanVien == "" || soDienThoai == "" || diaChi == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin của nhân viên!");
                    return; // Dừng thực thi hàm nếu không nhập đủ thông tin
                }

                // Kiểm tra xem mã nhân viên có trùng lặp không
                bool duplicateMaNV = CheckDuplicateMaNV(maNhanVien);
                if (duplicateMaNV)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã nhân viên khác!");
                    return; // Dừng thực thi hàm nếu mã nhân viên đã tồn tại
                }

                // Kiểm tra xem số điện thoại có trùng lặp không
                bool duplicateSoDienThoai = CheckDuplicateSoDienThoai(soDienThoai);
                if (duplicateSoDienThoai)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập số điện thoại khác!");
                    return; // Dừng thực thi hàm nếu số điện thoại đã tồn tại
                }

                // Thêm dữ liệu mới vào cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO tblNhanvien (PK_iNhanvienID, sTenNhanvien, sSodienthoai, sDiachi, dNgaysinh, bGioitinh) 
                            VALUES (@MaNhanVien, @TenNhanVien, @SoDienThoai, @DiaChi, @NgaySinh, @GioiTinh)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@TenNhanVien", tenNhanVien);
                    command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem dữ liệu đã được thêm thành công vào cơ sở dữ liệu chưa
                    if (rowsAffected > 0)
                    {
                        // Nếu thêm thành công, làm mới dữ liệu trên DataGridView để hiển thị dữ liệu mới
                        LoadData();



                        MessageBox.Show("Thêm nhân viên thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm nhân viên vào cơ sở dữ liệu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        // Hàm kiểm tra mã nhân viên có trùng lặp không
        private bool CheckDuplicateMaNV(string maNhanVien)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM tblNhanvien WHERE PK_iNhanvienID = @MaNhanVien";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }


        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các ô nhập trên form
                string maNhanVien = tbmanv.Text;
                string tenNhanVien = tb_tennv.Text;
                string soDienThoai = tb_sdt.Text;
                string diaChi = tb_diachi.Text;
                DateTime ngaySinh = dateTimePickerngaysinh.Value;
                bool gioiTinh = radionam.Checked; // true nếu là Nam, false nếu là Nữ

                // Kiểm tra xem đã nhập đủ các thuộc tính chưa
                if (maNhanVien == "" || tenNhanVien == "" || soDienThoai == "" || diaChi == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin của nhân viên!");
                    return; // Dừng thực thi hàm nếu không nhập đủ thông tin
                }

                // Thực hiện cập nhật dữ liệu vào cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE tblNhanvien SET sTenNhanvien = @TenNhanVien, sSodienthoai = @SoDienThoai, sDiachi = @DiaChi, dNgaysinh = @NgaySinh, bGioitinh = @GioiTinh 
                            WHERE PK_iNhanvienID = @MaNhanVien";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenNhanVien", tenNhanVien);
                    command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem dữ liệu đã được cập nhật thành công vào cơ sở dữ liệu chưa
                    if (rowsAffected > 0)
                    {
                        // Nếu cập nhật thành công, làm mới dữ liệu trên DataGridView để hiển thị dữ liệu mới
                        LoadData();

                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên cần cập nhật hoặc dữ liệu không thay đổi!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã nhân viên từ ô nhập trên form
                string maNhanVien = tbmanv.Text;

                // Kiểm tra xem mã nhân viên đã được nhập vào chưa
                if (maNhanVien == "")
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa!");
                    return; // Dừng thực thi hàm nếu không nhập mã nhân viên
                }

                // Xác nhận việc xóa dữ liệu
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện câu lệnh SQL để xóa dữ liệu khỏi cơ sở dữ liệu
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM tblNhanvien WHERE PK_iNhanvienID = @MaNhanVien";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                        int rowsAffected = command.ExecuteNonQuery();

                        // Kiểm tra xem dữ liệu đã được xóa thành công khỏi cơ sở dữ liệu chưa
                        if (rowsAffected > 0)
                        {
                            // Nếu xóa thành công, làm mới dữ liệu trên DataGridView để hiển thị dữ liệu mới
                            LoadData();

                            MessageBox.Show("Xóa nhân viên thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên cần xóa!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các ô nhập trên form
                string maNhanVien = tbmanv.Text.Trim();
                string tenNhanVien = tb_tennv.Text.Trim();
                string soDienThoai = tb_sdt.Text.Trim();
                string diaChi = tb_diachi.Text.Trim();
                bool isNam = radionam.Checked;
                bool isNu = radionu.Checked;

                // Thực hiện câu lệnh SQL để tìm kiếm dữ liệu trong cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                PK_iNhanvienID AS 'Mã Nhân Viên', 
                                sTenNhanvien AS 'Tên Nhân Viên', 
                                sSodienthoai AS 'Số Điện Thoại', 
                                sDiachi AS 'Địa Chỉ', 
                                dNgaysinh AS 'Ngày Sinh', 
                                CASE WHEN bGioitinh = 1 THEN N'Nam' ELSE N'Nữ' END AS 'Giới Tính' 
                            FROM tblNhanvien
                            WHERE (@MaNhanVien = '' OR PK_iNhanvienID LIKE @MaNhanVien)
                            AND (@TenNhanVien = '' OR sTenNhanvien LIKE @TenNhanVien)
                            AND (@SoDienThoai = '' OR sSodienthoai LIKE @SoDienThoai)
                            AND (@DiaChi = '' OR sDiachi LIKE @DiaChi)
                            AND (@IsNam = 0 OR bGioitinh = 1)
                            AND (@IsNu = 0 OR bGioitinh = 0)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNhanVien", "%" + maNhanVien + "%");
                    command.Parameters.AddWithValue("@TenNhanVien", "%" + tenNhanVien + "%");
                    command.Parameters.AddWithValue("@SoDienThoai", "%" + soDienThoai + "%");
                    command.Parameters.AddWithValue("@DiaChi", "%" + diaChi + "%");
                    command.Parameters.AddWithValue("@IsNam", isNam ? 1 : 0);
                    command.Parameters.AddWithValue("@IsNu", isNu ? 1 : 0);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Kiểm tra xem có kết quả tìm kiếm nào không
                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}
