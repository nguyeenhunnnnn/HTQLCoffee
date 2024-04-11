using HTQLCoffee.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Size = new Size(1200, 680);
        }

        private void menuNguyenLieu_Click(object sender, EventArgs e)
        {
            FormNguyenLieu customer = new FormNguyenLieu();
            customer.MdiParent = this;
            customer.Dock = DockStyle.Fill;
            customer.Show();
        }

        private void HDNhapMenu_Click(object sender, EventArgs e)
        {
            frmHDNhap frmHD = new frmHDNhap();
            frmHD.MdiParent = this;
            frmHD.Dock = DockStyle.Fill;
            frmHD.Show();
        }

        private void nccMenu_Click(object sender, EventArgs e)
        {
            frmNCC customer = new frmNCC();
            customer.MdiParent = this;
            customer.Dock = DockStyle.Fill;
            customer.Show();
        }

        private void doUongMenu_Click(object sender, EventArgs e)
        {
            frmDoUong customer = new frmDoUong();
            customer.MdiParent = this;
            customer.Dock = DockStyle.Fill;
            customer.Show();
        }

        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien customer = new FormNhanVien();
            customer.MdiParent = this;
            customer.Dock = DockStyle.Fill;
            customer.Show();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaiKhoanView account = new TaiKhoanView();
            account.MdiParent = this;
            account.Dock = DockStyle.Fill;
            account.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassView pass = new ChangePassView();
            pass.MdiParent = this;
            pass.Dock = DockStyle.Fill;
            pass.Show();
        }
        private void HDBanMenu_Click(object sender, EventArgs e)
        {
            frmHDBan frmHD = new frmHDBan();
            frmHD.MdiParent = this;
            frmHD.Dock = DockStyle.Fill;
            frmHD.Show();
        }
    }
}
