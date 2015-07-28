using CrystalDecisions.Shared;
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
            CrystalReport3 rp3 = new CrystalReport3();
            rp3.SetDataSource(ds);
            //ExportOptions exp=new ExportOptions();
            //exp.ExportFormatType = ExportFormatType.PortableDocFormat;

            rp3.SetParameterValue("Total_Lilies", p);
            rp3.SetParameterValue("Month", month);
            crystalReportViewer1.ReportSource = rp3;
            crystalReportViewer1.Refresh();
            
            
        }
    }
}
