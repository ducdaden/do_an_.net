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
    public partial class frmHang : Form
    {
        DataTable tblCL; //Chứa dữ liệu bảng Chất liệu
        public frmHang()
        {
            InitializeComponent();
        }

        private void Hang_Load(object sender, EventArgs e)
        {
            
            LoadDataGridView(); //Hiển thị bảng tblChatLieu
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaHang, TenHang FROM Hang";
            tblCL = Class.Function.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvHang.DataSource = tblCL;
            dgvHang.Columns[0].HeaderText = "Mã Hãng";
            dgvHang.Columns[1].HeaderText = "Tên Hãng";
            dgvHang.Columns[0].Width = 250;
            dgvHang.Columns[1].Width = 600;
            dgvHang.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvHang.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Function.Con; //Kết nối cơ sở dữ liệu
            dap.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCL.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHang.Text = dgvHang.CurrentRow.Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dgvHang.CurrentRow.Cells["TenHang"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            
        }
        private void ResetValue()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaHang.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            sql = "Select MaHang From Hang where MaHang=N'" + txtMaHang.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }

            sql = "INSERT INTO Hang VALUES(N'" +
                txtMaHang.Text + "',N'" + txtTenHang.Text + "')";
            Class.Function.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE Hang SET TenHang=N'" +
                txtTenHang.Text.ToString() +
                "' WHERE MaHang=N'" + txtMaHang.Text + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Hang WHERE MaHang=N'" + txtMaHang.Text + "'";
                Class.Function.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void cboNhanVien_DropDown(object sender, EventArgs e)
        {
            Function.FillCombo("SELECT MaHang FROM Hang", cboHang, "MaHang", "MaHang");
            cboHang.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetValue();
            if (cboHang.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã Hãng để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboHang.Focus();
                return;
            }
            txtMaHang.Text = cboHang.Text;

            LoadInfoHang();
            LoadDataGridView();

            cboHang.SelectedIndex = -1;
        }
        private void LoadInfoHang()
        {
            string str;
            str = "SELECT TenHang FROM Hang WHERE MaHang= N'" + txtMaHang.Text + "'";
            txtTenHang.Text = Function.GetFieldValues(str);
            
            
        }

        private void dgvHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
