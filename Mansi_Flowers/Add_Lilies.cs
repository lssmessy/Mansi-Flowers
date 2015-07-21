using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mansi_Flowers
{
    public partial class Add_Lilies : Form
    {
        //private OleDbConnection conn;
        //private OleDbCommand cmd = new OleDbCommand();
        private static String connectionString = Global_Connection.conn;
        private DataTable dtbl;
        DataSet ds;
        SqlCeConnection conn = new SqlCeConnection(connectionString);
        SqlCeCommand cmd = new SqlCeCommand();

        List<String> ownernames = new List<string>();
        List<String> lili = new List<string>();
        public Add_Lilies()
        {
            //conn = new OleDbConnection(connectionString);
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Lilies_Load(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dateTimePicker1.MaxDate = DateTime.Today;
            int rate = 0;
            try {
                
                cmd.Connection = conn;
                conn.Open();
                String query = "SELECT Owner_ID,OwnerName FROM owner_master";
                SqlCeDataAdapter adp = new SqlCeDataAdapter(query, conn);
                //OleDbDataAdapter adp = new OleDbDataAdapter(query, conn);
                //OleDbCommandBuilder builder = new OleDbCommandBuilder(adp);
                ds = new DataSet();
                adp.Fill(ds);

                
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    
                    cmd.CommandText = ("SELECT COUNT(*) FROM lilie_master WHERE Owner_ID=" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "AND Lilie_Date LIKE '%" + theDate + "%'");
                    int cnt = (int)cmd.ExecuteScalar();
                    if (cnt != 1 && cnt==0) {
                       
                    cmd.CommandText = ("INSERT INTO lilie_master(Owner_ID,Lilie_Date,OwnerName,Rate) VALUES(" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ",'" + theDate + "','" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "','"+rate+"')");
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
                String query1 = "SELECT Owner_ID,OwnerName,Lilies FROM lilie_master WHERE Lilie_Date='" + theDate + "' ORDER BY Owner_ID ASC";
                //OleDbDataAdapter adapter = new OleDbDataAdapter(query1, conn);
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(query1, conn);
                //OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
                SqlCeCommandBuilder cmdBuilder = new SqlCeCommandBuilder(adapter);
                DataTable tbl = new DataTable();
                
                adapter.Fill(dtbl);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    

                    dataGridView1.Rows.Add(dtbl.Rows[i][0], dtbl.Rows[i][1], dtbl.Rows[i][2]);

                    
                }
                ds.Tables.Add(dtbl);
                ds.WriteXmlSchema("Lilies_By_Day.xml");
                dataGridView1.Columns[1].Width = 170;
                //dataGridView1.Rows[0].Cells[0].Selected = false;
                //dataGridView1.Rows[0].Cells[2].Selected = true;
                dataGridView1.KeyPress += OnDataGirdView1_KeyPress;

            }
            catch (Exception exp) {
                MessageBox.Show(exp.ToString());
            }
            
        }
        private void OnDataGirdView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
                //e.Handled = true; if you don't want the datagrid from hearing the enter pressed
            }
        }
        private void SettingsGrid_MouseEnter(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            int total = 0;
            try
            {
                int count = dataGridView1.Rows.Count;
                string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                for (int i = 0; i < count; i++)
                {
                    //int lls = int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    int lls = 0;
                    if (int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out lls))

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = ("UPDATE lilie_master SET Lilies='" + lls + "' WHERE (Lilie_Date ='" + theDate + "' AND Owner_ID=" + dataGridView1.Rows[i].Cells[0].Value + ")");//Owner_ID=" + dataGridView1.Rows[i].Cells[0].Value + " 
                    cmd.ExecuteNonQuery();
                    //total += int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());   
                    total += lls;
                    
                    conn.Close();
                }
                label2.Text = total.ToString();
                MessageBox.Show("Data updated","Lilies",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                this.Enabled = true;
            }
            catch (Exception exp) {
                MessageBox.Show(exp.ToString());
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


            int total = 0;
            string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            try
            {
               
                cmd.Connection = conn;
                conn.Open();
                String query = "SELECT Owner_ID,OwnerName FROM owner_master";
                //OleDbDataAdapter adp = new OleDbDataAdapter(query, conn);
                SqlCeDataAdapter adp = new SqlCeDataAdapter(query, conn);
                //OleDbCommandBuilder builder = new OleDbCommandBuilder(adp);
                ds = new DataSet();
                adp.Fill(ds);


                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    cmd.CommandText = ("SELECT COUNT(*) FROM lilie_master WHERE Owner_ID=" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "AND Lilie_Date='" + theDate + "'");//
                    int cnt = (int)cmd.ExecuteScalar();
                    if (cnt != 1 & cnt == 0)
                    {
                        int s = 0;
                        cmd.CommandText = ("INSERT INTO lilie_master(Owner_ID,Lilie_Date,OwnerName,Lilies) VALUES(" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ",'" + theDate + "','" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "',"+s+")");
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
                //OleDbDataAdapter adapter = new OleDbDataAdapter(query1, conn);
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(query1, conn);
                SqlCeCommandBuilder cmdBuilder = new SqlCeCommandBuilder(adapter);
                //OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
                DataTable tbl = new DataTable();
                
                adapter.Fill(dtbl);

                int count = dataGridView1.Rows.Count;

                for (int i = 0; i <tbl.Rows.Count; i++)
                {

                    dataGridView1.Rows.Add(dtbl.Rows[i][0], dtbl.Rows[i][1], dtbl.Rows[i][2]);
                    //dataGridView1.Rows.Add(dst.Tables[0].Rows[i].ItemArray[0]);


                }
                ds.Tables.Add(dtbl);
                ds.WriteXmlSchema("Lilies_By_Day.xml");
                int lls = 0;
                
                for (int i = 0; i < count; i++)
                {
                    if (int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out lls))
                        total += lls;
                }
                label2.Text = total.ToString();


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            

           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0,0,this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string month = dateTimePicker1.Value.ToString("dd-MMMM-yyyy");
            new Daily_Total(ds, month, label2.Text).ShowDialog();
            
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "OwnerName like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = bs;
           
            
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Contact_Number_Clicked);
            if (dataGridView1.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Contact_Number_Clicked);
                }
            }

        }
        private void Contact_Number_Clicked(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int total = 0;
            int count = dataGridView1.Rows.Count;
            int lls = 0;
            for (int i = 0; i < count; i++)
            {
                if (int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out lls))
                    total += lls;

                
                
            }
            label2.Text = total.ToString();
            string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = ("UPDATE lilie_master SET Lilies='" + dataGridView1.CurrentRow.Cells[2].Value + "' WHERE (Lilie_Date ='" + theDate + "' AND Owner_ID=" + dataGridView1.CurrentRow.Cells[0].Value + ")");
            cmd.ExecuteNonQuery();
            conn.Close();
            //int rowIndex = dataGridView1.CurrentCell.RowIndex;

            //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            
        }

        

        
    }
}
