﻿namespace QLSinhViennhom5.IN
{
    partial class In_Khoa
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.qlSinhVienDataSet = new QLSinhViennhom5.QlSinhVienDataSet();
            this.khoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khoaTableAdapter = new QLSinhViennhom5.QlSinhVienDataSetTableAdapters.khoaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.qlSinhVienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.khoaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLSinhViennhom5.ReportKhoa.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(768, 493);
            this.reportViewer1.TabIndex = 0;
            // 
            // qlSinhVienDataSet
            // 
            this.qlSinhVienDataSet.DataSetName = "QlSinhVienDataSet";
            this.qlSinhVienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khoaBindingSource
            // 
            this.khoaBindingSource.DataMember = "khoa";
            this.khoaBindingSource.DataSource = this.qlSinhVienDataSet;
            // 
            // khoaTableAdapter
            // 
            this.khoaTableAdapter.ClearBeforeFill = true;
            // 
            // In_Khoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 493);
            this.Controls.Add(this.reportViewer1);
            this.Name = "In_Khoa";
            this.Text = "In_Khoa";
            this.Load += new System.EventHandler(this.In_Khoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qlSinhVienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private QlSinhVienDataSet qlSinhVienDataSet;
        private System.Windows.Forms.BindingSource khoaBindingSource;
        private QlSinhVienDataSetTableAdapters.khoaTableAdapter khoaTableAdapter;
    }
}