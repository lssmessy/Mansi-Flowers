namespace Mansi_Flowers
{
    partial class Rate_View
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Rate_tblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rate_dataset = new Mansi_Flowers.rate_dataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Rate_tblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate_dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // Rate_tblBindingSource
            // 
            this.Rate_tblBindingSource.DataMember = "Rate_tbl";
            this.Rate_tblBindingSource.DataSource = this.rate_dataset;
            // 
            // rate_dataset
            // 
            this.rate_dataset.DataSetName = "rate_dataset";
            this.rate_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Rate_tblBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.Rate_tblBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mansi_Flowers.Rate_rp.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 262);
            this.reportViewer1.TabIndex = 0;
            // 
            // Rate_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Rate_View";
            this.Text = "Rate_View";
            this.Load += new System.EventHandler(this.Rate_View_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rate_View_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Rate_tblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate_dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Rate_tblBindingSource;
        private rate_dataset rate_dataset;
        //private XSDs.rate_dataset rate_dataset;
    }
}