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
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        private string p5;
        private string p6;
        private string p7;
        private string month;

        
        //public Bill_View(DataSet ds)
        //{
        //    // TODO: Complete member initialization
           
        //}

        //public Bill_View(DataSet ds, string p1, string p2, string p3, string p4, string p5, string p6, string p7)
        //{
        //    // TODO: Complete member initialization
           
        //    this.ds = ds;
        //    this.ds = ds;
        //    this.p1 = p1;
        //    this.p2 = p2;
        //    this.p3 = p3;
        //    this.p4 = p4;
        //    this.p5 = p5;
        //    this.p6 = p6;
        //    this.p7 = p7;
        //}

        public Bill_View(DataSet ds, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string month)
        {
            // TODO: Complete member initialization
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.ds = ds;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.p6 = p6;
            this.p7 = p7;
            this.month = month;
        }

        private void Bill_View_Load(object sender, EventArgs e)
        {
            Bill_per_User rp1 = new Bill_per_User();
            rp1.SetDataSource(ds);
            rp1.SetParameterValue("Name", p1);
            rp1.SetParameterValue("Total_Lilies", p2);
            rp1.SetParameterValue("Amount", p3);
            rp1.SetParameterValue("Rent", p4);
            rp1.SetParameterValue("Commission", p5);
            rp1.SetParameterValue("Total_Amount", p6);
            rp1.SetParameterValue("Roundoff_Amount", p7);
            rp1.SetParameterValue("Month", month);
            crystalReportViewer1.ReportSource = rp1;
            crystalReportViewer1.Refresh();

        }
    }
}
