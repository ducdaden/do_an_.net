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
    public partial class DoanhThuSp : Form
    {
        public DoanhThuSp()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void DoanhThuSp_Load(object sender, EventArgs e)
        {
            DoanhThu2();
            Function.FillCombo("SELECT MaDienThoai,TenDienThoai FROM DienThoai", cboDienThoai, "MaDienThoai", "TenDienThoai");
            cboDienThoai.SelectedIndex = -1;
        }
        private void DoanhThu()
        {
            if (cboThangDau.Text != "" || cboThangCuoi.Text != "" || cboNamDau.Text != "" || cboNamCuoi.Text != "" || cboDienThoai.Text!="" )
            {
                SqlConnection con = new SqlConnection(Function.conString);
                SqlDataAdapter ad = new SqlDataAdapter("SELECT MONTH(HDBan.NgayBan) AS Thang,sum(ChiTietHDBan.ThanhTien) AS TT FRom ChiTietHDBan, HDBan, DienThoai Where MONTH(HDBan.NgayBan) >='" + cboThangDau.Text + "' AND YEAR(HDBan.NgayBan)>='" + cboNamDau.Text + "' AND MONTH(HDBan.NgayBan) <='" + cboThangCuoi.Text + "'AND YEAR(HDBan.NgayBan)<='" + cboNamCuoi.Text + "'AND ChiTietHDBan.MaHDBan = HDBan.MaHDBan AND ChiTietHDBan.MaDienThoai = DienThoai.MaDienThoai AND TenDienThoai='"+cboDienThoai.Text+ "' group by MONTH(HDBan.NgayBan)", con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                chart1.DataSource = dt;

                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                chart1.Series["Series1"].XValueMember = "Thang";
                chart1.Series["Series1"].YValueMembers = "TT";
                chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;



            }
            else
            {
                MessageBox.Show("Bạn vui lòng chọn đủ thông tin "); 
            }

            
        }


        private void DoanhThu2()
        {
            
                SqlConnection con = new SqlConnection(Function.conString);
                SqlDataAdapter ad = new SqlDataAdapter("SELECT MaHang,sum(ChiTietHDBan.ThanhTien) AS TT FRom ChiTietHDBan, DienThoai Where ChiTietHDBan.MaDienThoai=DienThoai.MaDienThoai Group by MaHang", con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                chart1.DataSource = dt;

                
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                chart1.Series["Series1"].XValueMember = "MaHang";
                chart1.Series["Series1"].YValueMembers = "TT";
                chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;



           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoanhThu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoanhThu2();
        }
    }
}
