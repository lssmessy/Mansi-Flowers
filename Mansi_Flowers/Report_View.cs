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

        public Report_View(DataSet ds)
        {
            // TODO: Complete member initialization
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.ds = ds;
        }

        private void Report_View_Load(object sender, EventArgs e)
        {
            CrystalReport2 rp2 = new CrystalReport2();
            rp2.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rp2;
            crystalReportViewer1.Refresh();
        }
    }
}
