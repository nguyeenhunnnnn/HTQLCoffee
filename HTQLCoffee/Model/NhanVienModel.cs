using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Model
{
    public class NhanVienModel
    {
        public int NhanVienID { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
    }
    public class NhanVienDAO
    {
        private readonly string _connectionString;

        public NhanVienDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<NhanVienModel> LayDanhSachNhanVien()
        {
            List<NhanVienModel> danhSachNhanVien = new List<NhanVienModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tblNhanvien";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachNhanVien.Add(new NhanVienModel
                            {
                                NhanVienID = Convert.ToInt32(reader["PK_iNhanvienID"]),
                                TenNhanVien = reader["sTenNhanvien"].ToString(),
                                SoDienThoai =reader["sSodienthoai"].ToString(),
                                DiaChi = reader["sDiachi"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["dNgaysinh"]),
                                GioiTinh = Convert.ToBoolean(reader["bGioitinh"])
                            });
                        }
                    }
                }
            }
            return danhSachNhanVien;
        }
    }
}
