using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.Model
{

     class TaiKhoanModel
    {
        string connectionString;
        public TaiKhoanModel()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;
        }

        private DataTable Get_Dulieu(string procname, string tablename)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(procname, cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable tbl = new DataTable(tablename);
            da.Fill(tbl);            
            return tbl;
        }
        public void GetTaiKhoanData(DataGridView dgv_TaiKhoan)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string storedProcedureName = "sp_get_taikhoan";
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    dgv_TaiKhoan.DataSource = dataTable;
                }
            }
        }
        private void show(string procname, string tablename, DataGridView dgv)
        {

                DataTable table = Get_Dulieu(procname, tablename);
                DataView view = new DataView(table);
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = view;
        }
      
        public void themTaiKhoan(string maNhanVien, string matKhau, string quyen, DataGridView dgv_TaiKhoan)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (SqlDataAdapter adp = new SqlDataAdapter())
                {
                    adp.SelectCommand = new SqlCommand("select * from tblTaikhoan", cnn);
                    DataTable table = new DataTable();
                    adp.Fill(table);

                    if (table != null)
                    {
                        int check = 0;
                        foreach (DataRow dr in table.Rows)
                        {
                            if (dr["PK_iNhanvienID"].ToString() == maNhanVien)
                            {
                                check++;
                            }
                        }
                        if (check != 0)
                        {
                            MessageBox.Show("Nhân Viên Đã Có Tài Khoản");
                            return;
                        }
                        else
                        {
                            string sql = "insert into tblTaikhoan (PK_iNhanvienID, sMatkhau, PK_iPhanquyenID)" +
                            "values (@id, @Matkhau,@quyen)";
                            adp.InsertCommand = new SqlCommand(sql, cnn);
                            adp.InsertCommand.Parameters.Add("@Matkhau", SqlDbType.NVarChar, 50).Value = matKhau;
                            adp.InsertCommand.Parameters.Add("@quyen", SqlDbType.Int).Value = Convert.ToInt32(quyen);
                            adp.InsertCommand.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(maNhanVien);

                            table.Rows.Add();
                            adp.Update(table);
                            table.Clear();
                            adp.Fill(table);
                            dgv_TaiKhoan.DataSource = table;
                            
                        }
                    }
                }
                MessageBox.Show("Thêm Thành Công");
            }
            show("sp_getTK", "tblTaiKhoan", dgv_TaiKhoan);
        }

        public void layDuLieu(DataGridView dgv_TaiKhoan)
        {
            DataTable table = Get_Dulieu("sp_getTK", "tblTaikhoan");
            DataView view = new DataView(table);
            dgv_TaiKhoan.AutoGenerateColumns = true;
            dgv_TaiKhoan.DataSource = view;
        }

        public void timKiem(string matKhau, string quyen, string maNhanVien, DataGridView dgv_TaiKhoan)
        {
            string dieukienLoc = "PK_iNhanvienID>0";
            if (!string.IsNullOrEmpty(matKhau))
                dieukienLoc += string.Format(" AND sMatkhau LIKE '%{0}%'", matKhau);
            if (!string.IsNullOrEmpty(quyen))
                dieukienLoc += string.Format(" AND Convert(PK_iPhanquyenID, System.String) LIKE '%{0}%'", quyen);
            if (!string.IsNullOrEmpty(maNhanVien))
                dieukienLoc += string.Format(" AND Convert(PK_iNhanvienID, System.String) LIKE '%{0}%'", maNhanVien);
            DataView dvTaiKhoan = (DataView)dgv_TaiKhoan.DataSource;
            dvTaiKhoan.RowFilter = dieukienLoc;
            dgv_TaiKhoan.DataSource = dvTaiKhoan;
        }

        public void dulieuCB(string query, string display, string value, ComboBox comboBox)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        comboBox.DisplayMember = display;
                        comboBox.ValueMember = value;
                        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        dt.Rows.Add();
                        comboBox.DataSource = dt;
                    }

                }
                cnn.Close();
            }
        }

        public void suaTaiKhoan(int maNhanVien, string matKhau, int quyen, DataGridView dgv_TaiKhoan)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_update_taikhoan";
                    cmd.Parameters.AddWithValue("@Maquyen", quyen);
                    cmd.Parameters.AddWithValue("@Matkhau", matKhau);
                    cmd.Parameters.AddWithValue("@Mataikhoan", dgv_TaiKhoan.CurrentRow.Cells["PK_iNhanvienID"].Value); // Use "PK_iNhanvienID" if it represents the primary key
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            show("sp_getTK", "tblTaiKhoan", dgv_TaiKhoan);

        }
        public void xoaTaiKhoan(int maNhanVien, DataGridView dgv_TaiKhoan)
        {
            try
            {
                if(MessageBox.Show("Bạn có chắc muốn xóa tài khoản này này???", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iNhanvien", Convert.ToInt32(dgv_TaiKhoan.CurrentRow.Cells["PK_iNhanvienID"].Value));

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                show("sp_getTK", "tblTaiKhoan", dgv_TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể xóa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
       
    }
}
