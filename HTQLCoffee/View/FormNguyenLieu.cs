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
    public partial class FormNguyenLieu : Form
    {
        public FormNguyenLieu()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.CellClick += dataGridView1_CellClick;
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
                                PK_iNguyenlieuID AS 'Mã Nguyên Liệu', 
                                sTenNguyenlieu AS 'Tên Nguyên Liệu', 
                                fSoluong AS 'Số Lượng', 
                                sDonvitinh AS 'Đơn Vị Tính' 
                            FROM tblNguyenlieu";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            try
            {
                // Xóa nội dung của các ô nhập liệu trên form và đặt giá trị mặc định
                tbmanguyenlieu.Text = "";
                tbtennguyenlieu.Text = "";
                tbsoluong.Text = "";
                tbdonvi.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                    // Lấy dữ liệu từ dòng được chọn và hiển thị lên các ô nhập liệu
                    tbmanguyenlieu.Text = selectedRow.Cells["Mã Nguyên Liệu"].Value.ToString();
                    tbtennguyenlieu.Text = selectedRow.Cells["Tên Nguyên Liệu"].Value.ToString();
                    tbsoluong.Text = selectedRow.Cells["Số Lượng"].Value.ToString();
                    tbdonvi.Text = selectedRow.Cells["Đơn Vị Tính"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private bool IsMaNguyenLieuExisted(string maNguyenLieu)
        {
            bool isExisted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM tblNguyenlieu WHERE PK_iNguyenlieuID = @MaNguyenLieu";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNguyenLieu", maNguyenLieu);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        isExisted = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return isExisted;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các ô nhập liệu trên form
                string maNguyenLieu = tbmanguyenlieu.Text.Trim();
                string tenNguyenLieu = tbtennguyenlieu.Text.Trim();
                string soLuong = tbsoluong.Text.Trim();
                string donViTinh = tbdonvi.Text.Trim();

                // Kiểm tra tính hợp lệ của dữ liệu đầu vào
                if (maNguyenLieu == "" || tenNguyenLieu == "" || soLuong == "" || donViTinh == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                // Kiểm tra xem mã nguyên liệu đã tồn tại trong cơ sở dữ liệu hay chưa
                if (IsMaNguyenLieuExisted(maNguyenLieu))
                {
                    MessageBox.Show("Mã nguyên liệu đã tồn tại. Vui lòng nhập lại mã nguyên liệu khác!");
                    return;
                }

                // Thực hiện thêm dữ liệu vào cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO tblNguyenlieu (PK_iNguyenlieuID, sTenNguyenlieu, fSoluong, sDonvitinh) 
                            VALUES (@MaNguyenLieu, @TenNguyenLieu, @SoLuong, @DonViTinh)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNguyenLieu", maNguyenLieu);
                    command.Parameters.AddWithValue("@TenNguyenLieu", tenNguyenLieu);
                    command.Parameters.AddWithValue("@SoLuong", float.Parse(soLuong));
                    command.Parameters.AddWithValue("@DonViTinh", donViTinh);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem dữ liệu đã được thêm thành công vào cơ sở dữ liệu chưa
                    if (rowsAffected > 0)
                    {
                        // Làm mới dữ liệu trong DataGridView
                        LoadData();

                        // Xóa nội dung của các ô nhập liệu để chuẩn bị cho việc nhập liệu mới
                        ResetForm();

                        MessageBox.Show("Thêm nguyên liệu thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm nguyên liệu vào cơ sở dữ liệu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các ô nhập liệu trên form
                string maNguyenLieu = tbmanguyenlieu.Text.Trim();
                string tenNguyenLieu = tbtennguyenlieu.Text.Trim();
                string soLuong = tbsoluong.Text.Trim();
                string donViTinh = tbdonvi.Text.Trim();

                // Kiểm tra tính hợp lệ của dữ liệu đầu vào
                if (maNguyenLieu == "" || tenNguyenLieu == "" || soLuong == "" || donViTinh == "")
                {
                    MessageBox.Show("Vui lòng chọn một nguyên liệu để sửa!");
                    return;
                }

                // Thực hiện cập nhật dữ liệu trong cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE tblNguyenlieu 
                            SET sTenNguyenlieu = @TenNguyenLieu, fSoluong = @SoLuong, sDonvitinh = @DonViTinh 
                            WHERE PK_iNguyenlieuID = @MaNguyenLieu";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenNguyenLieu", tenNguyenLieu);
                    command.Parameters.AddWithValue("@SoLuong", float.Parse(soLuong));
                    command.Parameters.AddWithValue("@DonViTinh", donViTinh);
                    command.Parameters.AddWithValue("@MaNguyenLieu", maNguyenLieu);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem dữ liệu đã được cập nhật thành công trong cơ sở dữ liệu chưa
                    if (rowsAffected > 0)
                    {
                        // Làm mới dữ liệu trong DataGridView
                        LoadData();

                        // Xóa nội dung của các ô nhập liệu để chuẩn bị cho việc nhập liệu mới
                        ResetForm();

                        MessageBox.Show("Cập nhật nguyên liệu thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật nguyên liệu trong cơ sở dữ liệu!");
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
                // Lấy mã nguyên liệu từ ô nhập liệu
                string maNguyenLieu = tbmanguyenlieu.Text.Trim();

                // Kiểm tra tính hợp lệ của dữ liệu đầu vào
                if (maNguyenLieu == "")
                {
                    MessageBox.Show("Vui lòng chọn một nguyên liệu để xóa!");
                    return;
                }

                // Thực hiện xóa dữ liệu từ cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string query = @"DELETE FROM tblNguyenlieu WHERE PK_iNguyenlieuID = @MaNguyenLieu";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNguyenLieu", maNguyenLieu);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem dữ liệu đã được xóa thành công trong cơ sở dữ liệu chưa
                    if (rowsAffected > 0)
                    {
                        // Làm mới dữ liệu trong DataGridView
                        LoadData();

                        // Xóa nội dung của các ô nhập liệu để chuẩn bị cho việc nhập liệu mới
                        ResetForm();

                        MessageBox.Show("Xóa nguyên liệu thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nguyên liệu từ cơ sở dữ liệu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnlmmoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ ô nhập liệu
                string tuKhoa = txtTimKiem.Text.Trim();

                // Kiểm tra xem từ khóa tìm kiếm có rỗng hay không
                if (tuKhoa == "")
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu truy vấn SQL để tìm kiếm nguyên liệu
                    string query = @"SELECT 
                                PK_iNguyenlieuID AS 'Mã Nguyên Liệu', 
                                sTenNguyenlieu AS 'Tên Nguyên Liệu', 
                                fSoluong AS 'Số Lượng', 
                                sDonvitinh AS 'Đơn Vị Tính' 
                            FROM tblNguyenlieu 
                            WHERE sTenNguyenlieu LIKE @TuKhoa";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Kiểm tra xem có bản ghi nào được tìm thấy hay không
                    if (dataTable.Rows.Count > 0)
                    {
                        // Hiển thị kết quả tìm kiếm trên DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nguyên liệu nào phù hợp với từ khóa tìm kiếm!");
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
