using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Model
{
    public class PhieuNhapChung
    {
        public int NhanvienID { get; set; }
        public int NhacungcapID { get; set; }
        public DateTime Ngaylap { get; set; }
        public int NguyenlieuID { get; set; }
        public float Soluong { get; set; }
        public float Dongia { get; set; }
    }
    public class PhieuNhap
    {
        public int PhieuNhapID { get; set; }
        public string TenNhanVien { get; set; }
        public string TenNhaCungCap { get; set; }
        public DateTime NgayLap { get; set; }
        public float TongTien { get; set; }
    }
    public class ChiTietPhieuNhap
    {
        public string TenNguyenLieu { get; set; }
        public float SoLuong { get; set; }
        public float DonGia { get; set; }
    }

}
