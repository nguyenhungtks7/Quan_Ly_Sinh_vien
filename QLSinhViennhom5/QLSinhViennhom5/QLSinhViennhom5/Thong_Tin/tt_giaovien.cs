using QLSinhViennhom5.IN;
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

namespace QLSinhViennhom5.Thong_Tin
{
    public partial class tt_giaovien : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        public tt_giaovien()
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

            dgv.Columns["magv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tengv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["gioitinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ngaysinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["sdt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["diachi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
        private void btnin_Click(object sender, EventArgs e)
        {
            In_giaovien frm = new In_giaovien();
            frm.Show();
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

        private void tt_giaovien_Load(object sender, EventArgs e)
        {
            txtmagv.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
