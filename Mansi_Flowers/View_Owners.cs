using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mansi_Flowers
{
    public partial class View_Owners : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String connectionString = Global_Connection.conn;
        public View_Owners()
        {
            conn = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void View_Owners_Load(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                textBox1.Text = "Search by Owner, Contact or Address";
            }
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            String query = "SELECT * FROM owner_master";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder commnder = new OleDbCommandBuilder(adapter);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].Equals("1") && dt.Rows[i][1].Equals("2") && dt.Rows[i][3].Equals("")) { }
                else
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PrintDoc().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            String searchText = textBox1.Text;
            String query = "SELECT * FROM owner_master WHERE OwnerName LIKE '%" + searchText + "%'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder commnder = new OleDbCommandBuilder(adapter);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].Equals("1") && dt.Rows[i][1].Equals("2") && dt.Rows[i][3].Equals("")) { }
                else
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            String searchText = textBox1.Text;
            String query = "SELECT * FROM owner_master WHERE OwnerName LIKE '%" + searchText + "%' OR Contact_Number LIKE '%" + searchText + "%' OR Address LIKE '%" + searchText + "%'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder commnder = new OleDbCommandBuilder(adapter);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
                textBox1.Text = "";
            
        }

        private void textBox1_Move(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                
            }
        }

        private void textBox1_ControlRemoved(object sender, ControlEventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }
        private void SettingsGrid_MouseEnter(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
