namespace QLSinhViennhom5.Inchinhsach
{
    partial class In_chinhsach
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
            this.chinhsachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chinhsachTableAdapter = new QLSinhViennhom5.QlSinhVienDataSetTableAdapters.chinhsachTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.qlSinhVienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chinhsachBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetChinhSach";
            reportDataSource1.Value = this.chinhsachBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLSinhViennhom5.Reportchinhsach.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(895, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // qlSinhVienDataSet
            // 
            this.qlSinhVienDataSet.DataSetName = "QlSinhVienDataSet";
            this.qlSinhVienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chinhsachBindingSource
            // 
            this.chinhsachBindingSource.DataMember = "chinhsach";
            this.chinhsachBindingSource.DataSource = this.qlSinhVienDataSet;
            // 
            // chinhsachTableAdapter
            // 
            this.chinhsachTableAdapter.ClearBeforeFill = true;
            // 
            // In_chinhsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "In_chinhsach";
            this.Text = "In_chinhsach";
            this.Load += new System.EventHandler(this.In_chinhsach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qlSinhVienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chinhsachBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private QlSinhVienDataSet qlSinhVienDataSet;
        private System.Windows.Forms.BindingSource chinhsachBindingSource;
        private QlSinhVienDataSetTableAdapters.chinhsachTableAdapter chinhsachTableAdapter;
    }
}