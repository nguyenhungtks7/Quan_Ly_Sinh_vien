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
    public partial class tt_monhoc : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        public tt_monhoc()
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
        private void LoadData()
        {
            string queryMonHoc = "SELECT *from monhoc";


            using (adapter = new SqlDataAdapter(queryMonHoc, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgv.DataSource = dataTable;
            }

        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

               
                txtmamh.Text = row.Cells["mamh"].Value.ToString();
                txttenmh.Text = row.Cells["tenmh"].Value.ToString();
                txtsotiet.Text = row.Cells["sotiet"].Value.ToString();

           
                string selectedMaGV = row.Cells["magv"].Value.ToString();
                cbmagv.Text = selectedMaGV;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            In_monhoc frm = new In_monhoc();
            frm.Show();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Close();

            }
        }

        private void tt_monhoc_Load(object sender, EventArgs e)
        {
            txtmamh.Focus();
        }
    }
}
