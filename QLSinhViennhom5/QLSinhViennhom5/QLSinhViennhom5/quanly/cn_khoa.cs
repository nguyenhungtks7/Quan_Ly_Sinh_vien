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
    public partial class cn_khoa : Form
    {
        private const string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        public cn_khoa()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            LoadData();
            dgv.Columns["makhoa"].HeaderText = "Mã khoa";
            dgv.Columns["tenkhoa"].HeaderText = "Tên khoa";

            dgv.Columns["makhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenkhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgv.Columns["makhoa"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenkhoa"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            

            dgv.Columns["makhoa"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenkhoa"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
         
        }
        private void LoadData()
        {
            
            string query = "SELECT * FROM khoa";
            using (adapter = new SqlDataAdapter(query, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void ClearTextBoxes()
        {
            txtmakhoa.Text = string.Empty;
            txttenkhoa.Text = string.Empty;
        }
        private bool IsMaKhoaExists(string makhoa)
        {
            string query = "SELECT COUNT(*) FROM khoa WHERE makhoa = @makhoa";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@makhoa", makhoa);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return count > 0;
            }
        }

      
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmakhoa.Text) )
            {
                MessageBox.Show("Vui lòng nhập mã khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmakhoa.Text.Length > 10)
            {
                MessageBox.Show("Mã khoa không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsMaKhoaExists(txtmakhoa.Text))
            {
                MessageBox.Show("Mã khoa đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txttenkhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (txttenkhoa.Text.Length > 50)
            {
                MessageBox.Show("Tên khoa không được quá 50 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO khoa (makhoa, tenkhoa) VALUES (@makhoa, @tenkhoa)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@makhoa", txtmakhoa.Text);
                command.Parameters.AddWithValue("@tenkhoa", txttenkhoa.Text);

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
            if (string.IsNullOrWhiteSpace(txtmakhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmakhoa.Text.Length > 10)
            {
                MessageBox.Show("Mã khoa không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txttenkhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (txttenkhoa.Text.Length > 50)
            {
                MessageBox.Show("Tên khoa không được quá 50 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
            string makhoa = txtmakhoa.Text;

            string query = "UPDATE khoa SET tenkhoa = @tenkhoa WHERE makhoa = @makhoa";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@makhoa", makhoa);
                command.Parameters.AddWithValue("@tenkhoa", txttenkhoa.Text);

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
            if (string.IsNullOrWhiteSpace(txtmakhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khoa cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               
                string makhoa = txtmakhoa.Text;

                string query = "DELETE FROM khoa WHERE makhoa = @makhoa";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@makhoa", makhoa);

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
                txtmakhoa.Text = dgv.Rows[selectedRowIndex].Cells["makhoa"].Value.ToString();
                txttenkhoa.Text = dgv.Rows[selectedRowIndex].Cells["tenkhoa"].Value.ToString();
            }
        }

        private void cn_khoa_Load(object sender, EventArgs e)
        {
            txtmakhoa.Focus();
        }
    }
}
