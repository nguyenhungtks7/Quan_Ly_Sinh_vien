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
    public partial class frm_TimKiem_Khoa : Form
    {
        SqlConnection connection;
        SqlCommand command;
        Database db = new Database();
        private string connectionString ;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dataTable = new DataTable();


        public frm_TimKiem_Khoa()
        {
            InitializeComponent();
            connectionString = db.ConnectionString;
            connection = new SqlConnection(connectionString);
            LoadData();
            LoadComboBoxData();


            dgv.Columns["makhoa"].HeaderText = "Mã khoa";
            dgv.Columns["tenkhoa"].HeaderText = "Tên khoa";
            


            dgv.Columns["makhoa"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenkhoa"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
          


            dgv.Columns["makhoa"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenkhoa"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
          


            dgv.Columns["makhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenkhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           


        }
        private void LoadData()
        {

            string sql = "select * from khoa";
            using (adapter = new SqlDataAdapter(sql, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void LoadComboBoxData()
        {
            cbb_timtheo.Items.Add("Mã Khoa");
            cbb_timtheo.Items.Add("Tên Khoa");
        }

        private void frm_TimKiem_Khoa_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadData();
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
            // mã khoa



            command = new SqlCommand();
            command.Connection = connection;

            if (cbb_timtheo.Text == "Mã Khoa")
            {
                command.CommandText = "select * from khoa " +
                            " where makhoa like'%" + (txt_tukhoa.Text).Trim() + "%'";

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
                command.CommandText = "select * from khoa " +
                            " where tenkhoa like N'%" + (txt_tukhoa.Text).Trim() + "%'";

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
