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
using BCrypt.Net;


namespace QLSinhViennhom5
{
    public partial class FrmDangNhap : Form
    {
        public static string role = "";
        public static string tennguoidung = "";
        public static string matkhau = "";
        public static string tentaikhoan = "";
        SqlConnection sqlcon;
        int sai = 5;
        internal static readonly string kryMatkhau;

        public FrmDangNhap()
        {
            InitializeComponent();
            this.ActiveControl = UsernameTextBox;
        }
        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
               
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));

             
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                
                return builder.ToString() == hashedPassword;
            }
        }
        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();

                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng nhập tên người dùng và mật khẩu.", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    UsernameTextBox.Focus();    
                    return;
                }

                string getUserQuery = "SELECT mod, state, mk, fullname FROM login WHERE tk = @username";
                SqlCommand getUserCmd = new SqlCommand(getUserQuery, sqlcon);
                getUserCmd.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = getUserCmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    int mod = reader.GetInt32(0);
                    bool isAccountActive = reader.GetBoolean(1);
                    string hashedPasswordFromDB = reader.GetString(2);
                    string name = reader.GetString(3);
                    bool isPasswordCorrect = VerifyPassword(password, hashedPasswordFromDB);

                    if (isPasswordCorrect)
                    {
                        if (isAccountActive)
                        {
                         
                            this.Close();
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Man_chinh frm = new Man_chinh();

                            switch (mod)
                            {
                                case 1:
                                    role = "admin";
                                    break;
                                case 2:
                                    role = "gv";
                                    break;
                                case 3:
                                    role = "tk";
                                    break;
                                case 4:
                                    role = "user";
                                    break;
                                default:
                                    role = "khac";
                                    break;
                            }
                            tentaikhoan = username;
                            tennguoidung = name;
                            matkhau = password;
                            frm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản của bạn đã bị vô hiệu hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        sai--;

                        MessageBox.Show($"Tên đăng nhập hoặc mật khẩu sai! Bạn còn {sai + 1} lần đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UsernameTextBox.Clear();
                        PasswordTextBox.Clear();
                        UsernameTextBox.Focus();
                    }
                }
                else
                {
                    sai--;

                    MessageBox.Show($"Tên đăng nhập hoặc mật khẩu sai! Bạn còn {sai + 1} lần đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UsernameTextBox.Clear();
                    PasswordTextBox.Clear();
                    UsernameTextBox.Focus();
                }

                reader.Close();
                getUserCmd.Dispose();

                if (sai <= 0)
                {
                    MessageBox.Show("Bạn đã hết quyền đăng nhập! Tài khoản của bạn đã bị vô hiệu hóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Form1 frm = new Form1();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ketnoi()
        {
            try
            {
               
                string connectionString = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
                sqlcon = new SqlConnection(connectionString);

          
                sqlcon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối, kiểm tra tên server và tên cơ sở dữ liệu!\n" + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            UsernameTextBox.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                // Hiển thị mật khẩu (ẩn ký tự *)
                PasswordTextBox.PasswordChar = '\0';
            }
            else
            {
                // Ẩn mật khẩu (hiển thị ký tự *)
                PasswordTextBox.PasswordChar = '*';
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
