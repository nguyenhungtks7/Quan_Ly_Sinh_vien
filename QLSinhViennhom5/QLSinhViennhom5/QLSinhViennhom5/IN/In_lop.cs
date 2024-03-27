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
    public partial class In_lop : Form
    {
        public In_lop()
        {
            InitializeComponent();
        }

        private void In_lop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlSinhVienDataSet.lop' table. You can move, or remove it, as needed.
            this.lopTableAdapter.Fill(this.qlSinhVienDataSet.lop);

            this.reportViewer1.RefreshReport();
        }
    }
}
