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
    public partial class frm_TimKiem_SinhVien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        Database db = new Database();
        private string connectionString;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dataTable = new DataTable();


        public frm_TimKiem_SinhVien()
        {
            InitializeComponent();
            connectionString = db.ConnectionString;
            connection = new SqlConnection(connectionString);
            LoadData();
            LoadComboBoxData();

           


            dgv.Columns["masv"].HeaderText = "Mã Sinh Viên";
            dgv.Columns["tensv"].HeaderText = "Tên Sinh Viên";
            dgv.Columns["gioitinh"].HeaderText = "Giới tính";
            dgv.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dgv.Columns["sdt"].HeaderText = "Số điện thoại";
            dgv.Columns["diachi"].HeaderText = "Địa chỉ";
            dgv.Columns["tencs"].HeaderText = "Tên chính sách";
            dgv.Columns["tenlop"].HeaderText = "Tên lớp";





            dgv.Columns["masv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tensv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["gioitinh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["ngaysinh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["sdt"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["diachi"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tencs"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenlop"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            dgv.Columns["masv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tensv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["gioitinh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["ngaysinh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["sdt"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["diachi"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tencs"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenlop"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);

            dgv.Columns["masv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tensv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["gioitinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ngaysinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["sdt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["diachi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tencs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenlop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadData()
        {

            string sql = "select masv, tensv, gioitinh, ngaysinh, sdt, diachi, tencs,tenlop from sinhvien " +
                "join chinhsach on(chinhsach.macs = sinhvien.macs) " +
                "join lop on(lop.malop = sinhvien.malop)";
            using (adapter = new SqlDataAdapter(sql, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void LoadComboBoxData()
        {
            cbb_timtheo.Items.Add("Mã Sinh Viên");
            cbb_timtheo.Items.Add("Tên Sinh Viên");
            cbb_timtheo.Items.Add("Giới Tính");
            cbb_timtheo.Items.Add("Ngày Sinh");
            cbb_timtheo.Items.Add("Số Điện Thoại");
            cbb_timtheo.Items.Add("Địa Chỉ");
            cbb_timtheo.Items.Add("Tên Chính Sách");
            cbb_timtheo.Items.Add("Tên Lớp");

        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
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

            //////////////
             command = new SqlCommand();
            command.Connection = connection;

            if (cbb_timtheo.Text == "Mã Sinh Viên")
            {
                command.CommandText = "select masv, tensv, gioitinh, ngaysinh, sdt, diachi, tencs,tenlop from sinhvien " +
                            "join chinhsach on(chinhsach.macs = sinhvien.macs) " +
                            "join lop on(lop.malop = sinhvien.malop) " +
                            "where masv like '%" + txt_tukhoa.Text.Trim() + "%'";

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

            if (cbb_timtheo.Text == "Tên Sinh Viên")
            {
                command.CommandText = "select masv, tensv, gioitinh, ngaysinh, sdt, diachi, tencs,tenlop from sinhvien " +
                            "join chinhsach on(chinhsach.macs = sinhvien.macs) " +
                            "join lop on(lop.malop = sinhvien.malop) " +
                            "where tensv  like N'%" + txt_tukhoa.Text.Trim() + "%'";

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
                command.CommandText = "select masv, tensv, gioitinh, ngaysinh, sdt, diachi, tencs,tenlop from sinhvien " +
                            "join chinhsach on(chinhsach.macs = sinhvien.macs) " +
                            "join lop on(lop.malop = sinhvien.malop) " +
                            "where gioitinh  like N'%" + txt_tukhoa.Text.Trim() + "%'";

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
                    command.CommandText = "select masv, tensv, gioitinh, ngaysinh, sdt, diachi, tencs,tenlop from sinhvien " +
                            "join chinhsach on(chinhsach.macs = sinhvien.macs) " +
                            "join lop on(lop.malop = sinhvien.malop) " +
                            "where ngaysinh like '%" + outputDateString.Trim() + "%'";

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
                else
                {
                    MessageBox.Show("Ngày tháng không đúng định dạng. Vui lòng nhập theo định dạng yyyy-MM-dd (năm-tháng-ngày) ví dụ \"1995-02-02.\"");
                }
            }

            if (cbb_timtheo.Text == "Số Điện Thoại")
            {
                command.CommandText = "select masv, tensv, gioitinh, ngaysinh, sdt, diachi, tencs,tenlop from sinhvien " +
                            "join chinhsach on(chinhsach.macs = sinhvien.macs) " +
                            "join lop on(lop.malop = sinhvien.malop) " +
                            "where sdt like '%" + txt_tukhoa.Text.Trim() + "%'";

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
                command.CommandText = "select masv, tensv, gioitinh, ngaysinh, sdt, diachi, tencs,tenlop from sinhvien " +
                    "join chinhsach on(chinhsach.macs = sinhvien.macs) " +
                    "join lop on(lop.malop = sinhvien.malop) where diachi like N'%" + txt_tukhoa.Text.Trim() + "%'";

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
            if (cbb_timtheo.Text == "Tên Chính Sách")
            {
                command.CommandText = "select masv, tensv, gioitinh, ngaysinh, sdt, diachi, tencs,tenlop from sinhvien " +
                            "join chinhsach on(chinhsach.macs = sinhvien.macs) " +
                            "join lop on(lop.malop = sinhvien.malop) " +
                            "where tencs like N'%" + txt_tukhoa.Text.Trim() + "%'";

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
            if (cbb_timtheo.Text == "Tên Lớp")
            {
                command.CommandText = "select masv, tensv, gioitinh, ngaysinh, sdt, diachi, tencs,tenlop from sinhvien " +
                            "join chinhsach on(chinhsach.macs = sinhvien.macs) " +
                            "join lop on(lop.malop = sinhvien.malop) " +
                            "where tenlop like '%" + txt_tukhoa.Text.Trim() + "%'";

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


            /////////////////

        }
        private void btn_LoadLai_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadData();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_TimKiem_SinhVien_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadData();
        }
    }
}
