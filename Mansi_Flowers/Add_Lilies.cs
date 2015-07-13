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
        List<String> ownernames = new List<string>();
        List<String> lili = new List<string>();
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
            try {
                
                cmd.Connection = conn;
                conn.Open();
                String query = "SELECT Owner_ID,OwnerName FROM owner_master";
                OleDbDataAdapter adp = new OleDbDataAdapter(query, conn);
                //OleDbCommandBuilder builder = new OleDbCommandBuilder(adp);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    
                    cmd.CommandText = ("SELECT COUNT(*) FROM lilie_master WHERE Owner_ID=" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "AND Lilie_Date LIKE '%" + theDate + "%'");
                    int cnt = (int)cmd.ExecuteScalar();
                    if (cnt != 1 && cnt==0) {
                    
                    cmd.CommandText = ("INSERT INTO lilie_master(Owner_ID,Lilie_Date,OwnerName) VALUES(" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ",'" + theDate + "','" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "')");
                    cmd.ExecuteNonQuery();
                    }

                 
                }
                conn.Close();
                //MessageBox.Show("inserted");

            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                dtbl = new DataTable();
                dtbl.Columns.Add("Owner_ID");
                dtbl.Columns.Add("OwnerName");
                dtbl.Columns.Add("Lilies");
                dtbl.Columns["Owner_ID"].ReadOnly = true;
                dtbl.Columns["OwnerName"].ReadOnly = true;
                dataGridView1.DataSource = dtbl;
                dataGridView1.Refresh();
                String query1 = "SELECT Owner_ID,OwnerName,Lilies FROM lilie_master WHERE Lilie_Date='" + theDate + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query1, conn);
                OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
                DataTable tbl = new DataTable();

                adapter.Fill(dtbl);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    dataGridView1.Rows.Add(dtbl.Rows[i][0], dtbl.Rows[i][1], dtbl.Rows[i][2]);


                }
            }
            catch (Exception exp) {
                MessageBox.Show(exp.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //try
            //{
                int count = dataGridView1.Rows.Count;
                string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                for (int i = 0; i < count; i++)
                {
                    //int oid = Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    //String oname = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    //int lilis = (int)dataGridView1.Rows[i].Cells[2].Value;
                    Random rm = new Random(100);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = ("UPDATE lilie_master SET Lilies='" + dataGridView1.Rows[i].Cells[2].Value + "' WHERE Owner_ID=" + dataGridView1.Rows[i].Cells[0].Value + " AND Lilie_Date =" + theDate + "");//(Lilie_Date ='" + theDate + "' AND 
                    cmd.ExecuteNonQuery();
                    //int s = (int)cmd.ExecuteScalar();
                    conn.Close();
                }
                MessageBox.Show("Data updated");
            //}
            //catch (Exception exp) {
            //    MessageBox.Show(exp.ToString());
            //}
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            try
            {
               
                cmd.Connection = conn;
                conn.Open();
                String query = "SELECT Owner_ID,OwnerName FROM owner_master";
                OleDbDataAdapter adp = new OleDbDataAdapter(query, conn);
                //OleDbCommandBuilder builder = new OleDbCommandBuilder(adp);
                DataSet ds = new DataSet();
                adp.Fill(ds);


                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    cmd.CommandText = ("SELECT COUNT(*) FROM lilie_master WHERE Owner_ID=" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "AND Lilie_Date='" + theDate + "'");//
                    int cnt = (int)cmd.ExecuteScalar();
                    if (cnt != 1 & cnt == 0)
                    {
            
                        cmd.CommandText = ("INSERT INTO lilie_master(Owner_ID,Lilie_Date,OwnerName) VALUES(" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ",'" + theDate + "','" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "')");
                        cmd.ExecuteNonQuery();
                        
                    }


                }
                conn.Close();
                //MessageBox.Show("After that");

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                dtbl = new DataTable();
                dtbl.Columns.Add("Owner_ID");
                dtbl.Columns.Add("OwnerName");
                dtbl.Columns.Add("Lilies");
                dtbl.Columns["Owner_ID"].ReadOnly = true;
                dtbl.Columns["OwnerName"].ReadOnly = true;
                dataGridView1.DataSource = dtbl;
                dataGridView1.Refresh();
                String query1 = "SELECT Owner_ID,OwnerName,Lilies FROM lilie_master WHERE Lilie_Date='" + theDate + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query1, conn);
                OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
                DataTable tbl = new DataTable();

                adapter.Fill(dtbl);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    dataGridView1.Rows.Add(dtbl.Rows[i][0], dtbl.Rows[i][1], dtbl.Rows[i][2]);


                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            

            //try
            //{
            //    string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            //    dtbl = new DataTable();
            //    dtbl.Columns.Add("Owner_ID");
            //    dtbl.Columns.Add("OwnerName");
            //    dtbl.Columns.Add("Lilies");
            //    dataGridView1.DataSource = dtbl;
            //    dataGridView1.Refresh();
            //    String query = "SELECT Owner_ID,OwnerName FROM lilie_master ";//WHERE Lilie_Date LIKE '%" + theDate + "%'";

            //    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            //    OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            //    DataTable tbl = new DataTable();

            //    cmd.Connection = conn;
            //    conn.Open();
            //    cmd.CommandText = "SELECT Lilies FROM lilie_master WHERE Lilie_Date=" + theDate + " ";
            //    OleDbDataReader rd = cmd.ExecuteReader();
            //    while (rd.Read())
            //    {
            //        lili.Add(rd[0].ToString());
            //    }

            //    conn.Close();
            //    //for lilies

            //    DataSet ds = new DataSet();

            //    adapter.Fill(dtbl);

            //    for (int i = 0; i < tbl.Rows.Count; i++)
            //    {
            //        dtbl.Rows[i][2] = lili[i];
            //        dataGridView1.Rows.Add(dtbl.Rows[i][0], dtbl.Rows[i][1], dtbl.Rows[i][2]);
            //        //cmd.Connection = conn;
            //        //conn.Open();
            //        //cmd.CommandText = ("INSERT INTO lilie_master(Lilie_Date,Owner_ID) VALUES('" + theDate + "'," + dtbl.Rows[i][0] + ")");
            //        //cmd.ExecuteNonQuery();
            //        //conn.Close();

            //    }
            //}
            //catch (Exception ex) {
            //    MessageBox.Show(ex.ToString());
                
            //}
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0,0,this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            
            
        }
    }
}
