using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mansi_Flowers
{
    public partial class Delete_Owner : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String connectionString = Global_Connection.conn;
        public Delete_Owner()
        {
            conn = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;
            if (count == 0)
            {
                MessageBox.Show("Please Select rows first!!", "Select rows", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete ?", "Delete Owners", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        String owner = row.Cells[1].Value.ToString();

                        if (!row.IsNewRow)
                        {

                            dataGridView1.Rows.Remove(row);
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.CommandText = "DELETE FROM owner_master WHERE OwnerName='" + owner + "'";
                            cmd.ExecuteNonQuery();
                            conn.Close();


                        }
                    }
                    
                }
                else
                {

                }
            }
        }

        private void Delete_Owner_Load(object sender, EventArgs e)
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

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
