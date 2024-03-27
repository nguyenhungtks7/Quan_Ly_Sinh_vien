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
    public partial class tt_diemsv : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        public tt_diemsv()
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            LoadData();
            dgv.Columns["id"].HeaderText = "ID";
            dgv.Columns["masv"].HeaderText = "Mã Sinh Viên";
            dgv.Columns["mamh"].HeaderText = "Mã Môn Học";
            dgv.Columns["diem"].HeaderText = "Điểm";

            dgv.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["masv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["mamh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["diem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["id"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["masv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["mamh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["diem"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);



            dgv.Columns["id"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["masv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["mamh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["diem"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
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
        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Close();

            }
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            In_diem frm = new In_diem();
            frm.Show();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                // Hiển thị dữ liệu của dòng được chọn lên các điều khiển nhập liệu
                txtmaid.Text = row.Cells["id"].Value.ToString();
                cbmsv.Text = row.Cells["masv"].Value.ToString();
                cbmamh.Text = row.Cells["mamh"].Value.ToString();
                txtdiem.Text = row.Cells["diem"].Value.ToString();
            }
        }

        private void tt_diemsv_Load(object sender, EventArgs e)
        {
            txtmaid.Focus();
        }
    }
}
