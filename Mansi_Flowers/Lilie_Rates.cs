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
        //private void GenerateUniqueData(int cellno)
        //{
        //    //Logic for unique names

        //    //Step 1:

        //    string initialnamevalue = dataGridView1.Rows[0].Cells[cellno].Value.ToString();

        //    //Step 2:        

        //    for (int i = 1; i < dataGridView1.Rows.Count; i++)
        //    {

        //        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == initialnamevalue)
        //            dataGridView1.Rows[i].Cells[0].Value= string.Empty;
        //        else
        //            initialnamevalue = dataGridView1.Rows[i].Cells[0].Value.ToString();
        //    }
        //}

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{

        //    String month = dateTimePicker1.Value.ToString("MM-yyyy");
        //    List<String> dates = new List<string>();
        //    List<String> rates = new List<string>();

        //    String date1;
        //    cmd.Connection = conn;
        //    conn.Open();
        //    cmd.CommandText = ("SELECT Lilie_Date,Rate FROM lilie_master WHERE Lilie_Date LIKE '%" + month + "%'");
        //    OleDbDataReader rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {

        //        date1 = rd["Lilie_Date"].ToString();
        //        if (dates.Contains(date1))
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            dates.Add(date1);
        //            rates.Add(rd["Rate"].ToString());
        //        }
        //    }

        //    conn.Close();

        //    DataTable dt = ListToDataTable(dates,rates);
        //    dataGridView1.DataSource = dt;
        //    dataGridView1.Refresh();

        //    //DataTable dt2 = new DataTable();
        //    //dt2.Columns.Add("Rate");
        //    //dataGridView1.DataSource = dt2;
        //    //dataGridView1.Refresh();
        //    //cmd.Connection = conn;
        //    //conn.Open();
        //    //String q1 = ("SELECT Rate FROM lilie_master WHERE Lilie_Date LIKE '%" + month + "%'");
        //    //OleDbDataAdapter adp = new OleDbDataAdapter(q1, conn);
        //    //adp.Fill(dt2);
        //    //conn.Close();

        //}

        //private static DataTable ListToDataTable(List<String> list, List<String> rate)
        //{

        //    DataTable table = new DataTable();
        //    // DateTime dtime;

        //    table.Columns.Add("Lilie_Date");
        //    table.Columns.Add("Rate");

        //    table.Columns["Lilie_Date"].ReadOnly = true;

        //    //int columns = 0;
        //    //foreach (var array in list)
        //    //{
        //    //    if (array.Length > columns)
        //    //    {
        //    //        columns = array.Length;
        //    //    }
        //    //}
        //    foreach (var array in list)
        //    {
        //        table.Rows.Add(array);
                
        //    }
        //    return table;
        //}

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

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

        private static DataTable ListToDataTable(List<DateRatePair> list)
        {

            DataTable table = new DataTable();
            // DateTime dtime;

            table.Columns.Add("Lilie_Date");
            table.Columns.Add("Rate");

            table.Columns["Lilie_Date"].ReadOnly = true;

            //int count = 0;
            //foreach (var array in list)
            //{
            //    if (array.Date != null)
            //    {
            //        count++;
            //    }
            //}
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
            MessageBox.Show("Rates updated");
        }

    }

}
