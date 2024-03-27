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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace QLSinhViennhom5
{
    public partial class cn_sinhvien : Form
    {
          private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        Database db = new Database();
        public cn_sinhvien()
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

            dgv.Columns["masv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tensv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["gioitinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ngaysinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["sdt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["diachi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["macs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["malop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            string queryMaCS = "SELECT * FROM chinhsach";
            string queryMaLop = "SELECT * FROM lop";
          
            using (adapter = new SqlDataAdapter(queryMaCS, connection))
            {
                DataTable maCSTable = new DataTable();
                adapter.Fill(maCSTable);

               
                cbmacs.DataSource = maCSTable;
                cbmacs.DisplayMember = "macs"; 
                cbmacs.ValueMember = "macs";
            }

          
            using (adapter = new SqlDataAdapter(queryMaLop, connection))
            {
                DataTable maLopTable = new DataTable();
                adapter.Fill(maLopTable);

                
                cbmalop.DataSource = maLopTable;
                cbmalop.DisplayMember = "malop"; 
                cbmalop.ValueMember = "malop";
            }
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
        private void ClearTextBoxes()
        {
            txtmasv.Text = string.Empty;
            txttensv.Text = string.Empty;
            cbnam.Checked = false;
            cbnam.Checked = false;
            txtngaysinh.Value = DateTime.Now;
            txtsdt.Text = string.Empty;
            txtdiachi.Text = string.Empty;
           

        }
        private bool IsMaSVExists(string masv)
        {
            string query = "SELECT COUNT(*) FROM sinhvien WHERE masv = @masv";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@masv", masv);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return count > 0;
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmasv.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsMaSVExists(txtmasv.Text))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmasv.Text.Length > 10)
            {
                MessageBox.Show("Mã sinh viên không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                if( string.IsNullOrWhiteSpace(txttensv.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sinh Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!cbnam.Checked && !cbnu.Checked)
            {
                MessageBox.Show("Bạn chưa chọn giới tính nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gioitinh="";
            if (cbnam.Checked)
            {
                gioitinh = cbnam.Text;
            }
            else
            {
                gioitinh = cbnu.Text;
            }
        
            if (!DateTime.TryParse(txtngaysinh.Text, out DateTime enteredDate))
            {
                MessageBox.Show("Ngày sinh không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (enteredDate >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!long.TryParse(txtsdt.Text, out _))
            {
                MessageBox.Show("Số điện không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sdt = "";

          
            string phoneNumber = txtsdt.Text.Trim();

            if (!phoneNumber.StartsWith("0"))
            {
                if (phoneNumber.Length != 9)
                {
                    MessageBox.Show("Bạn phải nhập 9 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sdt += "0" + phoneNumber;
                }
            }
            else
            {
                if (phoneNumber.Length != 10)
                {
                    MessageBox.Show("Bạn phải nhập 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sdt += phoneNumber;
                }
            }


            if (  string.IsNullOrWhiteSpace(txtdiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if( cbmacs.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Mã Chính Sách hoặc Mã Chính Sách không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbmalop.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Mã lớp hoặc Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "INSERT INTO sinhvien (masv, tensv, gioitinh, ngaysinh, sdt, diachi, macs, malop) " +
                         "VALUES (@masv, @tensv, @gioitinh, @ngaysinh, @sdt, @diachi, @macs, @malop)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@masv", txtmasv.Text);
                command.Parameters.AddWithValue("@tensv", txttensv.Text);
                command.Parameters.AddWithValue("@gioitinh", gioitinh);
                command.Parameters.AddWithValue("@ngaysinh", txtngaysinh.Value);
                command.Parameters.AddWithValue("@sdt", sdt);
                command.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                command.Parameters.AddWithValue("@macs", cbmacs.SelectedValue.ToString()); 
                command.Parameters.AddWithValue("@malop", cbmalop.SelectedValue.ToString()); 

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            ClearTextBoxes();
            LoadData();

            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearTextBoxes();

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmasv.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
  
            if (txtmasv.Text.Length > 10)
            {
                MessageBox.Show("Mã sinh viên không được quá 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txttensv.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sinh Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!cbnam.Checked && !cbnu.Checked)
            {
                MessageBox.Show("Bạn chưa chọn giới tính nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gioitinh = "";
            if (cbnam.Checked)
            {
                gioitinh = cbnam.Text;
            }
            else
            {
                gioitinh = cbnu.Text;
            }

            if (!DateTime.TryParse(txtngaysinh.Text, out DateTime enteredDate))
            {
                MessageBox.Show("Ngày sinh không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (enteredDate >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!long.TryParse(txtsdt.Text, out _))
            {
                MessageBox.Show("Số điện không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sdt = "";


            string phoneNumber = txtsdt.Text.Trim();

            if (!phoneNumber.StartsWith("0"))
            {
                if (phoneNumber.Length != 9)
                {
                    MessageBox.Show("Bạn phải nhập 9 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sdt += "0" + phoneNumber;
                }
            }
            else
            {
                if (phoneNumber.Length != 10)
                {
                    MessageBox.Show("Bạn phải nhập 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sdt += phoneNumber;
                }
            }
            if (string.IsNullOrWhiteSpace(txtdiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbmacs.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Mã Chính Sách hoặc Mã Chính Sách không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbmalop.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Mã lớp hoặc Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string masv = txtmasv.Text;

            string query = "UPDATE sinhvien SET tensv = @tensv, gioitinh = @gioitinh, " +
                           "ngaysinh = @ngaysinh, sdt = @sdt, diachi = @diachi, " +
                           "macs = @macs, malop = @malop WHERE masv = @masv";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@masv", masv);
                command.Parameters.AddWithValue("@tensv", txttensv.Text);
                command.Parameters.AddWithValue("@gioitinh", gioitinh);
                command.Parameters.AddWithValue("@ngaysinh", txtngaysinh.Value);
                command.Parameters.AddWithValue("@sdt", sdt);
                command.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                command.Parameters.AddWithValue("@macs", cbmacs.SelectedValue.ToString()); 
                command.Parameters.AddWithValue("@malop", cbmalop.SelectedValue.ToString()); 

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            ClearTextBoxes();
            LoadData();
            MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearTextBoxes();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmasv.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh Viên để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgv.SelectedCells.Count > 0)
            {
              
                string masv = txtmasv.Text;

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên có mã " + masv + " không?",
                                                      "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM sinhvien WHERE masv = @masv";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@masv", masv);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    LoadData();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                }
            }
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
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
                cbmacs.SelectedValue = row.Cells["macs"].Value.ToString();
                cbmalop.SelectedValue = row.Cells["malop"].Value.ToString();
            }
        }

        private void cn_sinhvien_Load(object sender, EventArgs e)
        {
            txtmasv.Focus();
        }

        private void btnnhapqr_Click(object sender, EventArgs e)
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
                    if (cbnam.Text == fields[2].Trim())
                    {
                        cbnam.Checked = true;
                    }
                    else
                    {
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
