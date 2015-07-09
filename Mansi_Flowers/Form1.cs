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

        }

        private void addOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Owner owner = new Add_Owner();
            owner.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Owners owner = new View_Owners();
            owner.ShowDialog();
        }
    }
}
