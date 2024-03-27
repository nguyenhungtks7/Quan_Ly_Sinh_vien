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
    public partial class tt_sinhvien : Form
    {
        private const string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        public tt_sinhvien()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            LoadData();
          
            dgv.Columns["masv"].HeaderText = "Mã Sinh Viên";
            dgv.Columns["tensv"].HeaderText = "Tên Sinh Viên";
            dgv.Columns["gioitinh"].HeaderText = "Giới tính";
            dgv.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dgv.Columns["sdt"].HeaderText = "Số điện thoại";
            dgv.Columns["diachi"].HeaderText = "Địa chỉ";
            dgv.Columns["macs"].HeaderText = "Mã chính sách";
            dgv.Columns["malop"].HeaderText = "Mã lớp";

            dgv.Columns["masv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tensv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["gioitinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ngaysinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["sdt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["diachi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["macs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["malop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgv.Columns["masv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tensv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["gioitinh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["ngaysinh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["sdt"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["diachi"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["macs"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["malop"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            dgv.Columns["masv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tensv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["gioitinh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["ngaysinh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["sdt"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["diachi"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["macs"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["malop"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);




        }
        private void LoadData()
        {
            string query = "SELECT * FROM sinhvien";
            using (adapter = new SqlDataAdapter(query, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {

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
                txtmasv.Text = row.Cells["masv"].Value.ToString();
                txttensv.Text = row.Cells["tensv"].Value.ToString();
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
                cbmacs.Text = row.Cells["macs"].Value.ToString();
                cbmalop.Text = row.Cells["malop"].Value.ToString();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            In_SinhVien frm = new In_SinhVien();
            frm.Show();
        }

        private void tt_sinhvien_Load(object sender, EventArgs e)
        {
            txtmasv.Focus();
        }
    }
}
