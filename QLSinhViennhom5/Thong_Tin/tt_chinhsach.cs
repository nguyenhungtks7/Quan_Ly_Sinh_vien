using QLSinhViennhom5.Inchinhsach;
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

namespace QLSinhViennhom5
{
    public partial class tt_chinhsach : Form
    {
           private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        Database db = new Database();
        public tt_chinhsach()
        {
            InitializeComponent();
            this.ActiveControl = txtma;
            connection = new SqlConnection(db.ConnectionString);
            LoadData();
            dgv.Columns["macs"].HeaderText = "Mã chính sách";
            dgv.Columns["tencs"].HeaderText = "Tên chính sách";
            dgv.Columns["chedo"].HeaderText = "Chế độ";

            dgv.Columns["macs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tencs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["chedo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["macs"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tencs"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["chedo"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);



            dgv.Columns["macs"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tencs"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["chedo"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
        }
        private void LoadData()
        {

            string query = "SELECT * FROM chinhsach";
            using (adapter = new SqlDataAdapter(query, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void btnin_Click(object sender, EventArgs e)
        {
            In_chinhsach frm = new In_chinhsach();
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
            int selectedRowIndex = e.RowIndex;
            if (selectedRowIndex >= 0)
            {
                txtma.Text = dgv.Rows[selectedRowIndex].Cells["macs"].Value.ToString();
                txtten.Text = dgv.Rows[selectedRowIndex].Cells["tencs"].Value.ToString();
                txtchedo.Text = dgv.Rows[selectedRowIndex].Cells["chedo"].Value.ToString();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tt_chinhsach_Load(object sender, EventArgs e)
        {
            txtma.Focus();
        }
    }
}
