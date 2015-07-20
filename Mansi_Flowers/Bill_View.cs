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
    public partial class Bill_View : Form
    {
        private DataSet ds;

        
        public Bill_View(DataSet ds)
        {
            // TODO: Complete member initialization
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.ds = ds;
        }

        private void Bill_View_Load(object sender, EventArgs e)
        {
            Bill_per_User rp1 = new Bill_per_User();
            rp1.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rp1;
            crystalReportViewer1.Refresh();

        }
    }
}
