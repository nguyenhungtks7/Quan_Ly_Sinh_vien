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
    public partial class FrmDangKy : Form
    {
        private SqlConnection sqlcon;
        public FrmDangKy()
        {
            InitializeComponent();
            this.ActiveControl = UsernameTextBox;
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {

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
                   string hoten = txthoten.Text;
                     string username = UsernameTextBox.Text;
                    string password = PasswordTextBox.Text;
                    string confirmPassword = Tbx_nhaplai.Text;
                if (string.IsNullOrWhiteSpace(hoten))
                {

                    MessageBox.Show("Vui lòng nhập Họ và tên.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txthoten.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(username))
                {
                   
                    MessageBox.Show("Vui lòng nhập tên người dùng.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    UsernameTextBox.Focus();
                    return;
                }    
                    if(string.IsNullOrWhiteSpace(password))
                {

                    MessageBox.Show("Vui lòng nhập  mật khẩu.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PasswordTextBox.Focus();
                    return;
                }
                if (password.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải lớn hơn 6 kí tư.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PasswordTextBox.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(confirmPassword))
                    {
                        MessageBox.Show("Vui lòng xác nhận lại mật khẩu.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Tbx_nhaplai.Focus();
                    return;
                }
           
                   if (password != confirmPassword)
                    {
                        MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Tbx_nhaplai.Focus();
                    return;
                }
                  
                        string checkUserQuery = "SELECT COUNT(*) FROM Login WHERE tk = @username";
                        SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, sqlcon);
                        checkUserCmd.Parameters.AddWithValue("@username", username);

                        int userCount = Convert.ToInt32(checkUserCmd.ExecuteScalar());
                        checkUserCmd.Dispose();

                        if (userCount > 0)
                        {
                            MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tên người dùng khác.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            string insertUserQuery = "INSERT INTO Login (tk, mk,fullname,mod, state ) VALUES (@username, @password, @name, @mod, @state)";
                            SqlCommand insertUserCmd = new SqlCommand(insertUserQuery, sqlcon);
                            insertUserCmd.Parameters.AddWithValue("@username", username);
                            insertUserCmd.Parameters.AddWithValue("@password", HashPassword(password));
                             insertUserCmd.Parameters.AddWithValue("@name", hoten);
                               insertUserCmd.Parameters.AddWithValue("@mod", 4);
                            insertUserCmd.Parameters.AddWithValue("@state", true);
                           insertUserCmd.ExecuteNonQuery();
                            insertUserCmd.Dispose();

                    DialogResult result = MessageBox.Show("Đăng Ký Thành Công. Bạn Muốn Đăng Nhập Không?", "Đăng ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        Close();
                        Form1 form = new Form1();
                        form.Show();

                    }
                    else
                    {

                        this.Close();
                        FrmDangNhap loginForm = new FrmDangNhap();
                        loginForm.Show();
                    }
                
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Close();
                Form1 form = new Form1();
                form.Show();
               
            }
          

        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                // Hiển thị mật khẩu (ẩn ký tự *)
                PasswordTextBox.PasswordChar = '\0';
                Tbx_nhaplai.PasswordChar = '\0';
            }
            else
            {
                // Ẩn mật khẩu (hiển thị ký tự *)
                PasswordTextBox.PasswordChar = '*';
                Tbx_nhaplai.PasswordChar = '*';
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Tbx_nhaplai_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
