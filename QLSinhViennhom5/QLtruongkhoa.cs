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
    public partial class QLtruongkhoa : Form
    {
        Database db = new Database();
        SqlConnection connection;
        SqlCommand command;
        private string sql ;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public QLtruongkhoa()
        {
            InitializeComponent();
            this.ActiveControl = txthoten;
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Chuyển đổi mảng byte thành chuỗi hex
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
           

        }
        void reset()
        {
            txt_user.Text = "";
            txt_pass.Text = "";
            txthoten.Text = "";
            txtnothoatdong.Checked = false;
            txthoatdong.Checked = false;
            txthoten.Focus();
        }
        private void loaddata()
        {
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select tk, mk, fullname, state from Login where mod = 3";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
         
        }

        private void QLtruongkhoa_Load(object sender, EventArgs e)
        {
            sql = db.ConnectionString;
            connection = new SqlConnection(sql);
            connection.Open();
            loaddata();
            dgv.Columns["tk"].HeaderText = "Tài khoản";
            dgv.Columns["mk"].HeaderText = "Mật khẩu";
            dgv.Columns["fullname"].HeaderText = "Họ tên";
            dgv.Columns["state"].HeaderText = "Trạng Thái";

            dgv.Columns["tk"].Width = 200;
            dgv.Columns["mk"].Width = 150;
            dgv.Columns["fullname"].Width = 210;
            dgv.Columns["state"].Width = 120;


            dgv.Columns["tk"].HeaderCell.Style.Font = new Font("Times New Roman", 13, FontStyle.Bold);
            dgv.Columns["mk"].HeaderCell.Style.Font = new Font("Times New Roman", 13, FontStyle.Bold);
            dgv.Columns["fullname"].HeaderCell.Style.Font = new Font("Times New Roman", 13, FontStyle.Bold);
            dgv.Columns["state"].HeaderCell.Style.Font = new Font("Times New Roman", 13, FontStyle.Bold);

            dgv.Columns["tk"].DefaultCellStyle.Font = new Font("Times New Roman", 13, FontStyle.Regular);
            dgv.Columns["mk"].DefaultCellStyle.Font = new Font("Times New Roman", 13, FontStyle.Regular);
            dgv.Columns["fullname"].DefaultCellStyle.Font = new Font("Times New Roman", 13, FontStyle.Regular);

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
     
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
           
        }

        private void btndong_Click(object sender, EventArgs e)
        {
       
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
  
        }

        private void btnthem_Click_1(object sender, EventArgs e)
        {
            bool isValid = true;
            string checkQuery = "select count(*) from Login where tk = @tk";

            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@tk", txt_user.Text);
                int existingCount = (int)checkCommand.ExecuteScalar();
                if (existingCount > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_user.Focus();
                    isValid = false;
                    return;
                }

            }
            if (string.IsNullOrEmpty(txthoten.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_user.Focus();
                isValid = false;
                return;
            }
            if (string.IsNullOrEmpty(txt_user.Text))
            {
                MessageBox.Show("Bạn chưa nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_user.Focus();
                isValid = false;
                return;
            }
            if (string.IsNullOrEmpty(txt_pass.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_pass.Focus();
                isValid = false;
                return;
            }
            if (txt_pass.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải lớn hơn 6 kí tư.", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_pass.Focus();
                isValid = false;
                return;
            }
            if (!txthoatdong.Checked && !txtnothoatdong.Checked)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái nào.", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isValid = false;
                return;

            }
            int trangthai = 1;
            if (txthoatdong.Checked)
            {
                trangthai = 1;
            }
            else if (txtnothoatdong.Checked)
            {
                trangthai = 0;
            }
            if (isValid)
            {

                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Login (tk, mk,fullname,mod, state )values ('" + txt_user.Text + "',N'" + HashPassword(txt_pass.Text) + "',N'" + txthoten.Text + "',3," + trangthai + ")";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
                txt_user.ReadOnly = false;
                txt_pass.ReadOnly = false;
            }
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(txthoten.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_user.Focus();
                isValid = false;
                return;
            }
            if (string.IsNullOrEmpty(txt_user.Text))
            {
                MessageBox.Show("Bạn chưa nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_user.Focus();
                isValid = false;
                return;
            }
            if (!txthoatdong.Checked && !txtnothoatdong.Checked)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái nào.", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isValid = false;
                return;

            }
            int trangthai = 1;
            if (txthoatdong.Checked)
            {
                trangthai = 1;
            }
            else if (txtnothoatdong.Checked)
            {
                trangthai = 0;
            }
            if (isValid)
            {
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE Login SET  fullname =N'" + txthoten.Text + "', state=" + trangthai + " where tk = '" + txt_user.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Sửa thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
                txt_user.ReadOnly = false;
                txt_pass.ReadOnly = false;
            }
           
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_user.Text))
            {
                MessageBox.Show("Bạn chưa nhập tài khoản cần xóa");
                txt_user.Focus();
                return;
            }
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này  không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == r)
            {
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Login where tk = '" + txt_user.Text + "'";
                command.ExecuteNonQuery();
                MessageBox.Show("Bạn đã xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();
                reset();
                txt_user.ReadOnly = false;
                txt_pass.ReadOnly = false;
            }
           
        }

        private void btnnhaplai_Click_1(object sender, EventArgs e)
        {
            reset();
            txt_user.ReadOnly = false;
            txt_pass.ReadOnly = false;
        }

        private void btndong_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn thoát  không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == r)
            {
                Close();
            }
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgv.Rows[e.RowIndex];
                txt_user.Text = r.Cells[0].Value.ToString();
                txt_pass.Text = "********";
                txthoten.Text = r.Cells[2].Value.ToString();
                bool checktt = bool.Parse(r.Cells[3].Value.ToString());
                if (checktt == true)
                {
                    txthoatdong.Checked = true;

                }
                else
                {
                    txtnothoatdong.Checked = true;
                }
            }
            txt_user.ReadOnly = true;
            txt_pass.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txt_user.Text))
            {
                MessageBox.Show("Bạn phải nhập tài khoản để đặt lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_user.Focus();
                isValid = false;
                return;
            }
            int trangthai = 1;
            if (txthoatdong.Checked)
            {
                trangthai = 1;
            }
            else if (txtnothoatdong.Checked)
            {
                trangthai = 0;
            }
            if (isValid)
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn làm mới mật khẩu của tài khoản này  không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.Yes == r)
                {
                    command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "UPDATE Login SET mk =N'" + HashPassword("111111") + "' where tk = '" + txt_user.Text + "'";
                    command.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Làm mới tài khoản thành công với mật khẩu mới \"111111!\"", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    txt_user.ReadOnly = false;
                    txt_pass.ReadOnly = false;
                }
            }
          
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
  
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBoxShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                // Hiển thị mật khẩu (ẩn ký tự *)
                txt_pass.PasswordChar = '\0';
            }
            else
            {
                // Ẩn mật khẩu (hiển thị ký tự *)
                txt_pass.PasswordChar = '*';
            }
        }
    }
}
