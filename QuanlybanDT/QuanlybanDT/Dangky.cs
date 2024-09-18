using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using QuanlybanDT.Class; //Sử dụng class Functions.cs
namespace QuanlybanDT
{
    public partial class Dangky : Form
    {
        SqlConnection con;
        public Dangky()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = Function.conString;
            con = new SqlConnection(conString);
            con.Open();
            string sql; //Lưu lệnh sql
            if (textBox1.Text.Trim().Length == 0) //Nếu chưa nhập mã 
            {
                MessageBox.Show("Bạn phải nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            sql = "SELECT COUNT (*) FROM NguoiDung where TaiKhoan=N'" + textBox1.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            string tk = cmd.ExecuteScalar().ToString();
            if (textBox1.Text.Trim()== "1")
            {
                MessageBox.Show("Tài khoản trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            
            if (textBox3.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (textBox3.Text.Trim() != textBox2.Text.Trim())
            {
                label5.Text = "Mật khẩu không trùng";
                textBox3.Focus();
                return;
            }

            string sql1 = "INSERT INTO NguoiDung VALUES(N'" +
                textBox1.Text + "',N'" + textBox3.Text + "')";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Đăng ký thành công");
            this.Close();
        }

        private void Dangky_Load(object sender, EventArgs e)
        {
            

        }
    }
}
