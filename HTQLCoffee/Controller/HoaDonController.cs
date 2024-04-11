using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Controller
{
    internal class HoaDonController
    {
        private readonly string _connectionString;
        public HoaDonController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void ThemMoiHoaDon(HoaDonChung phieuNhap, DataTable chitietPhieunhapDetails)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_InsertHoadon", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        // Thêm các tham số cho stored procedure
                        command.Parameters.AddWithValue("@PK_iNhanvienID", phieuNhap.NhanvienID);
                        command.Parameters.AddWithValue("@dNgaylap", phieuNhap.Ngaylap);
                        SqlParameter parameter = command.Parameters.AddWithValue("@ChitietHoadonDetails", chitietPhieunhapDetails);
                        parameter.SqlDbType = SqlDbType.Structured; // Đặt kiểu dữ liệu của tham số là kiểu bảng
                        // Thực thi stored procedure
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }
        public List<HoaDon> LayDanhSachHoaDon()
        {
            List<HoaDon> danhSachHoaDon = new List<HoaDon>();

            string query = @"
                SELECT PN.PK_iHoadonID,  NV.sTenNhanVien, PN.dNgaylap, PN.fTongtien 
                FROM tblHoadon PN 
                INNER JOIN tblNhanvien NV ON PN.PK_iNhanvienID = NV.PK_iNhanvienID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            HoaDon phieuNhap = new HoaDon
                            {
                                PhieuNhapID = Convert.ToInt32(reader["PK_iHoadonID"]),
                                TenNhanVien = reader["sTenNhanVien"].ToString(),
                                NgayLap = Convert.ToDateTime(reader["dNgaylap"]),
                                TongTien = Convert.ToSingle(reader["fTongtien"])
                            };

                            danhSachHoaDon.Add(phieuNhap);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return danhSachHoaDon;
        }
        public List<HoaDon> TimKiemPhieuNhap(int nhanVienID, string ngayLap)
        {
            List<HoaDon> ketQuaTimKiem = new List<HoaDon>();
            string query = @"
                SELECT PN.PK_iHoadonID,  NV.sTenNhanVien, PN.dNgaylap, PN.fTongtien 
                FROM tblHoadon PN 
                INNER JOIN tblNhanvien NV ON PN.PK_iNhanvienID = NV.PK_iNhanvienID
                WHERE PN.PK_iNhanvienID = @NhanVienID Or PN.dNgaylap = @NgayLap";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                    command.Parameters.AddWithValue("@NgayLap", ngayLap);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            HoaDon hoaDon = new HoaDon
                            {
                                PhieuNhapID = Convert.ToInt32(reader["PK_iHoadonID"]),
                                TenNhanVien = reader["sTenNhanVien"].ToString(),
                                NgayLap = Convert.ToDateTime(reader["dNgaylap"]),
                                TongTien = Convert.ToSingle(reader["fTongtien"])
                            };

                            ketQuaTimKiem.Add(hoaDon);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return ketQuaTimKiem;
        }
        public List<ChiTietHoaDon> LayDanhSachChiTietPhieuBan(int phieuNhapID)
        {
            List<ChiTietHoaDon> danhSachChiTiet = new List<ChiTietHoaDon>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT  NL.sTenDouong, CT.iSoluong, CT.fDongia 
            FROM tblChitietHoadon CT
            INNER JOIN tblDouong NL ON CT.PK_iDouongID = NL.PK_iDouongID
            WHERE CT.PK_iHoadonID = @PhieuNhapID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PhieuNhapID", phieuNhapID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ChiTietHoaDon chiTiet = new ChiTietHoaDon
                        {
                            TenDoUong = reader["sTenDouong"].ToString(),
                            SoLuong = Convert.ToSingle(reader["iSoluong"]),
                            DonGia = Convert.ToSingle(reader["fDongia"])
                        };
                        danhSachChiTiet.Add(chiTiet);
                    }
                }
            }

            return danhSachChiTiet;
        }
    }
}
