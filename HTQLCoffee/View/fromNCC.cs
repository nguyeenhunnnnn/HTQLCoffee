using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTQLCoffee.View
{
    public partial class frmNCC : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;

        public frmNCC()
        {
            InitializeComponent();
            Load += FrmNCC_Load;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void FrmNCC_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tblNhacungcap";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO tblNhacungcap (sTenNhacungcap, sSodienthoai, sDiachi, sEmail) VALUES (@TenNhacungcap, @Sodienthoai, @Diachi, @Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenNhacungcap", textBox2.Text);
                command.Parameters.AddWithValue("@Sodienthoai", textBox3.Text);
                command.Parameters.AddWithValue("@Diachi", textBox4.Text);
                command.Parameters.AddWithValue("@Email", textBox5.Text);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm mới nhà cung cấp thành công");
                    ClearTextBoxes();
                    BindData();
                }
                else
                {
                    MessageBox.Show("Thêm mới nhà cung cấp không thành công");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE tblNhacungcap SET sTenNhacungcap = @TenNhacungcap, sSodienthoai = @Sodienthoai, sDiachi = @Diachi, sEmail = @Email WHERE PK_INhacungcapID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", textBox1.Text);
                command.Parameters.AddWithValue("@TenNhacungcap", textBox2.Text);
                command.Parameters.AddWithValue("@Sodienthoai", textBox3.Text);
                command.Parameters.AddWithValue("@Diachi", textBox4.Text);
                command.Parameters.AddWithValue("@Email", textBox5.Text);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công");
                    ClearTextBoxes();
                    BindData();
                }
                else
                {
                    MessageBox.Show("Không có bản ghi nào được cập nhật");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int recordID = int.Parse(textBox1.Text);
                    DeleteRecord(recordID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa bản ghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteRecord(int recordID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM tblNhacungcap WHERE PK_INhacungcapID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", recordID);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa nhà cung cấp thành công");
                    BindData();
                }
                else
                {
                    MessageBox.Show("Không có bản ghi nào được xóa");
                }
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["PK_INhacungcapID"].Value.ToString();
                textBox2.Text = row.Cells["sTenNhacungcap"].Value.ToString();
                textBox3.Text = row.Cells["sSodienthoai"].Value.ToString();
                textBox4.Text = row.Cells["sDiachi"].Value.ToString();
                textBox5.Text = row.Cells["sEmail"].Value.ToString();
            }
        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
