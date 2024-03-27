using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhViennhom5.IN
{
    public partial class In_SinhVien : Form
    {
        public In_SinhVien()
        {
            InitializeComponent();
        }

        private void In_SinhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlSinhVienDataSet.sinhvien' table. You can move, or remove it, as needed.
            this.sinhvienTableAdapter.Fill(this.qlSinhVienDataSet.sinhvien);

            this.reportViewer1.RefreshReport();
        }
    }
}
