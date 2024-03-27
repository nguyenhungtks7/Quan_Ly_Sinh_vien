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
    public partial class In_giaovien : Form
    {
        public In_giaovien()
        {
            InitializeComponent();
        }

        private void In_giaovien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlSinhVienDataSet.giaovien' table. You can move, or remove it, as needed.
            this.giaovienTableAdapter.Fill(this.qlSinhVienDataSet.giaovien);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Close();

            }
        }
    }
}
