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

namespace QLSinhViennhom5.TimKiem
{
    public partial class frm_TimKiem_Lop : Form
    {

        SqlConnection connection;
        SqlCommand command;
        private string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dataTable = new DataTable();

        public frm_TimKiem_Lop()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            LoadData();
            LoadComboBoxData();

            dgv.Columns["malop"].HeaderText = "Mã lớp";
            dgv.Columns["tenlop"].HeaderText = "Tên lớp";
            dgv.Columns["tenkhoa"].HeaderText = "Tên khoa";



            dgv.Columns["malop"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenlop"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenkhoa"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);



            dgv.Columns["malop"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenlop"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenkhoa"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);



            dgv.Columns["malop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenlop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenkhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }

        private void LoadData()
        {

            string sql = "select malop, tenlop, tenkhoa from lop join khoa on(lop.makhoa = khoa.makhoa)";
            using (adapter = new SqlDataAdapter(sql, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void LoadComboBoxData()
        {
            cbb_timtheo.Items.Add("Mã Lớp");
            cbb_timtheo.Items.Add("Tên Lớp");
            cbb_timtheo.Items.Add("Tên Khoa");
        }

        private void frm_TimKiem_Lop_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadData();
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

            command = new SqlCommand();
            command.Connection = connection;

            if (cbb_timtheo.Text == "Mã Lớp")
            {
                command.CommandText = "select * from chinhsach " +
                            " where malop like'%" + (txt_tukhoa.Text).Trim() + "%'";

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
                command.CommandText = "select * from lop " +
                            " where tenlop like'%" + (txt_tukhoa.Text).Trim() + "%'";

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

            if (cbb_timtheo.Text == "Tên Khoa")
            {
                command.CommandText = "select malop, tenlop, tenkhoa from lop " +
                            "join khoa on ( khoa.makhoa = lop.makhoa) where tenkhoa like N'%" + (txt_tukhoa.Text).Trim() + "%'";



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
    }
}
