using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhViennhom5
{
    public partial class Formdoimatkhau : Form
    {
        SqlConnection sqlcon;
   
        public Formdoimatkhau()
        {
            InitializeComponent();
            this.ActiveControl = txtmatkhaucu;
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtmatkhaucu.PasswordChar = txtmatkhaumoi.PasswordChar = txtxacnhanmatkhaumoi.PasswordChar =
           checkBoxShowPassword.Checked ? '\0' : '*';
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        public void ketnoi()
        {
            try
            {
                // Bước 1: Kết nối
                string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
                sqlcon = new SqlConnection(connectionString);

                // Bước 2: Mở kết nối
                sqlcon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối, kiểm tra tên server và tên cơ sở dữ liệu!\n" + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));


                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
            private void btnok_Click(object sender, EventArgs e)
        {
            try
            {

                ketnoi();
                string username = Man_chinh.tentaikhoan;
                string currentPassword = txtmatkhaucu.Text;
                if (string.IsNullOrWhiteSpace(currentPassword))
                {

                    MessageBox.Show("Vui lòng nhập  mật khẩu cũ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtmatkhaucu.Focus();
                    return;
                }
                if (txtmatkhaucu.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải lớn hơn 6 kí tư.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtmatkhaucu.Focus();
                    return;
                }
       
    
                bool isPasswordCorrect = false;

               
                    string query = $"SELECT COUNT(*) FROM Login WHERE tk = @username AND mk = @password";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", HashPassword(currentPassword));

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();

                    if (count > 0)
                    {
                        isPasswordCorrect = true;
                        
                    }
                

                if (!isPasswordCorrect)
                { 
                    MessageBox.Show("Bạn nhập sai mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmatkhaucu.Clear();
                    txtmatkhaucu.Focus();
                    return;
                }


                    string newPassword = txtmatkhaumoi.Text;
                string confirmPassword = txtxacnhanmatkhaumoi.Text;
                if (string.IsNullOrWhiteSpace(newPassword))
                {

                    MessageBox.Show("Vui lòng nhập  mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtmatkhaumoi.Focus();
                    return;
                }
                if (newPassword.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải lớn hơn 6 kí tư.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtmatkhaumoi.Focus();
                    return;
                }
                if (currentPassword == newPassword)
                {
                    MessageBox.Show("Mật khẩu mới không được giống mật khẩu cũ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtmatkhaumoi.Clear();
                    txtxacnhanmatkhaumoi.Clear();
                    txtmatkhaumoi.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(confirmPassword))
                {

                    MessageBox.Show("Vui lòng xác nhận mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtxacnhanmatkhaumoi.Focus();
                    return;
                }
            
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtxacnhanmatkhaumoi.Clear();
                    txtxacnhanmatkhaumoi.Focus();
                    return;
                }

                
                
                    string updateQuery = $"UPDATE Login SET mk = @newPassword WHERE tk = @username";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, sqlcon);
                    updateCmd.Parameters.AddWithValue("@username", username);
                    updateCmd.Parameters.AddWithValue("@newPassword", HashPassword(newPassword));

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    updateCmd.Dispose();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Mật khẩu đã được thay đổi thành công cho tài khoản {username}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                

                // Đóng cả hai form Man_Chinh và FormDoiMatKhau
                Man_chinh frmManChinh = Application.OpenForms.OfType<Man_chinh>().FirstOrDefault();
                Formdoimatkhau frmDoiMatKhau = Application.OpenForms.OfType<Formdoimatkhau>().FirstOrDefault();

                if (frmManChinh != null)
                    frmManChinh.Close();

                if (frmDoiMatKhau != null)
                    frmDoiMatKhau.Close();

                // Hiển thị Form1
                FrmDangNhap frm1 = new FrmDangNhap();
                frm1.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Formdoimatkhau_Load(object sender, EventArgs e)
        {
            txttentaikhoan.Text = Man_chinh.tentaikhoan;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
