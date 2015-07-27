using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlServerCe;
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
        //private OleDbConnection conn;
        //private OleDbCommand cmd = new OleDbCommand();
        //private String connectionString = Global_Connection.conn;

        private static String connectionString = Global_Connection.conn;
        //private DataTable dtbl;

        SqlCeConnection conn = new SqlCeConnection(connectionString);
        SqlCeCommand cmd = new SqlCeCommand();
        DataSet ds;
        public View_Owners()
        {
            //conn = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void View_Owners_Load(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                {
                    textBox1.Text = "Search by Owner, Contact or Address";
                }
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                String query = "SELECT * FROM owner_master ORDER BY Owner_ID ASC";
                //OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, conn);
                SqlCeCommandBuilder commnder = new SqlCeCommandBuilder(adapter);
                //OleDbCommandBuilder commnder = new OleDbCommandBuilder(adapter);
                DataTable dt = new DataTable();
                ds = new DataSet();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].Equals("1") && dt.Rows[i][1].Equals("2") && dt.Rows[i][3].Equals("")) { }
                    else
                    {
                        dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                    }
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("View_Owners.xml");
                DataGridViewButtonColumn view_owner = new DataGridViewButtonColumn();
                view_owner.Name = "View Owner";
                view_owner.Text = "View Bill";
                //view_owner.HeaderText = "View";
                view_owner.UseColumnTextForButtonValue = true;
                if (dataGridView1.Columns["View Owner"] == null)
                {
                    dataGridView1.Columns.Insert(4, view_owner);

                }
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.PaleVioletRed;
                dataGridView1.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Rows[1].Cells["View Bill"] = new DataGridViewTextBoxCell();
        }
        
    

        private void button1_Click(object sender, EventArgs e)
        {
            new Report_View(ds).ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try{
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            
            String searchText = textBox1.Text;
            String query = "SELECT * FROM owner_master WHERE OwnerName LIKE '%" + searchText + "%'";
            //OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            //OleDbCommandBuilder commnder = new OleDbCommandBuilder(adapter);
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, conn);
            SqlCeCommandBuilder commnder = new SqlCeCommandBuilder(adapter);
            DataTable dt = new DataTable();
            ds = new DataSet();
                
            adapter.Fill(dt);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                    dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                         
                
               
            }
            //for (int i = 0; i < dataGridView1.Rows.Count; i++) {
            //    dataGridView1.Rows[i].Cells[0].Value = ReadOnlyAttribute.Yes;
            //}
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                String searchText = textBox1.Text;
                String query = "SELECT * FROM owner_master WHERE Owner_ID LIKE '%" + searchText + "%' OR OwnerName LIKE '%" + searchText + "%' OR Contact_Number LIKE '%" + searchText + "%' OR Address LIKE '%" + searchText + "%'";
                //OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                //OleDbCommandBuilder commnder = new OleDbCommandBuilder(adapter);

                SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, conn);
                SqlCeCommandBuilder commnder = new SqlCeCommandBuilder(adapter);
                DataTable dt = new DataTable();
                ds = new DataSet();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //BindingSource bs = new BindingSource();
            //bs.DataSource = dataGridView1.DataSource;
            //bs.Filter = "OwnerName like '%" + textBox1.Text + "%' or Owner_ID like '%" + textBox1.Text + "%' or Address like '%" + textBox1.Text + "%'";
            //dataGridView1.DataSource = bs;
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
            try{
                if (e.RowIndex == -1 || e.ColumnIndex != 4)  // ignore header row and any column
                    return;                                  //  that doesn't have a file name


            if (dataGridView1.Columns[e.ColumnIndex].Name == "View Owner" )
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                
                //MessageBox.Show("You clicked me " +dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                String owner = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                int oid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //Bill bill = new Bill(owner,oid);
                Bill_Between_Dates bill = new Bill_Between_Dates(owner, oid);
                bill.ShowDialog();

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}
