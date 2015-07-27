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
            this.ds = ds;
            this.thedate = thedate;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.ds = ds;
        }

        private void Rate_View_Load(object sender, EventArgs e)
        {
            Rate_print rp = new Rate_print();

            rp.SetDataSource(ds);
            rp.SetParameterValue("Date", thedate);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }
    }
}
