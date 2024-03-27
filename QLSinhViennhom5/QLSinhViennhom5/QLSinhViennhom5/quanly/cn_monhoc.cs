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
    public partial class cn_monhoc : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        public cn_monhoc()
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            LoadData();

            dgv.Columns["mamh"].HeaderText = "Mã Môn Học";
            dgv.Columns["tenmh"].HeaderText = "Tên Môn Học";
            dgv.Columns["sotiet"].HeaderText = "Số Tín Chỉ";
            dgv.Columns["magv"].HeaderText = "Mã Giáo Viên";

            dgv.Columns["mamh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenmh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["sotiet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["magv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["mamh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenmh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["sotiet"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["magv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
           

            dgv.Columns["mamh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenmh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["sotiet"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["magv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
          
        }
        private void ClearTextBoxes()
        {
            txtmamh.Clear();
            txttenmh.Clear();
            txtsotiet.Clear();
        
        }

        private void LoadData()
        {
            string queryMonHoc = "SELECT *from monhoc";
                                 

            using (adapter = new SqlDataAdapter(queryMonHoc, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgv.DataSource = dataTable;
            }

           
            string queryGiaoVien = "SELECT magv, tengv FROM giaovien";
            adapter = new SqlDataAdapter(queryGiaoVien, connection);
            DataTable gvDataTable = new DataTable();
            adapter.Fill(gvDataTable);

            cbmagv.DataSource = gvDataTable;
            cbmagv.DisplayMember = "magv";
            cbmagv.ValueMember = "magv";
        }
        private bool CheckMaMonHocExist(string maMH)
        {
            string queryCheck = "SELECT COUNT(*) FROM monhoc WHERE mamh = @mamh";

            using (SqlCommand checkCommand = new SqlCommand(queryCheck, connection))
            {
                checkCommand.Parameters.AddWithValue("@mamh", maMH);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }

        private void cn_monhoc_Load(object sender, EventArgs e)
        {
            txtmamh.Focus();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmamh.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Môn Học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
                if (string.IsNullOrWhiteSpace(txtmamh.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tên môn học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
      
            if (CheckMaMonHocExist(txtmamh.Text))
            {
                MessageBox.Show("Mã Môn Học đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                if (cbmagv.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã Giáo Viên hoặc mã giáo viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (!int.TryParse(txtsotiet.Text, out _))
            {
                MessageBox.Show("Số tiết không hợp lệ hoặc bạn chưa nhập số tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO monhoc (mamh, tenmh, sotiet, magv) " +
                           "VALUES (@mamh, @tenmh, @sotc, @magv)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@mamh", txtmamh.Text);
                command.Parameters.AddWithValue("@tenmh", txttenmh.Text);
                command.Parameters.AddWithValue("@sotc", int.Parse(txtsotiet.Text));
                command.Parameters.AddWithValue("@magv", cbmagv.SelectedValue.ToString());

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
            if (string.IsNullOrWhiteSpace(txtmamh.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Môn Học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtmamh.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên môn học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (cbmagv.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã Giáo Viên hoặc mã giáo viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (!int.TryParse(txtsotiet.Text, out _))
            {
                MessageBox.Show("Số tiết không hợp lệ hoặc bạn chưa nhập số tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "UPDATE monhoc SET tenmh = @tenmh, sotiet = @sotc, magv = @magv WHERE mamh = @mamh";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@mamh", txtmamh.Text);
                command.Parameters.AddWithValue("@tenmh", txttenmh.Text);
                command.Parameters.AddWithValue("@sotc", int.Parse(txtsotiet.Text));
                command.Parameters.AddWithValue("@magv", cbmagv.SelectedValue.ToString());

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            ClearTextBoxes();
            LoadData();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmamh.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Môn Học để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckMaMonHocExist(txtmamh.Text))
            {
                MessageBox.Show("Mã Môn Học không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM monhoc WHERE mamh = @mamh";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mamh", txtmamh.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                ClearTextBoxes();
                LoadData();
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

        private void dgv_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];

                    // Hiển thị dữ liệu của dòng được chọn lên các điều khiển nhập liệu
                    txtmamh.Text = row.Cells["mamh"].Value.ToString();
                    txttenmh.Text = row.Cells["tenmh"].Value.ToString();
                    txtsotiet.Text = row.Cells["sotiet"].Value.ToString();

                    // Chọn giáo viên trong ComboBox
                    string selectedMaGV = row.Cells["magv"].Value.ToString();
                    cbmagv.SelectedValue = selectedMaGV;
                }
        }
    }
}
