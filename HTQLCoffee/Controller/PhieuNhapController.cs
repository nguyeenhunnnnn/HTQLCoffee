using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.Controller
{
    internal class PhieuNhapController
    {
        private readonly string _connectionString;
        public PhieuNhapController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void ThemMoiPhieuNhap(PhieuNhapChung phieuNhap, DataTable chitietPhieunhapDetails)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_InsertPhieuNhap", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        // Thêm các tham số cho stored procedure
                        command.Parameters.AddWithValue("@iNhanvienID", phieuNhap.NhanvienID);
                        command.Parameters.AddWithValue("@iNhacungcapID", phieuNhap.NhacungcapID);
                        command.Parameters.AddWithValue("@dNgaylap", phieuNhap.Ngaylap);
                        SqlParameter parameter = command.Parameters.AddWithValue("@ChitietPhieunhapDetails", chitietPhieunhapDetails);
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
        public List<PhieuNhap> LayDanhSachPhieuNhap()
        {
            List<PhieuNhap> danhSachPhieuNhap = new List<PhieuNhap>();

            string query = @"
                SELECT PN.PK_iPhieunhapID,  NV.sTenNhanVien, NC.sTenNhacungcap, PN.dNgaylap, PN.fTongtien 
                FROM tblPhieunhap PN 
                INNER JOIN tblNhanvien NV ON PN.PK_iNhanvienID = NV.PK_iNhanvienID
                INNER JOIN tblNhacungcap NC ON PN.PK_iNhacungcapID = NC.PK_iNhacungcapID";


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
                            PhieuNhap phieuNhap = new PhieuNhap
                            {
                                PhieuNhapID = Convert.ToInt32(reader["PK_iPhieunhapID"]),
                                TenNhanVien = reader["sTenNhanVien"].ToString(),
                                TenNhaCungCap = reader["sTenNhacungcap"].ToString(),
                                NgayLap = Convert.ToDateTime(reader["dNgaylap"]),
                                TongTien = Convert.ToSingle(reader["fTongtien"])
                            };

                            danhSachPhieuNhap.Add(phieuNhap);
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

            return danhSachPhieuNhap;
        }
        public List<PhieuNhap> TimKiemPhieuNhap(int nhanVienID, string ngayLap)
        {
            List<PhieuNhap> ketQuaTimKiem = new List<PhieuNhap>();
            string query = @"
                SELECT PN.PK_iPhieunhapID, PN.PK_iNhanvienID, NV.sTenNhanVien, PN.PK_iNhacungcapID, NC.sTenNhacungcap, PN.dNgaylap, PN.fTongtien 
                FROM tblPhieunhap PN 
                INNER JOIN tblNhanvien NV ON PN.PK_iNhanvienID = NV.PK_iNhanvienID
                INNER JOIN tblNhacungcap NC ON PN.PK_iNhacungcapID = NC.PK_iNhacungcapID
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
                            PhieuNhap phieuNhap = new PhieuNhap
                            {
                                PhieuNhapID = Convert.ToInt32(reader["PK_iPhieunhapID"]),
                                TenNhanVien = reader["sTenNhanVien"].ToString(),
                                TenNhaCungCap = reader["sTenNhacungcap"].ToString(),
                                NgayLap = Convert.ToDateTime(reader["dNgaylap"]),
                                TongTien = Convert.ToSingle(reader["fTongtien"])
                            };

                            ketQuaTimKiem.Add(phieuNhap);
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
        public List<ChiTietPhieuNhap> LayDanhSachChiTietPhieuNhap(int phieuNhapID)
        {
            List<ChiTietPhieuNhap> danhSachChiTiet = new List<ChiTietPhieuNhap>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT  NL.sTenNguyenlieu, CT.fSoluong, CT.fDongia 
            FROM tblChitietPhieunhap CT
            INNER JOIN tblNguyenlieu NL ON CT.PK_iNguyenlieuID = NL.PK_iNguyenlieuID
            WHERE CT.PK_iPhieunhapID = @PhieuNhapID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PhieuNhapID", phieuNhapID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ChiTietPhieuNhap chiTiet = new ChiTietPhieuNhap
                        {
                            TenNguyenLieu = reader["sTenNguyenlieu"].ToString(),
                            SoLuong = Convert.ToSingle(reader["fSoluong"]),
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
