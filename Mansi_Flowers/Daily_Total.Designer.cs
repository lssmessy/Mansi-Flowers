﻿namespace Mansi_Flowers
{
    partial class Daily_Total
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
            this.Table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NewDataSet = new Mansi_Flowers.NewDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Table1BindingSource
            // 
            this.Table1BindingSource.DataMember = "Table1";
            this.Table1BindingSource.DataSource = this.NewDataSet;
            // 
            // NewDataSet
            // 
            this.NewDataSet.DataSetName = "NewDataSet";
            this.NewDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "Daily_Rp";
            reportDataSource2.Value = this.Table1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mansi_Flowers.Daily_rp.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 262);
            this.reportViewer1.TabIndex = 0;
            // 
            // Daily_Total
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Daily_Total";
            this.Text = "Daily_Total";
            this.Load += new System.EventHandler(this.Daily_Total_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Daily_Total_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Daily_Total_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Table1BindingSource;
        private NewDataSet NewDataSet;
//        private XSDs.DailyDataSet dailyDataSet;

    }
}