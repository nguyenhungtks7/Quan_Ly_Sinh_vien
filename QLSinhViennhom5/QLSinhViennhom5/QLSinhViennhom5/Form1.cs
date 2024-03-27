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
    public partial class Form1 : Form
    {
        private SqlConnection sqlcon;
        private Timer timer;
        private string labelText = "Đại Học Kinh Tế Kỹ Thuật - Công Nghiệp          ";
        private int currentPosition = 0;
        public Form1()
        {
            InitializeComponent();
            label2.Text = labelText;
            label2.AutoSize = true;

            // Tạo một Timer và thiết lập sự kiện Tick
            timer = new Timer();
            timer.Interval = 100; // Thiết lập khoảng thời gian cập nhật (milliseconds)
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Di chuyển vị trí hiện tại của chữ trên Label
            currentPosition++;
            if (currentPosition > labelText.Length)
                currentPosition = 0;

            // Cập nhật Label với vị trí mới của chữ
            label2.Text = labelText.Substring(currentPosition) + labelText.Substring(0, currentPosition);
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
           
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
           
           this.Hide();
        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            FrmDangKy frm = new FrmDangKy();
            frm.Show();
           this.Hide();
        }

        private void btnthongtin_Click(object sender, EventArgs e)
        {
            string tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "\n";
            tt += "Version: 1.1 \n";
            tt += "\n";
            tt += "Học phần thực tập:\n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Copy right @ năm 2929 \n";
            tt += "Designer by: Nguyễn Phi Hùng \n";
            tt += "Email: nguyenphihung@gmail.com \n\n";
            MessageBox.Show((tt), "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result1 == DialogResult.OK)
            {
            
                Application.Exit();
            }
        }
            public void ketnoi()
        
            {
                try
                {
                    //Bước 1: Kết nối
                    string strkn;
                    strkn = "Data Source=DESKTOP-OF-THAN\\SQLEXPRESS;Initial Catalog=QlSinhVien;Integrated Security=True";
                    sqlcon = new SqlConnection();
                    sqlcon.ConnectionString = strkn;
                    //Bước 2: mở kết nối
                    sqlcon.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chưa kết nối được, Bạn kiểm tra lại tên server và tên cơ sở dữ liệu!", "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(ex.Message);
                }
            }

            private void label1_Click(object sender, EventArgs e)
        {
            string tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "\n";
            tt += "Version: 1.1 \n";
            tt += "\n";
            tt += "Học phần thực tập:\n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Copy right @ năm 2929 \n";
            tt += "Designer by: Nguyễn Phi Hùng \n";
            tt += "Email: nguyenphihung@gmail.com \n\n";
            MessageBox.Show((tt), "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
