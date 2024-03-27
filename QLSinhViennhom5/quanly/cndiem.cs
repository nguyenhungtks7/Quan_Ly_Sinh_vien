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
    public partial class cndiem : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        Database db = new Database();
        public cndiem()
        {
            InitializeComponent();
            string connectionString = db.ConnectionString;
            connection = new SqlConnection(connectionString);
            LoadData();
            dgv.Columns["id"].HeaderText = "ID";
            dgv.Columns["masv"].HeaderText = "Mã Sinh Viên";
            dgv.Columns["mamh"].HeaderText = "Mã Môn Học";
            dgv.Columns["diem"].HeaderText = "Điểm";


            dgv.Columns["id"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["masv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["mamh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["diem"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            dgv.Columns["id"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["masv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["mamh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["diem"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);

            dgv.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["masv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["mamh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["diem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            string query = "SELECT masv, tensv FROM sinhvien";
            adapter = new SqlDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);

            cbmsv.DataSource = dataTable;
            cbmsv.DisplayMember = "masv";
            cbmsv.ValueMember = "masv";


            string query1 = "SELECT mamh, tenmh FROM monhoc";
            adapter = new SqlDataAdapter(query1, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);

            
            cbmamh.DataSource = dataTable;
            cbmamh.DisplayMember = "mamh";
            cbmamh.ValueMember = "mamh";
        }
        private void LoadData()
        {
          
            string queryDiem = "SELECT id, masv, mamh, diem FROM diem";

            using (adapter = new SqlDataAdapter(queryDiem, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);

              
                dgv.DataSource = dataTable;
            }
        }
        private void ClearTextBoxes()
        {
            
            txtmaid.Clear();
            txtdiem.Clear();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtmaid.Text))
             {
                MessageBox.Show("Bạn chưa nhập id", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbmsv.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Mã Sinh Viên hoặc Mã Sinh Viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbmamh.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Mã Môn học hoặc Mã Môn học không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

      

            if (!int.TryParse(txtmaid.Text, out int id))
            {
                MessageBox.Show("Bạn phải nhập id dạng số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string checkIdQuery = "SELECT COUNT(*) FROM diem WHERE id = @id";
            using (SqlCommand checkIdCommand = new SqlCommand(checkIdQuery, connection))
            {
                checkIdCommand.Parameters.AddWithValue("@id", id);
                connection.Open();
                int count = (int)checkIdCommand.ExecuteScalar();
                connection.Close();

                if (count > 0)
                {
                    MessageBox.Show("ID đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            float diem;
            if (!float.TryParse(txtdiem.Text, out diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm không hợp lệ hoặc bạn chưa nhập điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO diem (id, masv, mamh, diem) VALUES (@id, @masv, @mamh, @diem)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", int.Parse(txtmaid.Text));
                command.Parameters.AddWithValue("@masv", cbmsv.SelectedValue.ToString());
                command.Parameters.AddWithValue("@mamh", cbmamh.SelectedValue.ToString());
                command.Parameters.AddWithValue("@diem", float.Parse(txtdiem.Text));

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
            if (string.IsNullOrWhiteSpace(txtmaid.Text))
            {
                MessageBox.Show("Bạn chưa nhập id", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float diem;
            if (!float.TryParse(txtdiem.Text, out diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm không hợp lệ hoặc bạn chưa nhập điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "UPDATE diem SET masv = @masv, mamh = @mamh, diem = @diem WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", int.Parse(txtmaid.Text));
                command.Parameters.AddWithValue("@masv", cbmsv.SelectedValue.ToString());
                command.Parameters.AddWithValue("@mamh", cbmamh.SelectedValue.ToString());
                command.Parameters.AddWithValue("@diem", float.Parse(txtdiem.Text));

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
            if (string.IsNullOrWhiteSpace(txtmaid.Text))
            {
                MessageBox.Show("Bạn chưa nhập id để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtmaid.Text, out int id))
            {
                MessageBox.Show("Bạn phải nhập id dạng số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = int.Parse(txtmaid.Text);

       
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
        
                string query = "DELETE FROM diem WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", selectedId);

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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                txtmaid.Text = row.Cells["id"].Value.ToString();
                cbmsv.SelectedValue = row.Cells["masv"].Value.ToString();
                cbmamh.SelectedValue = row.Cells["mamh"].Value.ToString();
                txtdiem.Text = row.Cells["diem"].Value.ToString();
            }
        }

        private void cndiem_Load(object sender, EventArgs e)
        {
            txtmaid.Focus();
        }
    }
}
