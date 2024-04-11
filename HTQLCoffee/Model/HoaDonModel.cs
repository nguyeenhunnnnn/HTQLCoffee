using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Model
{
    public class HoaDonChung
    {
        public int NhanvienID { get; set; }
        public DateTime Ngaylap { get; set; }
        public int DoUongID { get; set; }
        public float Soluong { get; set; }
        public float Dongia { get; set; }
    }
    public class HoaDon
    {
        public int PhieuNhapID { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgayLap { get; set; }
        public float TongTien { get; set; }
    }
    public class ChiTietHoaDon
    {
        public string TenDoUong { get; set; }
        public float SoLuong { get; set; }
        public float DonGia { get; set; }
    }
}
