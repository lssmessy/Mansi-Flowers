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
    public partial class Rate_View : Form
    {
        private DataSet ds;
        private string thedate;

        public Rate_View(DataSet ds, string thedate)
        {
            // TODO: Complete member initialization
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.ds = ds;
            this.thedate = thedate;
        }

        private void Rate_View_Load(object sender, EventArgs e)
        {
            this.Rate_tblBindingSource.DataSource = ds;
            ReportParameter month = new ReportParameter("Month", thedate);
            reportViewer1.LocalReport.SetParameters(month);
            this.reportViewer1.RefreshReport();
        }
    }
}
