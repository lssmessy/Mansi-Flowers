using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        private string owner_id;
        
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

        public Bill_View(DataSet ds, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string month,string owner_id)
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
            this.owner_id = owner_id;
        }

        private void Bill_View_Load(object sender, EventArgs e)
        {
            //Bill_per_User rp1 = new Bill_per_User();
            //rp1.SetDataSource(ds);
            //rp1.SetParameterValue("Name", p1);
            //rp1.SetParameterValue("Total_Lilies", p2);
            //rp1.SetParameterValue("Amount", p3);
            //rp1.SetParameterValue("Rent", p4);
            //rp1.SetParameterValue("Commission", p5);
            //rp1.SetParameterValue("Total_Amount", p6);
            //rp1.SetParameterValue("Roundoff_Amount", p7);
            //rp1.SetParameterValue("Month", month);
            //crystalReportViewer1.ReportSource = rp1;
            //crystalReportViewer1.Refresh();

            ReportParameter nme = new ReportParameter("Name", p1);
            ReportParameter ttl = new ReportParameter("Total_Lilies", p2);
            ReportParameter amt = new ReportParameter("Amount", p3);
            ReportParameter rnt = new ReportParameter("Rent", p4);
            ReportParameter commission = new ReportParameter("Commission", p5);
            ReportParameter ttl_amt = new ReportParameter("Total_Amount", p6);
            ReportParameter final = new ReportParameter("Final_Amount", p7);
            ReportParameter mnth = new ReportParameter("Month", month);
            ReportParameter oid = new ReportParameter("ID", owner_id);
            this.NewDataSetBindingSource.DataSource = ds;
            reportViewer1.LocalReport.SetParameters(nme);
            reportViewer1.LocalReport.SetParameters(ttl);
            reportViewer1.LocalReport.SetParameters(amt);
            reportViewer1.LocalReport.SetParameters(rnt);
            reportViewer1.LocalReport.SetParameters(commission);
            reportViewer1.LocalReport.SetParameters(ttl_amt);
            reportViewer1.LocalReport.SetParameters(final);
            reportViewer1.LocalReport.SetParameters(mnth);
            reportViewer1.LocalReport.SetParameters(oid);
            reportViewer1.RefreshReport();
            //setting the customized margins for the page
            System.Drawing.Printing.PageSettings rps = new System.Drawing.Printing.PageSettings();
            rps.Margins.Left = 96; //25.4 mm
            rps.Margins.Right = 96;
            rps.Margins.Top = 30;//7.9375 mm
            rps.Margins.Bottom = 19;//5.0 mm
                        
            reportViewer1.SetPageSettings(rps);

            
            this.reportViewer1.RefreshReport();
        }

        private void Bill_View_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
        }

        private void Bill_View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
