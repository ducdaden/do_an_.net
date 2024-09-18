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
using QuanlybanDT.Class;
namespace QuanlybanDT
{
    public partial class TongQuan : Form
    {
        public TongQuan()
        {
            InitializeComponent();
        }
        SqlConnection Con;
        private void TongQuan_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label1.Text = "Sản phẩm bán chạy tháng: " + dt.ToString("MM-yyyy");
            double tt = Convert.ToDouble(dt.ToString("MM")) - 1;
            double nt;
            if (Convert.ToDouble(dt.ToString("MM")) == 1)
            {
                nt = Convert.ToDouble(dt.ToString("yyyy")) - 1;
                tt = 12;
            }
            else
            {
                nt = Convert.ToDouble(dt.ToString("yyyy"));
            }
            label2.Text = "Sản phẩm bán chạy tháng: 0" + tt + "-" + nt;
            DoanhThu();
            DoanhThu2();

            //load doanh thu len label
            double t = Convert.ToDouble(Function.GetFieldValues("SELECT SUM(TongTien) From HDBan"));
            string tt1 = string.Format("{0:#,##0}", t);

            label8.Text = tt1 + " VNĐ";
            double c = Convert.ToDouble(Function.GetFieldValues("SELECT SUM(SoLuong) From ChiTietHDBan"));
            label9.Text =  c.ToString();
            double hd = Convert.ToDouble(Function.GetFieldValues("SELECT COUNT(MaHDBan) From HDBan"));
            label7.Text = hd.ToString();
        }
        private void DoanhThu()
        {
            DateTime dt1 = DateTime.Now;
            SqlConnection con = new SqlConnection(Function.conString);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT Top 5 TenDienThoai,Sum(ChiTietHDBan.SoLuong) AS SL FRom ChiTietHDBan, HDBan, DienThoai Where MONTH(HDBan.NgayBan) = '" + Convert.ToDouble(dt1.ToString("MM")) + "' AND   ChiTietHDBan.MaHDBan = HDBan.MaHDBan AND ChiTietHDBan.MaDienThoai = DienThoai.MaDienThoai group by TenDienThoai ORDER BY SL DESC ", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;

            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";

            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart1.Series["Series1"].XValueMember = "TenDienThoai";
            chart1.Series["Series1"].YValueMembers = "SL";




            /*//load doanh thu len label
            double t = Convert.ToDouble(Function.GetFieldValues("SELECT SUM(TongTien) From HDBan"));
            string tt = string.Format("{0:#,##0}", t);

            label1.Text = "Số tiền thu về:" + tt + " VNĐ";
            double c = Convert.ToDouble(Function.GetFieldValues("SELECT SUM(SoLuong) From ChiTietHDBan"));
            label2.Text = "Số điện thoại đã bán ra:" + c;*/
        }

        private void DoanhThu2()
        {
            DateTime dt1 = DateTime.Now;
            Double t1 = Convert.ToDouble(dt1.ToString("MM")) - 1;

            SqlConnection con = new SqlConnection(Function.conString);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT Top 5 TenDienThoai,Sum(ChiTietHDBan.SoLuong) AS SL FRom ChiTietHDBan, HDBan, DienThoai Where MONTH(HDBan.NgayBan) = '" + t1 + "' AND   ChiTietHDBan.MaHDBan = HDBan.MaHDBan AND ChiTietHDBan.MaDienThoai = DienThoai.MaDienThoai group by TenDienThoai ORDER BY SL DESC ", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart2.DataSource = dt;

            chart2.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";

            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart2.Series["Series1"].XValueMember = "TenDienThoai";
            chart2.Series["Series1"].YValueMembers = "SL";

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
