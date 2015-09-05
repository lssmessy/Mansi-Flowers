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
        
        private static String connectionString = Global_Connection.conn;
        

        SqlCeConnection conn = new SqlCeConnection(connectionString);
        SqlCeCommand cmd = new SqlCeCommand();
        DataSet ds= new DataSet("Owners_Dataset");
        
        public View_Owners()
        {
            //conn = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void View_Owners_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;
            //dateTimePicker2.MinDate = dateTimePicker1.Value;
            try
            {
                if (textBox1.Text.Length < 1)
                {
                    textBox1.Text = "Search by Owner name";
                }
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                String query = "SELECT Owner_ID,OwnerName FROM owner_master ORDER BY Owner_ID ASC";
                
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, conn);
                SqlCeCommandBuilder commnder = new SqlCeCommandBuilder(adapter);
                
                DataTable dt = new DataTable();
                
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                        dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1]);
                
                    
                }
                dt.TableName = "owner_tbl";
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("Owners_view.xsd");
                DataGridViewButtonColumn view_owner = new DataGridViewButtonColumn();
                view_owner.Name = "View Owner";
                view_owner.Text = "View Bill";
                //view_owner.HeaderText = "View";
                view_owner.UseColumnTextForButtonValue = true;
                if (dataGridView1.Columns["View Owner"] == null)
                {
                    dataGridView1.Columns.Insert(2, view_owner);

                }
                DataGridViewButtonColumn print_bill = new DataGridViewButtonColumn();
                print_bill.Name = "Print";
                print_bill.Text = "Print Bill";
                //view_owner.HeaderText = "View";
                print_bill.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(3, print_bill);

                dataGridView1.Columns.Add("Column", "Amount");
                
                
                dataGridView1.Columns["OwnerName"].Width = 150;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.PaleVioletRed;
                dataGridView1.EnableHeadersVisualStyles = false;
                label3.Text = dataGridView1.RowCount.ToString();
                if (dataGridView1.Rows.Count > 0)
            {
                button1.Enabled = true;
            }
                else if (dataGridView1.Rows.Count <= 0)
                {
                    button1.Enabled = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    dataGridView1.Rows[1].Cells["View Bill"] = new DataGridViewTextBoxCell();
        //    dataGridView1.Rows[1].Cells["Print Bill"] = new DataGridViewTextBoxCell();

        //}
        
    

        private void button1_Click(object sender, EventArgs e)
        {
            new Report_View(ds,label3.Text).ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try{
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            
            String searchText = textBox1.Text;
            String query = "SELECT * FROM owner_master WHERE OwnerName LIKE '%" + searchText + "%'";
           
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, conn);
            SqlCeCommandBuilder commnder = new SqlCeCommandBuilder(adapter);
            DataTable dt = new DataTable();
                          
            adapter.Fill(dt);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                    dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                         
                
               
            }
           
                
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

                SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, conn);
                SqlCeCommandBuilder commnder = new SqlCeCommandBuilder(adapter);
                DataTable dt = new DataTable();

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

            //try
            //{
            //    if (textBox1.Text == "")
            //    {
            //    }
            //    else
            //    {
            //        BindingSource bs = new BindingSource();
            //        bs.DataSource = dataGridView1.DataSource;
            //        bs.Filter = "OwnerName like '%" + textBox1.Text + "%' or Owner_ID like '%" + textBox1.Text;
            //        dataGridView1.DataSource = bs;
            //    }
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.ToString());
            //}
            
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

       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            try{
                //if (e.RowIndex == -1 || e.ColumnIndex != 4)  // ignore header row and any column
                //    return;                                  //  that doesn't have a file name


                if (dataGridView1.Columns[e.ColumnIndex].Name == "View Owner")
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    //MessageBox.Show("You clicked me " +dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    String owner = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int oid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //Bill bill = new Bill(owner,oid);
                    
                    Bill_Between_Dates bill = new Bill_Between_Dates(owner, oid);
                    bill.ShowDialog();

                }
            
            if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name == "Print")
            {
                try
                {
                   //int oid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    int total_lilis = 0;
                    double amount = 0.0;
                    //label2.Text = owner;
                    string owner = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    String month = dateTimePicker1.Value.ToString("MM-yyyy");
                    String month1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                    String month2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
                    ds = new DataSet();
                    DataTable dtbl = new DataTable();

                    dtbl.Columns.Add("Lilie_Date");
                    dtbl.Columns.Add("Lilies");
                    dtbl.Columns.Add("Rate");
                    dtbl.Columns.Add("Amount");

                    dtbl.Columns["Lilie_Date"].ReadOnly = true;
                    dtbl.Columns["Lilies"].ReadOnly = true;
                    dtbl.Columns["Rate"].ReadOnly = true;


                    
                    dataGridView1.Refresh();

                    string oid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    String query1 = "SELECT Lilie_Date,Lilies,Rate FROM lilie_master WHERE (Owner_ID =" + oid + " AND Lilie_Date >= '" + month1 + "' AND Lilie_Date <= '" + month2 + "' ) AND Lilie_Date LIKE '%" + month + "%' ORDER BY Lilie_Date ASC";// AND OwnerName='" + owner + "'
                    
                    SqlCeDataAdapter adapter = new SqlCeDataAdapter(query1, conn);
                    SqlCeCommandBuilder cmdBuilder = new SqlCeCommandBuilder(adapter);
                    DataTable tbl = new DataTable();

                    adapter.Fill(dtbl);
                    int rates = 0;
                    int lilis = 0;
                    double total_amount = 0.0d;
                    double rent = 0.0d;
                    double commission = 0.0d;
                    double final_amount = 0.0d;
                    int row_count=dtbl.Rows.Count;
                    for (int i = 0; i <row_count ; i++)
                    {


                    

                        if (int.TryParse(dtbl.Rows[i].Field<string>("Rate").ToString(), out rates))

                            if (int.TryParse(dtbl.Rows[i].Field<string>("Lilies").ToString(), out lilis))

                                        

                        amount = (lilis * rates) / 1000.0;
                    
                        dtbl.Rows[i]["Amount"] = amount;
                    
                        total_lilis += lilis;
                        total_amount += (double)amount;
                    


                    }

                    ds.Tables.Add(dtbl);
                    ds.WriteXmlSchema("Bill.xml");
                    rent = (total_lilis * 5) / 1000.0;
                    commission = (total_amount * 15) / 100.0;
                    final_amount = total_amount - rent - commission;

                    var round_final = Math.Round(final_amount, MidpointRounding.AwayFromZero);
                    
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = ("UPDATE lilie_master SET Amount='" + round_final + "' WHERE (Owner_ID =" + oid + " AND OwnerName='" + owner + "'AND Lilie_Date LIKE '%" + month + "%' ) ");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    


                    String month_my = dateTimePicker1.Value.ToString("MMMM-yyyy");
                    //MessageBox.Show(oid);
                    new Bill_View(ds, owner, total_lilis.ToString(), total_amount.ToString(), rent.ToString(), commission.ToString(), final_amount.ToString(), round_final.ToString(), month_my,oid).ShowDialog();
                    //new Bill_View(ds, owner, total_lilis.ToString(), total_amount.ToString(), rent.ToString(), commission.ToString(), final_amount.ToString(), round_final.ToString(), month_my).ShowDialog();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewCellEventArgs e1 = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

            if (e.KeyCode == Keys.Enter)
            {

                dataGridView1_CellContentClick_1(sender, e1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
            
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                button3.Cursor = Cursors.WaitCursor;
                button3.Enabled = false;
                double bring_amount = 0.0;

                //String query = "SELECT Owner_ID,OwnerName FROM owner_master ORDER BY Owner_ID ASC";
                
                //SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, conn);
                //SqlCeCommandBuilder commnder = new SqlCeCommandBuilder(adapter);
                
                //DataTable dt = new DataTable();

                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    int total_lilis = 0;
                    double amount = 0.0;


                    String month = dateTimePicker1.Value.ToString("MM-yyyy");
                    String month1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                    String month2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
                    ds = new DataSet();
                    DataTable dtbl = new DataTable();

                    dtbl.Columns.Add("Lilie_Date");
                    dtbl.Columns.Add("Lilies");
                    dtbl.Columns.Add("Rate");
                    dtbl.Columns.Add("Amount");


                    //dataGridView1.Refresh();


                    String query1 = "SELECT Lilie_Date,Lilies,Rate FROM lilie_master WHERE (Owner_ID =" + dataGridView1.Rows[j].Cells[0].Value + " AND OwnerName='" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "'AND Lilie_Date >= '" + month1 + "' AND Lilie_Date <= '" + month2 + "' ) AND Lilie_Date LIKE '%" + month + "%' ORDER BY Lilie_Date ASC";// OwnerName,Lilie_Date,Lilies,Rate,Owner_ID // 

                    SqlCeDataAdapter adapter = new SqlCeDataAdapter(query1, conn);
                    SqlCeCommandBuilder cmdBuilder = new SqlCeCommandBuilder(adapter);
                    DataTable tbl = new DataTable();

                    adapter.Fill(dtbl);
                    int rates = 0;
                    int lilis = 0;
                    double total_amount = 0.0d;
                    double rent = 0.0d;
                    double commission = 0.0d;
                    double final_amount = 0.0d;

                    for (int i = 0; i < dtbl.Rows.Count; i++)
                    {

                        if (int.TryParse(dtbl.Rows[i].Field<string>("Rate").ToString(), out rates))

                            if (int.TryParse(dtbl.Rows[i].Field<string>("Lilies").ToString(), out lilis))

                                amount = (lilis * rates) / 1000.0;
                        dtbl.Rows[i]["Amount"] = amount;

                        total_lilis += lilis;
                        total_amount += (double)amount;

                        

                    }


                    //dataGridView1.Rows[i].Cells["Column"].Value = round_final;
                    //dataGridView1.CurrentRow.Cells["Column"].Value = round_final;
                    //ds.Tables.Add(dtbl);
                    //ds.WriteXmlSchema("Bill.xml");
                    rent = (total_lilis * 5) / 1000.0;
                    commission = (total_amount * 15) / 100.0;
                    final_amount = total_amount - rent - commission;

                    var round_final = Math.Round(final_amount, MidpointRounding.AwayFromZero);
                    dataGridView1.Rows[j].Cells["Column"].Value = round_final;
                    bring_amount += round_final;
                    //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    //{
                    //    rent = (total_lilis * 5) / 1000.0;
                    //    commission = (total_amount * 15) / 100.0;
                    //    final_amount = total_amount - rent - commission;

                    //    var round_final = Math.Round(final_amount, MidpointRounding.AwayFromZero);
                        
                    //}

                }

                label6.Text = bring_amount.ToString();
                button3.Cursor = Cursors.Default;
                button3.Enabled = true;
            }
            catch (Exception exp) {
                MessageBox.Show(exp.ToString());
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
