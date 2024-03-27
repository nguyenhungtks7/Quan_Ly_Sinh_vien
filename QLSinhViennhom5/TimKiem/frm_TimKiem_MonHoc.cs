using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QLSinhViennhom5.TimKiem
{
    public partial class frm_TimKiem_MonHoc : Form
    {
        SqlConnection connection;
        SqlCommand command;
        Database db = new Database();
        private string connectionString ;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dataTable = new DataTable();
        public frm_TimKiem_MonHoc()
        {
            InitializeComponent();
            connectionString = db.ConnectionString;
            connection = new SqlConnection(connectionString);
            LoadData();
            LoadComboBoxData();

            dgv.Columns["mamh"].HeaderText = "Mã môn học";
            dgv.Columns["tenmh"].HeaderText = "Tên môn học ";
            dgv.Columns["sotiet"].HeaderText = "Số tiết";
            dgv.Columns["tengv"].HeaderText = "Tên giáo viên";



            dgv.Columns["mamh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tenmh"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["sotiet"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.Columns["tengv"].HeaderCell.Style.Font = new Font("Times New Roman", 10, FontStyle.Bold);



            dgv.Columns["mamh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tenmh"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["sotiet"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dgv.Columns["tengv"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);



            dgv.Columns["mamh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tenmh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["sotiet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tengv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadData()
        {
            
            string sql = "select mamh, tenmh, sotiet, tengv from monhoc " +
                            "join giaovien on(monhoc.magv = giaovien.magv)";
            using (adapter = new SqlDataAdapter(sql, connection))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
        }
        private void LoadComboBoxData()
        {
            cbb_timtheo.Items.Add("Mã Môn Học");
            cbb_timtheo.Items.Add("Tên Môn");
            cbb_timtheo.Items.Add("Tên Giáo Viên");
            cbb_timtheo.Items.Add("Số Tiết");
        }
        private void frm_TimKiem_MonHoc_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadData();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            Boolean kt = false;
            string kq;
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
            // check cbb

            command = new SqlCommand();
            command.Connection = connection;

            if (cbb_timtheo.Text == "Mã Môn Học")
            {
                command.CommandText = "select mamh, tenmh, sotiet, tengv  from monhoc " +
                    " join giaovien on(monhoc.magv = giaovien.magv)  where mamh like '%" + txt_tukhoa.Text + "%'";

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

            if (cbb_timtheo.Text == "Tên Môn")
            {
                command.CommandText = "select mamh, tenmh, sotiet, tengv  from monhoc " +
                    " join giaovien on(monhoc.magv = giaovien.magv)  where tenmh like N'%" + txt_tukhoa.Text + "%'";

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

            if (cbb_timtheo.Text == "Tên Giáo Viên")
            {
                command.CommandText = "select mamh, tenmh, sotiet, tengv from monhoc " +
                    " join giaovien on(monhoc.magv = giaovien.magv)  where tengv like N'%" + txt_tukhoa.Text + "%'";

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

            if (cbb_timtheo.Text == "Số Tiết")
            {
                command.CommandText = "select mamh, tenmh, sotiet, tengv from monhoc " +
                    " join giaovien on(monhoc.magv = giaovien.magv)  where sotiet like '%" + txt_tukhoa.Text + "%'";

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




            connection.Close();



           

        }// tim

        private void btn_LoadLai_Click(object sender, EventArgs e)
        {
            txt_tukhoa.Clear();
            cbb_timtheo.Focus();

            LoadData();
                
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    } //class
}