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

namespace QLSinhViennhom5
{
    public partial class cn_chinhsach : Form
    {
        Database db = new Database();
        private const string connectionString = ""; 
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        public cn_chinhsach()
        {
            InitializeComponent();
            this.ActiveControl = txtma;
            
            connection = new SqlConnection(db.ConnectionString);
            LoadData();
            dgv.Columns["macs"].HeaderText = "Mã chính sách";
            dgv.Columns["tencs"].HeaderText = "Tên chính sách";
            dgv.Columns["chedo"].HeaderText = "Chế độ";
            dgv.Columns["macs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tencs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["chedo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["macs"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tencs"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["chedo"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            dgv.Columns["macs"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tencs"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["chedo"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);

           

        }
        private void LoadData()
        {
       
            string query = "SELECT * FROM chinhsach";
            using (adapter = new SqlDataAdapter(query, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void ClearTextBoxes()
        {
            
            txtma.Text = string.Empty;
            txtten.Text = string.Empty;
            txtchedo.Text = string.Empty;
        }
        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtma.Text))
            {
                MessageBox.Show("Vui lòng nhập mã chính sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtten.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chính sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtchedo.Text))
            {
                MessageBox.Show("Vui lòng nhập chế độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtchedo.Text.Length > 10)
            {
                MessageBox.Show("Chế độ không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Kiểm tra xem mã đã tồn tại chưa
            string checkExistQuery = "SELECT COUNT(*) FROM chinhsach WHERE macs = @macs";
            using (SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, connection))
            {
                checkExistCommand.Parameters.AddWithValue("@macs", txtma.Text);

                connection.Open();
                int count = Convert.ToInt32(checkExistCommand.ExecuteScalar());
                connection.Close();

                if (count > 0)
                {
                    MessageBox.Show("Mã chính sách đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!IsValidInput())
            {
                return;
            }

            
            string query = "INSERT INTO chinhsach (macs, tencs, chedo) VALUES (@macs, @tencs, @chedo)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@macs", txtma.Text);
                command.Parameters.AddWithValue("@tencs", txtten.Text);
                command.Parameters.AddWithValue("@chedo", txtchedo.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            ClearTextBoxes();
            LoadData();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtma.Text)){
                MessageBox.Show("Vui lòng nhập mã chính sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            if(string.IsNullOrWhiteSpace(txtten.Text) )
            {
                MessageBox.Show("Vui lòng nhập tên chính sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }
            if (string.IsNullOrWhiteSpace(txtchedo.Text))
            {
                MessageBox.Show("Vui lòng nhập chế độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtchedo.Text.Length > 10)
            {
                MessageBox.Show("Chế độ không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            string macs = txtma.Text;

            string query = "UPDATE chinhsach SET tencs = @tencs, chedo = @chedo WHERE macs = @macs";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@macs", macs);
                command.Parameters.AddWithValue("@tencs", txtten.Text);
                command.Parameters.AddWithValue("@chedo", txtchedo.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            ClearTextBoxes();
            LoadData();
            MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtma.Text))
            {
                MessageBox.Show("Vui lòng nhập mã chính sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                
            string macs = txtma.Text;

            string query = "DELETE FROM chinhsach WHERE macs = @macs";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@macs", macs);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            ClearTextBoxes();
            LoadData();
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Close();

            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            if (selectedRowIndex >= 0)
            {
                txtma.Text = dgv.Rows[selectedRowIndex].Cells["macs"].Value.ToString();
                txtten.Text = dgv.Rows[selectedRowIndex].Cells["tencs"].Value.ToString();
                txtchedo.Text = dgv.Rows[selectedRowIndex].Cells["chedo"].Value.ToString();
            }
        }

        private void cn_chinhsach_Load(object sender, EventArgs e)
        {
            txtma.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
