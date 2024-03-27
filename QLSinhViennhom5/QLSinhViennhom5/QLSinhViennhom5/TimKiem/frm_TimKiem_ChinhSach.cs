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
    public partial class frm_TimKiem_ChinhSach : Form
    {
        SqlConnection connection;
        SqlCommand command;
        private string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dataTable = new DataTable();


        public frm_TimKiem_ChinhSach()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            LoadData();
            LoadComboBoxData();
            dgv.Columns["macs"].HeaderText = "Mã chính sách";
            dgv.Columns["tencs"].HeaderText = "Tên chính sách";
            dgv.Columns["chedo"].HeaderText = "Chế độ";
          

            dgv.Columns["macs"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tencs"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["chedo"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);


            dgv.Columns["macs"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tencs"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["chedo"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);


            dgv.Columns["macs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tencs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["chedo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadData()
        {

            string sql = "select * from chinhsach";
            using (adapter = new SqlDataAdapter(sql, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void LoadComboBoxData()
        {
            cbb_timtheo.Items.Add("Mã Chính Sách");
            cbb_timtheo.Items.Add("Tên Chính Sách");
            cbb_timtheo.Items.Add("Chế Độ");

           
            
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {

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
            // mã chính sách

            command = new SqlCommand();
            command.Connection = connection;

            if (cbb_timtheo.Text == "Mã Chính Sách")
            {
                command.CommandText = "select * from chinhsach " +
                            " where macs like'%" + (txt_tukhoa.Text).Trim() + "%'";

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
                command.CommandText = "select * from chinhsach " +
                            " where tencs like N'%" + (txt_tukhoa.Text).Trim() + "%'";

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

            if (cbb_timtheo.Text == "Tên Chế Độ")
            {
                command.CommandText = "select * from chinhsach " +
                            " where chedo like N'%" + (txt_tukhoa.Text).Trim() + "%'";

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

        private void frm_TimKiem_ChinhSach_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadData();
        }
    }
}
