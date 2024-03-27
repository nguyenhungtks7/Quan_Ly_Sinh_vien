using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhViennhom5.Inchinhsach
{
    public partial class In_chinhsach : Form
    {
        public In_chinhsach()
        {
            InitializeComponent();
        }

        private void In_chinhsach_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlSinhVienDataSet.chinhsach' table. You can move, or remove it, as needed.
            this.chinhsachTableAdapter.Fill(this.qlSinhVienDataSet.chinhsach);

            this.reportViewer1.RefreshReport();
        }
    }
}
