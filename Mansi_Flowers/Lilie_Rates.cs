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
    public partial class Lilie_Rates : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String connectionString = Global_Connection.conn;
        //private DataTable dtbl;
        //int i = 0;
        public Lilie_Rates()
        {
            conn = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void Lilie_Rates_Load(object sender, EventArgs e)
        {
            try{
            String month = dateTimePicker1.Value.ToString("MM-yyyy");
            List<String> dates = new List<string>();
            List<DateRatePair> lstPairs = new List<DateRatePair>();
            String date1;
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = ("SELECT Lilie_Date,Rate FROM lilie_master WHERE Lilie_Date LIKE '%" + month + "%' ORDER BY Lilie_Date DESC");
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                date1 = rd["Lilie_Date"].ToString();
                if (dates.Contains(date1))
                {
                    continue;
                }
                else
                {
                    dates.Add(date1);
                    DateRatePair aPair = new DateRatePair();
                    aPair.Date = date1;
                    String b = aPair.Rate = rd["Rate"].ToString();
                    lstPairs.Add(aPair);

                }
            }

            conn.Close();

            DataTable dt = ListToDataTable(lstPairs);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
           
        }
       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try{
            String month = dateTimePicker1.Value.ToString("MM-yyyy");
            List<String> dates = new List<string>();
            List<DateRatePair> lstPairs = new List<DateRatePair>();
            String date1;
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = ("SELECT Lilie_Date,Rate FROM lilie_master WHERE Lilie_Date LIKE '%" + month + "%' ORDER BY Lilie_Date DESC");
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                date1 = rd["Lilie_Date"].ToString();
                if (dates.Contains(date1))
                {
                    continue;
                }
                else
                {
                    dates.Add(date1);
                    DateRatePair aPair = new DateRatePair();
                    aPair.Date = date1;
                    String b=aPair.Rate = rd["Rate"].ToString();
                    lstPairs.Add(aPair);

                }
            }

            conn.Close();

            DataTable dt = ListToDataTable(lstPairs);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private static DataTable ListToDataTable(List<DateRatePair> list)
        {
            
            DataTable table = new DataTable();
            // DateTime dtime;

            table.Columns.Add("Lilie_Date");
            table.Columns.Add("Rate");

            table.Columns["Lilie_Date"].ReadOnly = true;

            foreach (var array in list)
            {
                DataRow dr = table.NewRow();
                dr["Lilie_Date"] = array.Date;
                dr["Rate"] = array.Rate;
                table.Rows.Add(dr);
            }
            return table;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                cmd.Connection = conn;
                conn.Open();
                string dts = dataGridView1.Rows[i].Cells[0].Value.ToString();
                int rates = 0;
                if (int.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out rates))


                cmd.CommandText = ("UPDATE lilie_master SET Rate='" + rates + "' WHERE Lilie_Date ='" + dts + "'");
                cmd.ExecuteNonQuery();//dataGridView1.Rows[i].Cells["Rate"].Value
                conn.Close();
            }
            MessageBox.Show("Rates updated", "Rates", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{

        //}
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Contact_Number_Clicked);
            if (dataGridView1.CurrentCell.ColumnIndex == 1) //Desired Column
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


    }

}
