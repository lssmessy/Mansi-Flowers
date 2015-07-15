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
            DataGridViewButtonColumn view_owner = new DataGridViewButtonColumn();
            view_owner.Name = "View Owner";
            view_owner.Text = "View";
            //view_owner.HeaderText = "View";
            view_owner.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["View Owner"] == null) {
                dataGridView1.Columns.Insert(4, view_owner);
               
            }
        }
        void dataGridView1_DataBindingComplete(object sender,
    DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Rows[1].Cells["View"] = new DataGridViewTextBoxCell();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "View")
            {
                MessageBox.Show("You clicked me");
            }
        }
    //    private void dataGridView1_CellClick(object sender,
    //System.Windows.FormsDataGridViewCellEventArgs e)
    //    {
    //        if (DataGridView1.Columns[e.ColumnIndex].Name == "MyButton")
    //        {
    //            MessageBox.Show("You clicked me");
    //        }
    //    }

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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "View Owner" )
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                
                //MessageBox.Show("You clicked me " +dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                String owner = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                int oid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Bill bill = new Bill(owner,oid);
                bill.ShowDialog();

            }
        }
    }
}
