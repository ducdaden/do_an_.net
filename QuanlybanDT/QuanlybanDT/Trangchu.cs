using QuanlybanDT.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlybanDT
{
    public partial class Trangchu : Form
    {
        public Trangchu()
        {
            InitializeComponent();
        }
        SqlConnection Con;
        private void Trangchu_Load(object sender, EventArgs e)
        {
            Class.Function.Connect(); //Mở kết nối
            TongQuan tq = new TongQuan();
            tq.MdiParent = this;
            tq.Show();

        }

        
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            
            Application.Exit(); //Thoát
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frm = new frmHoaDonBan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MdiParent = this;
            nv.Show();
        }

        private void mnuKhachhang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void mnuHang_Click(object sender, EventArgs e)
        {
            frmHang fh = new frmHang();
            fh.MdiParent = this;
            fh.Show();
        }

        private void mnuDienThoai_Click(object sender, EventArgs e)
        {
            DienThoai dt = new DienThoai();
            dt.MdiParent = this;
            dt.Show();
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            Thongke tk = new Thongke();
            tk.MdiParent = this;
            tk.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void thToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tổngQuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TongQuan tq = new TongQuan();
            tq.MdiParent = this;
            tq.Show();
        }

        private void doanhThuSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoanhThuSp dtsp = new DoanhThuSp();
            dtsp.MdiParent = this;
            dtsp.Show();
        }

        private void thốngKêCửaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhThuTK dt = new DanhThuTK();
            dt.MdiParent = this;
            dt.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.Show();
        }
    }
}
