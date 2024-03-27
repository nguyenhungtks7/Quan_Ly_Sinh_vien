using QLSinhViennhom5.quanly;
using QLSinhViennhom5.Thong_Tin;
using QLSinhViennhom5.TimKiem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace QLSinhViennhom5
{
    public partial class Man_chinh : Form
    {
        private Timer timer;
        public static string tentaikhoan;
        public static string kryMatkhau;
        private string labelText = "";
        private int currentPosition = 0;
        private CultureInfo culture;
    
        public Man_chinh()
        {
            InitializeComponent();

      

  

            labelText += "Xin chào, " + FrmDangNhap.tennguoidung + "                            ";
            lblTenTaiKhoan.Text = labelText;

            lblTenTaiKhoan.AutoSize = true;

            // Tạo một Timer và thiết lập sự kiện Tick
            timer = new Timer();
            timer.Interval = 100; // Thiết lập khoảng thời gian cập nhật (milliseconds)
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
      
        }

        private void cậpNhậtPhầnMềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang sử dụng phiên bản mới nhất!", "Thông báo", MessageBoxButtons.OK);
        }

        private void painToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Windows/system32/mspaint.exe");
        }

        private void cmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Windows/system32/cmd.exe");
        }

        private void nodepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Windows/system32/notepad.exe");
        }

        private void máyTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Windows/system32/calc.exe");
        }

        private void microsoftWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE");
        }

        private void quảnLýTàiKhoảnAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLAdmin frm = new QLAdmin();
            frm.Show();
        }

        private void quảnLýTàiKhoảnUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLuser frm = new QLuser();
            frm.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn thoát  không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == r)
            {
                //Application.Exit();
                Close();

                FrmDangNhap frm = new FrmDangNhap();
                frm.Show();
            }
        }

        private void Ts_btndangnhap_Click(object sender, EventArgs e)
        {
            Close();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
        }

        internal static void show()
        {
            throw new NotImplementedException();
        }
 

        private void admin_Load(object sender, EventArgs e)
        {
            UpdateLabelText();




            toolStripStatusLabel1.Text = "Hà Nội, ngày " + DateTime.Now.ToString("dd/MM/yyyy") +
                " - Bây giờ là " + DateTime.Now.ToString("hh: mm: ss tt");
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer2_Tick;
            timer.Start();
            if (FrmDangNhap.role.Contains("admin"))
            {
            


            }
            if (FrmDangNhap.role.Contains("gv"))
            {
                Ts_btn_quanly.Visible = false;
                Ts_btndangnhap.Visible = false;
                Ts_btn_admin.Visible = false;
                Ts_btn_user.Visible = false;
                Ts_btn_gv.Visible = false;
                Ts_btn_truongkhoa.Visible = false;
                
            }
            if (FrmDangNhap.role.Contains("tk"))
            {
                Ts_btn_quanly.Visible = false;
                Ts_btndangnhap.Visible = false;
                Ts_btn_admin.Visible = false;
                Ts_btn_user.Visible = false;
                Ts_btn_gv.Visible = false;
                Ts_btn_truongkhoa.Visible = false;
                Ts_btn_diem.Visible = false;
            }
            if (FrmDangNhap.role.Contains("user"))
            {
                Ts_btn_quanly.Visible = false;
                Ts_btndangnhap.Visible = false;
                Ts_btn_admin.Visible = false;
                Ts_btn_user.Visible = false;
                Ts_btn_gv.Visible = false;
                Ts_btn_truongkhoa.Visible = false;
                Ts_btn_diem.Visible = false;
            }
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Ts_btn_hienthi_kieuxem_trongsuot_Click(object sender, EventArgs e)
        {

        }

        private void Ts_btn_hienthi_kieuxem_trongsuot_100_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.45;
         
        }

        private void Ts_btn_hienthi_kieuxem_trongsuot_50_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.8;
        }

        private void Ts_btn_hienthi_kieuxem_macdinh_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void Ts_btn_hienthi_ngonngu_tiengviet_Click(object sender, EventArgs e)
        {
            SetLanguage("vi-VN");
        }
        private void SetLanguage(string cultureName)
        {
            culture = CultureInfo.CreateSpecificCulture(cultureName);
            ResourceManager rm = new ResourceManager("QLSinhViennhom5.Langg.MyResource", typeof(Man_chinh).Assembly);
            đăngNhậpToolStripMenuItem.Text = rm.GetString("hethong", culture);
            Ts_btndangnhap.Text = rm.GetString("dangnhap", culture);
            Ts_btn_admin.Text = rm.GetString("quanlyad", culture);
            Ts_btn_truongkhoa.Text = rm.GetString("quanlytruongkhoa", culture);
            Ts_btn_gv.Text = rm.GetString("quanlygvien", culture);
            Ts_btn_user.Text = rm.GetString("quanlyuser", culture);
            Ts_btn_khoa.Text = rm.GetString("quanlytruongkhoa", culture);
            Ts_btn_doimatkhau.Text = rm.GetString("thaydoipass", culture);
            Ts_btn_dangxuat.Text = rm.GetString("dangxuatt", culture);
            Ts_btn_thoat.Text = rm.GetString("thoat", culture);
            Ts_btn_thongtinkhoa.Text = rm.GetString("phongkhoa", culture);
            Ts_btn_thongtin_giaovien.Text = rm.GetString("giaovien", culture);
            Ts_btn_thongtin_lop.Text = rm.GetString("diem", culture);
            Ts_btn_khoa.Text = rm.GetString("khoa", culture);
            Ts_btn_thongtin_monhoc.Text = rm.GetString("monhoc", culture);
            Ts_btn_thongtin_chinhsach.Text = rm.GetString("chinhsach", culture);
            Ts_btn_timkiem.Text = rm.GetString("timkiem", culture);
            Ts_btn_timkiem_khoa_giaovien.Text = rm.GetString("giaovien", culture);
            Ts_btn_timkiem_khoa.Text = rm.GetString("phongkhoa", culture);
            Ts_btn_timkiem_lop.Text = rm.GetString("lop", culture);
            Ts_btn_thongtin_lop.Text = rm.GetString("lop", culture);
            Ts_btn_timkiem_khoa_sinhvien.Text = rm.GetString("sinhvien", culture);
            Ts_btn_timkiem_khoa_monhoc.Text = rm.GetString("monhoc", culture);
            Ts_btn_timkiem_khoa_chinhsach.Text = rm.GetString("chinhsach", culture);
            Ts_btn_diem.Text = rm.GetString("diem", culture);
            Ts_btn_quanly.Text = rm.GetString("quanly", culture);
            Ts_btn_quanly_khoa.Text = rm.GetString("phongkhoa", culture);
            Ts_btn_quanly_giaovien.Text = rm.GetString("giaovien", culture);
            Ts_btn_quanly_lop.Text = rm.GetString("lop", culture);
            Ts_btn_quanly_sinhvien.Text = rm.GetString("sinhvien", culture);
            Ts_btn_quanly_monhoc.Text = rm.GetString("monhoc", culture);
            Ts_btn_quanly_chinhsach.Text = rm.GetString("chinhsach", culture);
            Ts_btn_quanly_diem.Text = rm.GetString("diem", culture);
            Ts_btn_hienthi.Text = rm.GetString("hienthi", culture);
            Ts_btn_hienthi_kieuxem.Text = rm.GetString("kieuxem", culture);
            Ts_btn_hienthi_ngonngu.Text = rm.GetString("ngonngu", culture);
            Ts_btn_hienthi_ngonngu_tiengviet.Text = rm.GetString("tiengviet", culture);
            Ts_btn_hienthi_ngonngu_tienganh.Text = rm.GetString("tienganh", culture);
            Ts_btn_hienthi_kieuxem_trongsuot.Text = rm.GetString("trongsuot", culture);
            Ts_btn_hienthi_kieuxem_macdinh.Text = rm.GetString("macdinh", culture);
            Ts_btn_tienich.Text = rm.GetString("tienich", culture);
            Ts_btn_tienich_maytinh.Text = rm.GetString("maytinh", culture);
            Ts_btn_hotro.Text = rm.GetString("hotro", culture);
            Ts_btn_hotro_lienhe.Text = rm.GetString("lienhe", culture);
            Ts_btn_hotro_thongtin.Text = rm.GetString("thongtin", culture);
            Ts_btn_hotro_capnhatphanmen.Text = rm.GetString("capnhappm", culture);
            Ts_btn_thongtin.Text = rm.GetString("thongtin", culture);
            Ts_btn_thongtin_sinhvien.Text = rm.GetString("sinhvien", culture);
            Ts_btn_tienich.Text = rm.GetString("tienich", culture); 


        }
        private void UpdateLabelText()
        {
            if (Ts_btn_hienthi_ngonngu_tiengviet.Text == "Tiếng Việt")
            {
                labelText = "Xin chào, " + FrmDangNhap.tennguoidung + "                            ";
            }
            else
            {
                labelText = "Hello, " + FrmDangNhap.tennguoidung + "                            ";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateLabelText();
            currentPosition++;
            if (currentPosition > labelText.Length)
                currentPosition = 0;

            lblTenTaiKhoan.Text = labelText.Substring(currentPosition) + labelText.Substring(0, currentPosition);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
     
            if (Ts_btn_hienthi_ngonngu_tiengviet.Text == "Tiếng Việt")
            {
                toolStripStatusLabel1.Text = "Hôm nay là ngày " + DateTime.Now.ToString("dd/MM/yyyy") +
                 " - Bây giờ là " + DateTime.Now.ToString("hh: mm: ss tt");
            }
            else
            {
                toolStripStatusLabel1.Text = "Today " + DateTime.Now.ToString("dd/MM/yyyy") +
                 " - Now " + DateTime.Now.ToString("hh: mm: ss tt");
            }

            //toolStripStatusLabel1.Text = this.Text.Substring(1, this.Text.Length - 1) + this.Text.Substring(0, 1);
            //toolStripStatusLabel1.Text = this.Text.Substring(1, this.Text.Length - 1) + this.Text.Substring(0, 1);
        }

        private void Ts_btn_dangxuat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất  không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == r)
            {
                Close();

                MessageBox.Show("Đăng xuất thành công.", "Thông báo", MessageBoxButtons.OK);
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
                //Close();

                //FrmDangNhap frm = new FrmDangNhap();
                //frm.Show();
            }
        }

        private void Ts_btn_hotro_lienhe_Click(object sender, EventArgs e)
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

        private void Ts_btn_hotro_thongtin_Click(object sender, EventArgs e)
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

        private void Ts_btn_doimatkhau_Click(object sender, EventArgs e)
        {
            Formdoimatkhau frm = new Formdoimatkhau();
            tentaikhoan = FrmDangNhap.tentaikhoan;
            kryMatkhau = FrmDangNhap.matkhau;
            frm.Show();
        }

        private void Ts_btn_hienthi_ngonngu_tienganh_Click(object sender, EventArgs e)
        {
            SetLanguage("en-US");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Ts_btn_gv_Click(object sender, EventArgs e)
        {
            QLgiaovien frm = new QLgiaovien();
            frm.Show();
        }

        private void Ts_btn_truongkhoa_Click(object sender, EventArgs e)
        {
            QLtruongkhoa frm = new QLtruongkhoa();
            frm.Show();
        }

        private void Ts_btn_thongtinkhoa_Click(object sender, EventArgs e)
        {
            tt_khoa tt_Khoa = new tt_khoa();
            tt_Khoa.Show();
        }

        private void Ts_btn_thongtin_giaovien_Click(object sender, EventArgs e)
        {
            tt_giaovien tt_Giaovien = new tt_giaovien();
            tt_Giaovien.Show();
        }

        private void Ts_btn_thongtin_lop_Click(object sender, EventArgs e)
        {
            tt_lop tt_Lop = new tt_lop();
            tt_Lop.Show();
        }

        private void Ts_btn_thongtin_sinhvien_Click(object sender, EventArgs e)
        {
            tt_sinhvien frm = new tt_sinhvien();
            frm.Show();
        }

        private void Ts_btn_thongtin_monhoc_Click(object sender, EventArgs e)
        {
            tt_monhoc frm = new tt_monhoc();
            frm.Show();
        }

        private void Ts_btn_thongtin_chinhsach_Click(object sender, EventArgs e)
        {
            tt_chinhsach frm = new tt_chinhsach();
            frm.Show();
        }

        private void Ts_btn_thongtin_diem_Click(object sender, EventArgs e)
        {
            tt_diemsv frm = new tt_diemsv();    
            frm.Show();
        }

        private void Ts_btn_timkiem_khoa_giaovien_Click(object sender, EventArgs e)
        {
            frm_TimKiem_GiaoVien frm = new frm_TimKiem_GiaoVien();
            frm.Show();
      
        }

        private void Ts_btn_timkiem_khoa_Click(object sender, EventArgs e)
        {
            frm_TimKiem_Khoa frm = new frm_TimKiem_Khoa();
            frm.Show();
        }

        private void Ts_btn_timkiem_lop_Click(object sender, EventArgs e)
        {
            frm_TimKiem_Lop frm = new frm_TimKiem_Lop();
            frm.Show();
        }

        private void Ts_btn_timkiem_khoa_sinhvien_Click(object sender, EventArgs e)
        {
            frm_TimKiem_SinhVien frm = new frm_TimKiem_SinhVien();
            frm.Show();
        }

        private void Ts_btn_timkiem_khoa_monhoc_Click(object sender, EventArgs e)
        {
            frm_TimKiem_MonHoc frm = new frm_TimKiem_MonHoc();
            frm.Show();

        }

        private void Ts_btn_timkiem_khoa_chinhsach_Click(object sender, EventArgs e)
        {
            frm_TimKiem_ChinhSach frm = new frm_TimKiem_ChinhSach();
            frm.Show(); 
        }

        private void Ts_btn_diem_Click(object sender, EventArgs e)
        {
            cn_diemsv frm = new cn_diemsv();
            frm.Show();
        }

        private void Ts_btn_quanly_khoa_Click(object sender, EventArgs e)
        {
            cn_khoa frm = new cn_khoa();
            frm.Show();
        }

        private void Ts_btn_quanly_giaovien_Click(object sender, EventArgs e)
        {
            cn_giaovien frm = new cn_giaovien();
            frm.Show();
        }

        private void Ts_btn_quanly_lop_Click(object sender, EventArgs e)
        {
            cn_lop frm = new cn_lop();
            frm.Show();
        }

        private void Ts_btn_quanly_sinhvien_Click(object sender, EventArgs e)
        {
            cn_sinhvien frm= new cn_sinhvien();
            frm.Show();
        }

        private void Ts_btn_quanly_monhoc_Click(object sender, EventArgs e)
        {
            cn_monhoc frm = new cn_monhoc();
            frm.Show();
        }

        private void Ts_btn_quanly_chinhsach_Click(object sender, EventArgs e)
        {
            cn_chinhsach frm = new cn_chinhsach();
            frm.Show();
        }

        private void Ts_btn_quanly_diem_Click(object sender, EventArgs e)
        {
      
            cndiem frm = new cndiem();
            frm.Show();
        }
    }
}
