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
    public partial class DanhThuTK : Form
    {
        public DanhThuTK()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void DanhThuTK_Load(object sender, EventArgs e)
        {
            DoanhThu();

        }
        private void DoanhThu()
        {
            SqlConnection con = new SqlConnection(Function.conString);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT MaDienThoai,Sum(SoLuong) AS SL,sum(ThanhTien) AS TT FRom ChiTietHDBan group by MaDienThoai", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;
            
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
            
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY2.MajorGrid.Enabled=false;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart1.Series["Số điện thoại bán"].XValueMember = "MaDienThoai";
            chart1.Series["Số điện thoại bán"].YValueMembers = "SL";
            

            chart1.Series["Doanh Thu"].XValueMember = "MaDienThoai";
            chart1.Series["Doanh Thu"].YValueMembers = "TT";
            chart1.Series["Doanh Thu"].MarkerSize = 5;
            
            chart1.Series["Doanh Thu"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;

            //load doanh thu len label
            double t = Convert.ToDouble(Function.GetFieldValues("SELECT SUM(TongTien) From HDBan"));
            string tt = string.Format("{0:#,##0}", t);

            label1.Text = "Số tiền thu về:" + tt + " VNĐ";
            double c = Convert.ToDouble(Function.GetFieldValues("SELECT SUM(SoLuong) From ChiTietHDBan"));
            label2.Text = "Số điện thoại đã bán ra:" + c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoanhThu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Function.conString);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT TenDienThoai,Sum(ChiTietHDBan.SoLuong) AS SL,sum(ChiTietHDBan.ThanhTien) AS TT FRom ChiTietHDBan, HDBan, DienThoai Where HDBan.NgayBan >='"+dateTimePicker1.Value+"' AND HDBan.NgayBan<='"+dateTimePicker2.Value+"' AND ChiTietHDBan.MaHDBan = HDBan.MaHDBan AND ChiTietHDBan.MaDienThoai = DienThoai.MaDienThoai group by TenDienThoai", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;

            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart1.Series["Số điện thoại bán"].XValueMember = "TenDienThoai";
            chart1.Series["Số điện thoại bán"].YValueMembers = "SL";


            chart1.Series["Doanh Thu"].XValueMember = "TenDienThoai";
            chart1.Series["Doanh Thu"].YValueMembers = "TT";

            //load doanh thu len label
            string t = Function.GetFieldValues("SELECT SUM(TongTien) From HDBan where HDBan.NgayBan<='"+dateTimePicker2.Value+"' AND HDBan.NgayBan>='"+dateTimePicker1.Value+"'");
            double t1;
                bool t2= Double.TryParse(t,out t1);
            string tt = string.Format("{0:#,##0}", t1);
            
            label1.Text = "Số tiền thu về:" + tt + " VNĐ";
            string s = Function.GetFieldValues("SELECT SUM(SoLuong) From ChiTietHDBan,HDBan Where HDBan.NgayBan >='" + dateTimePicker1.Value + "' AND HDBan.NgayBan<='" + dateTimePicker2.Value + "' AND ChiTietHDBan.MaHDBan=HDBan.MaHDBan");
            
            label2.Text = "Số điện thoại đã bán ra:" + s;
        }
    }
}
