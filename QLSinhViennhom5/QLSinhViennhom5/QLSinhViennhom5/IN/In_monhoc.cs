﻿using System;
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
    public partial class In_monhoc : Form
    {
        public In_monhoc()
        {
            InitializeComponent();
        }

        private void In_monhoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlSinhVienDataSet.monhoc' table. You can move, or remove it, as needed.
            this.monhocTableAdapter.Fill(this.qlSinhVienDataSet.monhoc);

            this.reportViewer1.RefreshReport();
        }
    }
}
