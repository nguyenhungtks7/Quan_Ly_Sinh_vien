using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhViennhom5.TimKiem
{
    public partial class frm_TimKiem_GiaoVien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        private string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dataTable = new DataTable();

        public frm_TimKiem_GiaoVien()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            LoadData();
            LoadComboBoxData();

            dgv.Columns["magv"].HeaderText = "Mã giáo viên";
            dgv.Columns["tengv"].HeaderText = "Tên giáo viên";
            dgv.Columns["gioitinh"].HeaderText = "Giới tính";
            dgv.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dgv.Columns["sdt"].HeaderText = "Số điện thoại";
            dgv.Columns["diachi"].HeaderText = "Địa chỉ";


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

            string sql = "select * from giaovien";
            using (adapter = new SqlDataAdapter(sql, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void LoadComboBoxData()
        {
            cbb_timtheo.Items.Add("Mã Giáo Viên");
            cbb_timtheo.Items.Add("Tên Giáo Viên");
            cbb_timtheo.Items.Add("Giới Tính");
            cbb_timtheo.Items.Add("Ngày Sinh");
            cbb_timtheo.Items.Add("Số Điện Thoại");
            cbb_timtheo.Items.Add("Địa Chỉ");
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {

                Boolean kt = false;
                
                string kq_cbb = cbb_timtheo.Text;

                if (string.IsNullOrEmpty(txt_tukhoa.Text))
                {
                    MessageBox.Show("Không được để trống Từ Khóa", "Tìm Kiếm", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txt_tukhoa.Focus();
                    return;
                }
                if (cbb_timtheo.SelectedIndex == -1)
                {
                    MessageBox.Show("Tìm theo không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            // check cbb


            //////////////
            command = new SqlCommand();
            command.Connection = connection;

            if (cbb_timtheo.Text == "Mã Giáo Viên")
            {
                command.CommandText = "select * from giaovien " +
                                " where magv like'%" + (txt_tukhoa.Text).Trim() + "%'";

                adapter.SelectCommand = command;
                dataTable.Clear();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Đã tìm thấy dữ liệu", "Tìm Kiếm", MessageBoxButtons.OKCancel);
                    dgv.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã.");
                }
            }

            if (cbb_timtheo.Text == "Tên Giáo Viên")
            {
                command.CommandText = "select * from giaovien" +
                                " where giaovien.tengv like N'%" + (txt_tukhoa.Text).Trim() + "%'";

                adapter.SelectCommand = command;
                dataTable.Clear();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Đã tìm thấy dữ liệu", "Tìm Kiếm", MessageBoxButtons.OKCancel);
                    dgv.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã.");
                }
            }

            if (cbb_timtheo.Text == "Giới Tính")
            {
                command.CommandText = "select * from giaovien " +
                                " where gioitinh like N'%" + (txt_tukhoa.Text).Trim() + "%'";

                adapter.SelectCommand = command;
                dataTable.Clear();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Đã tìm thấy dữ liệu", "Tìm Kiếm", MessageBoxButtons.OKCancel);
                    dgv.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã.");
                }
            }
            if (cbb_timtheo.Text == "Ngày Sinh")
            {

               
                DateTime inputDate;
                if (DateTime.TryParseExact(txt_tukhoa.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out inputDate))
                {
                   
                    string outputDateString = inputDate.ToString("yyyy-MM-dd");

                    command.CommandText = "SELECT * FROM giaovien " +
                                          "WHERE ngaysinh LIKE @NgaySinh";
                    command.Parameters.AddWithValue("@NgaySinh", "%" + outputDateString.Trim() + "%");

                    adapter.SelectCommand = command;
                    dataTable.Clear();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Đã tìm thấy dữ liệu", "Tìm Kiếm", MessageBoxButtons.OKCancel);
                        dgv.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu.");
                    }
                }
                else
                {
                    MessageBox.Show("Ngày tháng không đúng định dạng. Vui lòng nhập theo định dạng yyyy-MM-dd (năm-tháng-ngày) ví dụ \"1995-02-02.\"");
                }
            }

            if (cbb_timtheo.Text == "Số Điện Thoại")
            {
                command.CommandText = "select * from giaovien " +
                                " where sdt like N'%" + (txt_tukhoa.Text).Trim() + "%'";

                adapter.SelectCommand = command;
                dataTable.Clear();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Đã tìm thấy dữ liệu", "Tìm Kiếm", MessageBoxButtons.OKCancel);
                    dgv.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã.");
                }
            }

            if (cbb_timtheo.Text == "Địa Chỉ")
            {
                command.CommandText = "select * from giaovien " +
                                " where diachi like N'%" + (txt_tukhoa.Text).Trim() + "%'";

                adapter.SelectCommand = command;
                dataTable.Clear();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Đã tìm thấy dữ liệu", "Tìm Kiếm", MessageBoxButtons.OKCancel);
                    dgv.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã.");
                }
            }
            
        }

        private void frm_TimKiem_GiaoVien_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadData();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_LoadLai_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadData();
        }
    }
}
