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
    public partial class Add_Lilies : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String connectionString = Global_Connection.conn;
        private DataTable dtbl;
        public Add_Lilies()
        {
            conn = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Lilies_Load(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dtbl = new DataTable();
            dtbl.Columns.Add("Owner_ID");
            dtbl.Columns.Add("OwnerName");
            dtbl.Columns.Add("Lilies");
            dataGridView1.DataSource = dtbl;
            //dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            String query = "SELECT Owner_ID,OwnerName,Lilies FROM lilie_master";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            DataTable tbl = new DataTable();
            DataSet ds = new DataSet();
            adapter.Fill(dtbl);
            for (int i = 0; i < tbl.Rows.Count; i++) {
                dataGridView1.Rows.Add(dtbl.Rows[i][0], dtbl.Rows[i][1],dtbl.Rows[i][2]);


            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            int count=dataGridView1.Rows.Count;
            dataGridView1.Rows[0].Cells[1].Value.GetType();
            string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            for (int i = 0; i < count; i++)
            {
                int oid = Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                String oname = dataGridView1.Rows[i].Cells[1].Value.ToString();
                

                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = ("INSERT INTO lilie_master(Lilies,Lili_Date,Owner_ID) VALUES(" + dataGridView1.Rows[i].Cells[2].Value + ", " + theDate + ", " + oid + ")");
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Data updated");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dtbl = new DataTable();
            dtbl.Columns.Add("Owner_ID");
            dtbl.Columns.Add("OwnerName");
            dtbl.Columns.Add("Lilies");
            dataGridView1.DataSource = dtbl;
            //dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            String query = "SELECT Owner_ID,OwnerName FROM owner_master";//,Lilies FROM lilie_master WHERE Lilie_Date=" + theDate + " ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            DataTable tbl = new DataTable();
            DataSet ds = new DataSet();
            
            adapter.Fill(dtbl);
            
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (adapter == null) {
                    dtbl.Rows[i][2] = "";
                }
                dataGridView1.Rows.Add(dtbl.Rows[i][0], dtbl.Rows[i][1], dtbl.Rows[i][2]);


            }
        }
    }
}
