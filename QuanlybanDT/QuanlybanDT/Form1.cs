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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        public Boolean CheckLogin = false;
        public  static string taikhoan="";
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string conString = @"Data Source=LAPTOP-GEQFS79D;Initial Catalog=QuanLybanDT;Integrated Security=True";
            con = new SqlConnection(conString);
            con.Open();
            string sqllogin = "SELECT COUNT (*) FROM NguoiDung WHERE TaiKhoan='" + textBox1.Text + "' and MatKhau='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(sqllogin, con);
            string Kiemtra = cmd.ExecuteScalar().ToString();
            con.Close();
            if (Kiemtra == "1")
            {
                
                Trangchu tc = new Trangchu();
                this.Visible = false;
                tc.Show();
                MessageBox.Show("Đăng nhập thành công");
                CheckLogin = true;
                taikhoan = textBox1.Text;

            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            label3.Parent = panel2;
            label3.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dangky dk = new Dangky();
            dk.Show();
        }
    }
}
