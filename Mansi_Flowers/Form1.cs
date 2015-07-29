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
    public partial class Form1 : Form
    {
        public Form1()
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Maximized;
            
            InitializeComponent();
            
        }

        private void monthkyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View_Owners_Monthly().ShowDialog();
        }

        private void addOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Owner owner = new Add_Owner();
            owner.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void updateOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Owners owner = new View_Owners();
            owner.ShowDialog();
        }

        private void deleteOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_Owner owner = new Delete_Owner();
            owner.ShowDialog();
            
        }

        private void addUpdateLilisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //add_lilies.MdiParent=this;
            Add_Lilies newMDIChild = new Add_Lilies();
            //Form1 newMDIChild = new Form1();
            //newMDIChild.MdiParent = this;
            newMDIChild.ShowDialog();
            //this.LayoutMdi(MdiLayout.Cascade);
            //newMDIChild.Dock = DockStyle.Fill;
            //add_lilies.ShowDialog();
            
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void daysToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addEditRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Lilie_Rates().ShowDialog();
        }

        private void updateOwnerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            View_Owners owner = new View_Owners();
            owner.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void betweenDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View_Owners().ShowDialog();
        }

        private void liliEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void howToUseWithKeyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Howtouse().ShowDialog();
        }

        private void aboutUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About_US().ShowDialog();
        }
    }
}
