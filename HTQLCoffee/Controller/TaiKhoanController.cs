using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.Controller
{
    internal class TaiKhoanController
    {
        private TaiKhoanModel taiKhoanModel;
        public TaiKhoanController()
        {
            this.taiKhoanModel = new TaiKhoanModel();
        }

        public void ThemTaiKhoanController(string maNhanVien, string matKhau, string quyen, DataGridView dgv_TaiKhoan)
        {
            this.taiKhoanModel.themTaiKhoan(maNhanVien, matKhau, quyen, dgv_TaiKhoan);
        }

        public void dulieuCBController(string query, string display, string value, ComboBox comboBox)
        {
            this.taiKhoanModel.dulieuCB(query, display, value, comboBox);
        }

        public void layDuLieuController(DataGridView dgv_TaiKhoan)
        {
            this.taiKhoanModel.layDuLieu(dgv_TaiKhoan);
        }
        public void GetTaiKhoanData(DataGridView dgv_TaiKhoan)
        {
            taiKhoanModel.GetTaiKhoanData(dgv_TaiKhoan);
        }

        public void timKiemController(string matKhau, string maNhanVien, string quyen, DataGridView dgv_TaiKhoan)
        {
            this.taiKhoanModel.timKiem(matKhau, maNhanVien, quyen, dgv_TaiKhoan);
        }

        public void suaTaiKhoanController(int maNhanVien, string matKhau, int quyen, DataGridView dgv_TaiKhoan)
        {
            this.taiKhoanModel.suaTaiKhoan(maNhanVien, matKhau, quyen, dgv_TaiKhoan);
        }
        public void xoaController(int maNhanVien, DataGridView dgv_TaiKhoan)
        {
            this.taiKhoanModel.xoaTaiKhoan(maNhanVien, dgv_TaiKhoan);
        }

    }

}
