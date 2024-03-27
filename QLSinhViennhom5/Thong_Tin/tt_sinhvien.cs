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
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSinhViennhom5.Thong_Tin
{
    public partial class tt_sinhvien : Form
    {
        public static string thongtinsinhvien;
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        Database db = new Database();
        public tt_sinhvien()
        {
            InitializeComponent();
            connection = new SqlConnection(db.ConnectionString);
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

        private void button1_Click(object sender, EventArgs e)
        {
         

            string gioitinh = "";
            if (cbnam.Checked )
            {
                gioitinh= "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }
            thongtinsinhvien = 
                txtmasv.Text.Trim() + ","
                + txttensv.Text.Trim() + ","
                + gioitinh + ","
                + txtngaysinh.Text.Trim() + "," +
                txtsdt.Text.Trim() + ","
                + txtdiachi.Text.Trim() + "," +
                cbmacs.Text.Trim() +","+
                cbmalop.Text.Trim();
           QR  qR = new QR();
            qR.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadQRCodeFromImage(openFileDialog.FileName);
            }
        }
        private void ReadQRCodeFromImage(string imagePath)
        {
          
            BarcodeReader barcodeReader = new BarcodeReader();

            try
            {
                // Đọc hình ảnh từ đường dẫn
                Bitmap barcodeBitmap = new Bitmap(imagePath);

                
                var result = barcodeReader.Decode(barcodeBitmap);

                if (result != null)
                {

                    MessageBox.Show("Dữ liệu từ mã QR: " + result.Text, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    string inputString = result.Text;
                    ProcessString(inputString);
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ProcessString(string input)
        {
            try
            {
                // Tách chuỗi thành các trường dựa trên dấu phẩy
                string[] fields = input.Split(',');

                // Kiểm tra và gán giá trị vào các textbox tương ứng
                if (fields.Length == 8)
                {
                    txtmasv.Text = fields[0].Trim();
                    txttensv.Text = fields[1].Trim();
                   if(cbnam.Text == fields[2].Trim())
                    {
                        cbnam.Checked = true;
                    }
                    else { 
                        cbnu.Checked = true;
                            }
                    txtngaysinh.Text = fields[3].Trim();
                    txtsdt.Text = fields[4].Trim();
                    txtdiachi.Text = fields[5].Trim();
                    cbmacs.Text = fields[6].Trim();
                    cbmalop.Text = fields[7].Trim();
                }
                else
                {
                    MessageBox.Show("Định dạng chuỗi không đúng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


    }
}
