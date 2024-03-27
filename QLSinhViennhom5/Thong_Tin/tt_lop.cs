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
    public partial class tt_lop : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        Database db = new Database();
        public tt_lop()
        {
            InitializeComponent();
            connection = new SqlConnection(db.ConnectionString);
            LoadData();
          
            dgv.Columns["malop"].HeaderText = "Mã Lớp";
            dgv.Columns["tenlop"].HeaderText = "Tên Lớp";
            dgv.Columns["makhoa"].HeaderText = "Tên khoa";

            dgv.Columns["malop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenlop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["makhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         

            dgv.Columns["malop"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenlop"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["makhoa"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);




            dgv.Columns["malop"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenlop"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["makhoa"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
        }
        private void LoadData()
        {

            string query = "SELECT * FROM lop";
            using (adapter = new SqlDataAdapter(query, connection))
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

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            if (selectedRowIndex >= 0 && selectedRowIndex < dgv.Rows.Count)
            {
                txtmalop.Text = dgv.Rows[selectedRowIndex].Cells["malop"].Value.ToString();
                txttenlop.Text = dgv.Rows[selectedRowIndex].Cells["tenlop"].Value.ToString();
                cbmakhoa.Text = dgv.Rows[selectedRowIndex].Cells["makhoa"].Value.ToString();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            In_lop in_Lop = new In_lop();
            in_Lop.Show();
        }

        private void tt_lop_Load(object sender, EventArgs e)
        {
            txtmalop.Focus();
        }
    }
}
