using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Model
{
    public class NguyenLieuModel
    {
        public int NguyenLieuID { get; set; }
        public string TenNguyenLieu { get; set; }
        public float SoLuong { get; set; }
        public string DonViTinh { get; set; }
    }

    public class NguyenLieuDAO
    {
        private readonly string _connectionString;

        public NguyenLieuDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<NguyenLieuModel> LayDanhSachNguyenLieu()
        {
            List<NguyenLieuModel> danhSachNguyenLieu = new List<NguyenLieuModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tblNguyenlieu";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachNguyenLieu.Add(new NguyenLieuModel
                            {
                                NguyenLieuID = Convert.ToInt32(reader["PK_iNguyenlieuID"]),
                                TenNguyenLieu = reader["sTenNguyenlieu"].ToString(),
                                SoLuong = Convert.ToSingle(reader["fSoluong"]),
                                DonViTinh = reader["sDonvitinh"].ToString(),
                            });
                        }
                    }
                }
            }
            return danhSachNguyenLieu;
        }
    }
}
