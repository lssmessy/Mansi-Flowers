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
    public partial class Report_View : Form
    {
        private DataSet ds;
        private string p;

        //public Report_View(DataSet ds)
        //{
        //    // TODO: Complete member initialization
            
        //}

        public Report_View(DataSet ds, string p)
        {
            // TODO: Complete member initialization
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.ds = ds;
            this.p = p;
        }

        private void Report_View_Load(object sender, EventArgs e)
        {
            //CrystalReport2 rp2 = new CrystalReport2();
            //rp2.SetDataSource(ds);
            //crystalReportViewer1.ReportSource = rp2;
            //crystalReportViewer1.Refresh();
            ReportParameter total = new ReportParameter("Total", p);
            reportViewer1.LocalReport.SetParameters(total);
            this.owner_tblBindingSource.DataSource = ds;
            this.reportViewer1.RefreshReport();
        }

        private void Report_View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }
    }
}
