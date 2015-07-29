using CrystalDecisions.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mansi_Flowers
{
    public partial class Daily_Total : Form
    {
        private DataSet ds;
        private string month;
        private string p;

        

        

        public Daily_Total(DataSet ds, string month, string p)
        {
            // TODO: Complete member initialization
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.ds = ds;
            this.month = month;
            this.p = p;
        }

        private void Daily_Total_Load(object sender, EventArgs e)
        {
            //CrystalReport3 rp3 = new CrystalReport3();
            //rp3.SetDataSource(ds);
            ////ExportOptions exp=new ExportOptions();
            ////exp.ExportFormatType = ExportFormatType.PortableDocFormat;

            //rp3.SetParameterValue("Total_Lilies", p);
            //rp3.SetParameterValue("Month", month);
            //crystalReportViewer1.ReportSource = rp3;
            //crystalReportViewer1.Refresh();
            
            ReportParameter total_liles = new ReportParameter("Total_Lilies", p);
            ReportParameter mnth = new ReportParameter("Month", month);
            this.Table1BindingSource.DataSource = ds;
            reportViewer1.LocalReport.SetParameters(total_liles);
            reportViewer1.LocalReport.SetParameters(mnth);
            reportViewer1.RefreshReport();
                        
        }

        private void Daily_Total_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Daily_Total_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
