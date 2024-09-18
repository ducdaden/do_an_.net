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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        SqlConnection con;
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
                MessageBox.Show("Bạn phải nhập mật khẩu hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            sql = "SELECT COUNT (*) FROM NguoiDung where TaiKhoan=N'" + textBox1.Text.Trim() + "' AND MatKhau=N'" + textBox2.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            string tk = cmd.ExecuteScalar().ToString();
            if (textBox1.Text.Trim() == "1")
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (txtMkm.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMkm.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (textBox3.Text.Trim() != txtMkm.Text.Trim())
            {
                MessageBox.Show("Mật khẩu không trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                textBox3.Focus();
                return;
            }

            string sqlInsert = "UPDATE NguoiDung SET MatKhau=@MatKhau WHERE TaiKhoan=@TaiKhoan";
            SqlCommand cmd1 = new SqlCommand(sqlInsert, con);

            cmd1.Parameters.AddWithValue("MatKhau", textBox3.Text);
            cmd1.Parameters.AddWithValue("TaiKhoan", textBox1.Text);
            
            

            
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Sửa mật khẩu thành công");
            this.Close();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            textBox1.Text = Form1.taikhoan;
            textBox1.ReadOnly = true;
        }
    }
}
