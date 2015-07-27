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
    public partial class Bill : Form
    {
        private string owner;
        private int oid;
        
        private static String connectionString = Global_Connection.conn;
        

        SqlCeConnection conn = new SqlCeConnection(connectionString);
        SqlCeCommand cmd = new SqlCeCommand();

        DataSet ds=new DataSet();
        //public Bill()
        //{
        //    conn = new OleDbConnection(connectionString);
        //    InitializeComponent();
            
        //}

        public Bill(string owner, int oid)
        {
            // TODO: Complete member initialization
            //conn = new OleDbConnection(connectionString);
            InitializeComponent();
            this.owner = owner;
            this.oid = oid;
            //Load += Bill_Load;
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            try{
            int total_lilis = 0;
            double amount = 0.0;
            label2.Text = owner;
            String month = dateTimePicker1.Value.ToString("MM-yyyy");
            //ds = new DataSet();
            DataTable dtbl = new DataTable();
            
            dtbl.Columns.Add("Lilie_Date");
            dtbl.Columns.Add("Lilies");
            dtbl.Columns.Add("Rate");
            dtbl.Columns.Add("Amount");
            
            dtbl.Columns["Lilie_Date"].ReadOnly = true;
            dtbl.Columns["Lilies"].ReadOnly = true;
            dtbl.Columns["Rate"].ReadOnly = true;
            

            dataGridView1.DataSource = dtbl;
            dataGridView1.Refresh();

            String query1 = "SELECT Lilie_Date,Lilies,Rate FROM lilie_master WHERE (Owner_ID =" + oid + " AND OwnerName='" + owner + "'AND Lilie_Date LIKE '%" + month + "%' ) ORDER BY Lilie_Date ASC";// OwnerName,Lilie_Date,Lilies,Rate,Owner_ID // 
            //OleDbDataAdapter adapter = new OleDbDataAdapter(query1, conn);
            //OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);

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
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++) { 

                 if (int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out rates))
                 if (int.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out lilis))
                 
                 amount = (lilis * rates) / 1000.0;
                 dataGridView1.Rows[i].Cells[3].Value=amount;
                 total_lilis += lilis;
                 total_amount +=(double)amount;
                 dataGridView1.Rows[i].Cells["Amount"].ReadOnly = true;
                 

            }

            this.ds.Tables.Add(dtbl);
            this.ds.WriteXmlSchema("Bill.xml");
            rent = (total_lilis * 5) / 1000.0;
            commission = (total_amount * 15) / 100.0;
            final_amount = total_amount - rent - commission;

            var round_final = Math.Round(final_amount, MidpointRounding.AwayFromZero);

            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = ("UPDATE lilie_master SET Amount='" + round_final + "' WHERE (Owner_ID =" + oid + " AND OwnerName='" + owner + "'AND Lilie_Date LIKE '%" + month + "%' ) ");
            cmd.ExecuteNonQuery();
            conn.Close();
            this.label13.Text = round_final.ToString();
            this.label11.Text = final_amount.ToString();
            this.label9.Text = commission.ToString();
            this.label7.Text = rent.ToString();
            this.label3.Text = total_lilis.ToString();
            this.label5.Text = total_amount.ToString();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.PaleVioletRed;
            dataGridView1.EnableHeadersVisualStyles = false;    
                //ds.Tables.Add(dtbl);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try{
            int total_lilis = 0;
            double amount = 0.0;
            this.label2.Text = owner;
            String month = dateTimePicker1.Value.ToString("MM-yyyy");
            DataTable dtbl = new DataTable();
            
            
            dtbl.Columns.Add("Lilie_Date");
            dtbl.Columns.Add("Lilies");
            dtbl.Columns.Add("Rate");
            dtbl.Columns.Add("Amount");
            
            dtbl.Columns["Lilie_Date"].ReadOnly = true;
            dtbl.Columns["Lilies"].ReadOnly = true;
            dtbl.Columns["Rate"].ReadOnly = true;
            

            dataGridView1.DataSource = dtbl;
            dataGridView1.Refresh();

            String query1 = "SELECT Lilie_Date,Lilies,Rate FROM lilie_master WHERE (Owner_ID =" + oid + " AND OwnerName='" + owner + "'AND Lilie_Date LIKE '%" + month + "%' ) ORDER BY Lilie_Date ASC";// OwnerName,Lilie_Date,Lilies,Rate,Owner_ID // 
            //OleDbDataAdapter adapter = new OleDbDataAdapter(query1, conn);
            //OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);

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
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                if (int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out rates))
                    if (int.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out lilis))

                        amount = (lilis * rates) / 1000.0;
                dataGridView1.Rows[i].Cells[3].Value = amount;
                total_lilis += lilis;
                total_amount += (double)amount;
                
            }
            rent = (total_lilis * 5) / 1000.0;
            commission = (total_amount * 15) / 100.0;
            final_amount = total_amount - rent - commission;
            var round_final = Math.Round(final_amount, MidpointRounding.AwayFromZero);
            ds.Reset();
            ds.Tables.Add(dtbl);
            ds.WriteXmlSchema("Bill.xml");
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = ("UPDATE lilie_master SET Amount='" + round_final + "' WHERE (Owner_ID =" + oid + " AND OwnerName='" + owner + "'AND Lilie_Date LIKE '%" + month + "%' ) ");
            cmd.ExecuteNonQuery();
            conn.Close();

            this.label13.Text = round_final.ToString();

            this.label11.Text = final_amount.ToString();
            this.label9.Text = commission.ToString();
            this.label7.Text = rent.ToString();
            this.label3.Text = total_lilis.ToString();
            this.label5.Text = total_amount.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                button3.Enabled = true;
            }
            else if (dataGridView1.Rows.Count <= 0)
            {
                button3.Enabled = false;
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String month = dateTimePicker1.Value.ToString("MMMM-yyyy");
            new Bill_View(ds, label2.Text,label3.Text, label5.Text, label7.Text, label9.Text, label11.Text, label13.Text,month).ShowDialog();
            
            
        }
    }
}
