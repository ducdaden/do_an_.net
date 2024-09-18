using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanlybanDT.Class; 
namespace QuanlybanDT
{
    public partial class frmHang : Form
    {
        DataTable tblCL; 
        public frmHang()
        {
            InitializeComponent();
        }

        private void Hang_Load(object sender, EventArgs e)
        {
            
            LoadDataGridView(); 
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaHang, TenHang FROM Hang";
            tblCL = Class.Function.GetDataToTable(sql); 
            dgvHang.DataSource = tblCL;
            dgvHang.Columns[0].HeaderText = "Mã Hãng";
            dgvHang.Columns[1].HeaderText = "Tên Hãng";
            dgvHang.Columns[0].Width = 250;
            dgvHang.Columns[1].Width = 600;
            dgvHang.AllowUserToAddRows = false; 
            dgvHang.EditMode = DataGridViewEditMode.EditProgrammatically; 
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(); 

            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Function.Con; 
            dap.SelectCommand.CommandText = sql; 
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCL.Rows.Count == 0) 
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
            string sql; 
            if (txtMaHang.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0) 
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
            Class.Function.RunSQL(sql); 
            LoadDataGridView(); 
            ResetValue();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; 
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "") 
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0) 
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
            if (txtMaHang.Text == "") 
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
