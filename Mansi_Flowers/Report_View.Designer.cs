namespace Mansi_Flowers
{
    partial class Report_View
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.owners_Dataset = new Mansi_Flowers.XSDs.Owners_Dataset();
            this.ownersDatasetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.owner_tblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.owners_Dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownersDatasetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.owner_tblBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "owner_data";
            reportDataSource2.Value = this.owner_tblBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mansi_Flowers.Owners_view_rp.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(396, 262);
            this.reportViewer1.TabIndex = 0;
            // 
            // owners_Dataset
            // 
            this.owners_Dataset.DataSetName = "Owners_Dataset";
            this.owners_Dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ownersDatasetBindingSource
            // 
            this.ownersDatasetBindingSource.DataSource = this.owners_Dataset;
            this.ownersDatasetBindingSource.Position = 0;
            // 
            // owner_tblBindingSource
            // 
            this.owner_tblBindingSource.DataMember = "owner_tbl";
            this.owner_tblBindingSource.DataSource = this.owners_Dataset;
            // 
            // Report_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 262);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_View";
            this.Text = "Report_View";
            this.Load += new System.EventHandler(this.Report_View_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Report_View_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.owners_Dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownersDatasetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.owner_tblBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ownersDatasetBindingSource;
        private XSDs.Owners_Dataset owners_Dataset;
        private System.Windows.Forms.BindingSource owner_tblBindingSource;

    }
}