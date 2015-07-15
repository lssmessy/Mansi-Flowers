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
    public partial class Bill : Form
    {
        private string owner;
        private int oid;
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String connectionString = Global_Connection.conn;
        //public Bill()
        //{
        //    conn = new OleDbConnection(connectionString);
        //    InitializeComponent();
            
        //}

        public Bill(string owner, int oid)
        {
            // TODO: Complete member initialization
            conn = new OleDbConnection(connectionString);
            InitializeComponent();
            this.owner = owner;
            this.oid = oid;
            //Load += Bill_Load;
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            String month = dateTimePicker1.Value.ToString("MM-yyyy");
            DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("Owner_ID");
            dtbl.Columns.Add("OwnerName");
            dtbl.Columns.Add("Lilie_Date");
            dtbl.Columns.Add("Lilies");
            dtbl.Columns.Add("Rate");
            dtbl.Columns.Add("Owner_ID");
            //dtbl.Columns["Owner_ID"].ReadOnly = true;
            dtbl.Columns["OwnerName"].ReadOnly = true;
            dtbl.Columns["Lilie_Date"].ReadOnly = true;

            dataGridView1.DataSource = dtbl;
            dataGridView1.Refresh();

            String query1 = "SELECT OwnerName,Lilie_Date,Lilies,Rate,Owner_ID FROM lilie_master WHERE (Owner_ID =" + oid + " AND OwnerName='" + owner + "' AND Lilie_Date LIKE '%"+month+"%') ORDER BY Lilie_Date ASC";// OwnerName,Lilie_Date,Lilies,Rate,Owner_ID 
            OleDbDataAdapter adapter = new OleDbDataAdapter(query1, conn);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            DataTable tbl = new DataTable();

            adapter.Fill(dtbl);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {


                dataGridView1.Rows.Add(dtbl.Rows[i][0], dtbl.Rows[i][1], dtbl.Rows[i][2], dtbl.Rows[i][3], dtbl.Rows[i][4]);


            }

            //DataTable dt = new DataTable();
            //dt.Columns.Add("OwnerName");
            //dt.Columns.Add("Lilie_Date");
            //dt.Columns.Add("Lilies");
            //dt.Columns.Add("Rate");

            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            //dataGridView1.DataSource = dt;
            //String query = "SELECT * FROM lilie_master";
            ////String query = "SELECT OwnerName,Lilie_Date,Lilies,Rate FROM lilie_master WHERE (Owner_ID=" + oid + " AND OwnerName='" + owner + "')";
            //OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            ////OleDbCommandBuilder commnder = new OleDbCommandBuilder(adapter);
                        
            //DataSet ds = new DataSet();
            //adapter.Fill(dt);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //    dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                
            //}
            
        }
    }
}
