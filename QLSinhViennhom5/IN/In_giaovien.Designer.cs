﻿namespace QLSinhViennhom5.IN
{
    partial class In_giaovien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(In_giaovien));
            this.giaovienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qlSinhVienDataSet = new QLSinhViennhom5.QlSinhVienDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.giaovienTableAdapter = new QLSinhViennhom5.QlSinhVienDataSetTableAdapters.giaovienTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.giaovienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlSinhVienDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // giaovienBindingSource
            // 
            this.giaovienBindingSource.DataMember = "giaovien";
            this.giaovienBindingSource.DataSource = this.qlSinhVienDataSet;
            // 
            // qlSinhVienDataSet
            // 
            this.qlSinhVienDataSet.DataSetName = "QlSinhVienDataSet";
            this.qlSinhVienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.giaovienBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLSinhViennhom5.Reportgiaovien.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(266, 107);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1568, 811);
            this.reportViewer1.TabIndex = 0;
            // 
            // giaovienTableAdapter
            // 
            this.giaovienTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1733, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // In_giaovien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "In_giaovien";
            this.Text = "In Giáo Viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.In_giaovien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.giaovienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlSinhVienDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private QlSinhVienDataSet qlSinhVienDataSet;
        private System.Windows.Forms.BindingSource giaovienBindingSource;
        private QlSinhVienDataSetTableAdapters.giaovienTableAdapter giaovienTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}