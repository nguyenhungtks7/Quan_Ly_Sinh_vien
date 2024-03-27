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
    public partial class In_Khoa : Form
    {
        public In_Khoa()
        {
            InitializeComponent();
        }

        private void In_Khoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlSinhVienDataSet.khoa' table. You can move, or remove it, as needed.
            this.khoaTableAdapter.Fill(this.qlSinhVienDataSet.khoa);

            this.reportViewer1.RefreshReport();
        }
    }
}
