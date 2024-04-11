using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Model
{
    public class NhaCungCapModel
    {
        public int NhacungcapID { get; set; }
        public string TenNhacungcap { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
    }
    public class NhaCungCapDAO
    {
        private readonly string _connectionString;

        public NhaCungCapDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<NhaCungCapModel> LayDanhSachNhaCungCap()
        {
            List<NhaCungCapModel> danhSachNhaCungCap = new List<NhaCungCapModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tblNhacungcap";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachNhaCungCap.Add(new NhaCungCapModel
                            {
                                NhacungcapID = Convert.ToInt32(reader["PK_iNhacungcapID"]),
                                TenNhacungcap = reader["sTenNhacungcap"].ToString(),
                                SoDienThoai =reader["sSodienthoai"].ToString(),
                                DiaChi = reader["sDiachi"].ToString(),
                                Email = reader["sEmail"].ToString()
                            });
                        }
                    }
                }
            }
            return danhSachNhaCungCap;
        }
    }
}
