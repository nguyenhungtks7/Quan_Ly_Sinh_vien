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
    public partial class In_diem : Form
    {
        public In_diem()
        {
            InitializeComponent();
        }

        private void In_diem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlSinhVienDataSet.diem' table. You can move, or remove it, as needed.
            this.diemTableAdapter.Fill(this.qlSinhVienDataSet.diem);

            this.reportViewer1.RefreshReport();
        }
    }
}
