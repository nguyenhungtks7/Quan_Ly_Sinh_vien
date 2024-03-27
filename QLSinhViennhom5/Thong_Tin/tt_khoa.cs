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
    public partial class tt_khoa : Form
    {
         private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        Database db = new Database();
        public tt_khoa()
        {
            InitializeComponent();
            connection = new SqlConnection(db.ConnectionString);
            LoadData();
            dgv.Columns["makhoa"].HeaderText = "Mã khoa";
            dgv.Columns["tenkhoa"].HeaderText = "Tên khoa";

            dgv.Columns["makhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenkhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["makhoa"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenkhoa"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
           



            dgv.Columns["makhoa"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenkhoa"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
       
        }
        private void LoadData()
        {

            string query = "SELECT * FROM khoa";
            using (adapter = new SqlDataAdapter(query, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void btnxoa_Click(object sender, EventArgs e)
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
            if (selectedRowIndex >= 0)
            {
                txtmakhoa.Text = dgv.Rows[selectedRowIndex].Cells["makhoa"].Value.ToString();
                txttenkhoa.Text = dgv.Rows[selectedRowIndex].Cells["tenkhoa"].Value.ToString();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            In_Khoa frm = new In_Khoa();
            frm.Show();
        }

        private void tt_khoa_Load(object sender, EventArgs e)
        {
            txtmakhoa.Focus();
        }
    }
}
