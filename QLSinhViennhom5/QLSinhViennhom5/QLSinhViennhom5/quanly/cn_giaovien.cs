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
    public partial class cn_giaovien : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        public cn_giaovien()
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            LoadData();

            dgv.Columns["magv"].HeaderText = "Mã GV";
            dgv.Columns["tengv"].HeaderText = "Tên GV";
            dgv.Columns["gioitinh"].HeaderText = "Giới Tính";
            dgv.Columns["ngaysinh"].HeaderText = "Ngày Sinh";
            dgv.Columns["sdt"].HeaderText = "SĐT";
            dgv.Columns["diachi"].HeaderText = "Địa Chỉ";


            dgv.Columns["magv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tengv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["gioitinh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["ngaysinh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["sdt"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["diachi"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            dgv.Columns["magv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tengv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["gioitinh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["ngaysinh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["sdt"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["diachi"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);

            dgv.Columns["magv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tengv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["gioitinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ngaysinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["sdt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["diachi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



        }
        private void LoadData()
        {
            string queryGiaoVien = "SELECT * FROM giaovien";

            using (adapter = new SqlDataAdapter(queryGiaoVien, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgv.DataSource = dataTable;
            }
        }
        private void ClearTextBoxes()
        {
            txtmagv.Clear();
            txttengv.Clear();
          
            txtsdt.Clear();
            txtdiachi.Clear();
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmagv.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Giáo Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmagv.Text.Length > 10)
            {
                MessageBox.Show("Mã giáo viên không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txttengv.Text))
            {
                MessageBox.Show("Vui lòng nhập tên giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!cbnam.Checked && !cbnu.Checked)
            {
                MessageBox.Show("Bạn chưa chọn giới tính nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gioitinh = "";
            if (cbnam.Checked)
            {
                gioitinh = cbnam.Text;
            }
            else
            {
                gioitinh = cbnu.Text;
            }

            if (!DateTime.TryParse(txtngaysinh.Text, out DateTime enteredDate))
            {
                MessageBox.Show("Ngày sinh không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (enteredDate >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!long.TryParse(txtsdt.Text, out _))
            {
                MessageBox.Show("Số điện không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sdt = "";


            string phoneNumber = txtsdt.Text.Trim();

            if (!phoneNumber.StartsWith("0"))
            {
                if (phoneNumber.Length != 9)
                {
                    MessageBox.Show("Bạn phải nhập 9 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sdt += "0" + phoneNumber;
                }
            }
            else
            {
                if (phoneNumber.Length != 10)
                {
                    MessageBox.Show("Bạn phải nhập 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sdt += phoneNumber;
                }
            }
            if (string.IsNullOrWhiteSpace(txtdiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE giaovien SET tengv = @tengv, gioitinh = @gioitinh, ngaysinh = @ngaysinh, sdt = @sdt, diachi = @diachi WHERE magv = @magv";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@magv", txtmagv.Text);
                command.Parameters.AddWithValue("@tengv", txttengv.Text);
                command.Parameters.AddWithValue("@gioitinh", gioitinh);
                command.Parameters.AddWithValue("@ngaysinh", txtngaysinh.Value);
                command.Parameters.AddWithValue("@sdt", sdt);
                command.Parameters.AddWithValue("@diachi", txtdiachi.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            ClearTextBoxes();
            LoadData();
            MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmagv.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Giáo Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CheckMaGiaoVienExist(txtmagv.Text))
            {
                MessageBox.Show("Mã Giáo Viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmagv.Text.Length > 10)
            {
                MessageBox.Show("Mã giáo viên không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txttengv.Text))
            {
                MessageBox.Show("Vui lòng nhập tên giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!cbnam.Checked && !cbnu.Checked)
            {
                MessageBox.Show("Bạn chưa chọn giới tính nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gioitinh = "";
            if (cbnam.Checked)
            {
                gioitinh = cbnam.Text;
            }
            else
            {
                gioitinh = cbnu.Text;
            }

            if (!DateTime.TryParse(txtngaysinh.Text, out DateTime enteredDate))
            {
                MessageBox.Show("Ngày sinh không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (enteredDate >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!long.TryParse(txtsdt.Text, out _))
            {
                MessageBox.Show("Số điện không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sdt = "";


            string phoneNumber = txtsdt.Text.Trim();

            if (!phoneNumber.StartsWith("0"))
            {
                if (phoneNumber.Length != 9)
                {
                    MessageBox.Show("Bạn phải nhập 9 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sdt += "0" + phoneNumber;
                }
            }
            else
            {
                if (phoneNumber.Length != 10)
                {
                    MessageBox.Show("Bạn phải nhập 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sdt += phoneNumber;
                }
            }
            if (string.IsNullOrWhiteSpace(txtdiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO giaovien (magv, tengv, gioitinh, ngaysinh, sdt, diachi) " +
                           "VALUES (@magv, @tengv, @gioitinh, @ngaysinh, @sdt, @diachi)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@magv", txtmagv.Text);
                command.Parameters.AddWithValue("@tengv", txttengv.Text);
                command.Parameters.AddWithValue("@gioitinh", gioitinh);
                command.Parameters.AddWithValue("@ngaysinh", txtngaysinh.Value);
                command.Parameters.AddWithValue("@sdt", sdt);
                command.Parameters.AddWithValue("@diachi", txtdiachi.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            ClearTextBoxes();
            LoadData();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private bool CheckMaGiaoVienExist(string maGV)
        {
            string queryCheck = "SELECT COUNT(*) FROM giaovien WHERE magv = @magv";

            using (SqlCommand checkCommand = new SqlCommand(queryCheck, connection))
            {
                checkCommand.Parameters.AddWithValue("@magv", maGV);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmagv.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Giáo Viên để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           

            string query = "DELETE FROM giaovien WHERE magv = @magv";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@magv", txtmagv.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            ClearTextBoxes();
            LoadData();
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                txtmagv.Text = row.Cells["magv"].Value.ToString();
                txttengv.Text = row.Cells["tengv"].Value.ToString();
                string gioitinh = row.Cells["gioitinh"].Value.ToString();
                if (gioitinh == "Nam")
                {
                    cbnam.Checked = true;
                }
                else
                {
                    cbnu.Checked = true;
                }
                txtngaysinh.Value = DateTime.Parse(row.Cells["ngaysinh"].Value.ToString());
                txtsdt.Text = row.Cells["sdt"].Value.ToString();
                txtdiachi.Text = row.Cells["diachi"].Value.ToString();
            }
        }

        private void cn_giaovien_Load(object sender, EventArgs e)
        {
            txtmagv.Focus();
        }
    }
}
