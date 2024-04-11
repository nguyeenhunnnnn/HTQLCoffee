using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTQLCoffee.View
{
    public partial class frmDoUong : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;

        public frmDoUong()
        {
            InitializeComponent();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        void BindData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM tblDouong", con);
                    SqlDataAdapter sd = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["PK_IDoUongID"].Value.ToString();
                textBox2.Text = row.Cells["sTenDoUong"].Value.ToString();
                textBox3.Text = row.Cells["fDonGia"].Value.ToString();
            }
        }

        private void frmDoUong_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO tblDouong (sTenDoUong, fDonGia) VALUES (@TenDoUong, @DonGia)";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@TenDoUong", textBox2.Text);
                    command.Parameters.AddWithValue("@DonGia", textBox3.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm mới đồ uống thành công");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới đồ uống không thành công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm mới đồ uống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            BindData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE tblDouong SET sTenDoUong = @TenDoUong, fDonGia = @DonGia WHERE PK_IDoUongID = @ID";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@TenDoUong", textBox2.Text);
                    command.Parameters.AddWithValue("@DonGia", textBox3.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật đồ uống thành công");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào được cập nhật");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật đồ uống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            BindData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int recordID = int.Parse(textBox1.Text);
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM tblDouong WHERE PK_IDoUongID = @ID";
                        SqlCommand command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@ID", recordID);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa đồ uống thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không có bản ghi nào được xóa");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa bản ghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                BindData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
