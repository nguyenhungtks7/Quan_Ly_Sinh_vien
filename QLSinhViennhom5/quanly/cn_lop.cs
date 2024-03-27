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
    public partial class cn_lop : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        Database db = new Database();
        public cn_lop()
        {
            InitializeComponent();
            connection = new SqlConnection(db.ConnectionString);
            LoadData();
            LoadComboBoxData();
            dgv.Columns["malop"].HeaderText = "Mã Lớp";
            dgv.Columns["tenlop"].HeaderText = "Tên Lớp";
            dgv.Columns["makhoa"].HeaderText = "Tên khoa";

            dgv.Columns["makhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenlop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["malop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["makhoa"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenlop"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["malop"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);


            dgv.Columns["makhoa"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenlop"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["malop"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
        }
        private void LoadData()
        {
            
            string query = "SELECT * FROM lop";
            using (adapter = new SqlDataAdapter(query, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }

        private void LoadComboBoxData()
        {
            string query = "SELECT makhoa, tenkhoa FROM khoa";
            using (adapter = new SqlDataAdapter(query, connection))
            {
                DataTable khoaTable = new DataTable();
                adapter.Fill(khoaTable);

                cbmakhoa.DataSource = khoaTable;
                cbmakhoa.DisplayMember = "makhoa";
                cbmakhoa.ValueMember = "makhoa";
            }
        }
        private void ClearTextBoxes()
        {
            txtmalop.Text = string.Empty;
            txttenlop.Text = string.Empty;
        }
        private bool IsMaLopExists(string malop)
        {
            string query = "SELECT COUNT(*) FROM lop WHERE malop = @malop";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@malop", malop);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return count > 0;
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmalop.Text) )
            {
                MessageBox.Show("Vui lòng nhập mã lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsMaLopExists(txtmalop.Text))
            {
                MessageBox.Show("Mã lớp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txttenlop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmalop.Text.Length > 10)
            {
                MessageBox.Show("Mã lớp không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txttenlop.Text.Length > 50)
            {
                MessageBox.Show("Tên lớp không được quá 50 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(cbmakhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã khoa hoặc mã khoa không tồn tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            string query = "INSERT INTO lop (malop, tenlop, makhoa) VALUES (@malop, @tenlop, @makhoa)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@malop", txtmalop.Text);
                command.Parameters.AddWithValue("@tenlop", txttenlop.Text);
                command.Parameters.AddWithValue("@makhoa", cbmakhoa.SelectedValue);

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
            if (string.IsNullOrWhiteSpace(txtmalop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
      
            if (string.IsNullOrWhiteSpace(txttenlop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmalop.Text.Length > 10)
            {
                MessageBox.Show("Mã lớp không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txttenlop.Text.Length > 50)
            {
                MessageBox.Show("Tên lớp không được quá 50 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbmakhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã khoa hoặc mã khoa không tồn tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string malop = txtmalop.Text;

            string query = "UPDATE lop SET tenlop = @tenlop, makhoa = @makhoa WHERE malop = @malop";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@malop", malop);
                command.Parameters.AddWithValue("@tenlop", txttenlop.Text);
                command.Parameters.AddWithValue("@makhoa", cbmakhoa.SelectedValue);

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
            if (string.IsNullOrWhiteSpace(txtmalop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
             
                string malop = txtmalop.Text;

                string query = "DELETE FROM lop WHERE malop = @malop";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@malop", malop);

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

        private void btnthoat_Click(object sender, EventArgs e)
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
            if (selectedRowIndex >= 0 && selectedRowIndex < dgv.Rows.Count)
            {
                txtmalop.Text = dgv.Rows[selectedRowIndex].Cells["malop"].Value.ToString();
                txttenlop.Text = dgv.Rows[selectedRowIndex].Cells["tenlop"].Value.ToString();
                cbmakhoa.SelectedValue = dgv.Rows[selectedRowIndex].Cells["makhoa"].Value.ToString();
            }
        }

        private void cn_lop_Load(object sender, EventArgs e)
        {
            txtmalop.Focus();
        }
    }
}
