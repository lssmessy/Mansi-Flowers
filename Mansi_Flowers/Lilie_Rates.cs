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
        private DataTable dtbl;
        public Lilie_Rates()
        {
            conn = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void Lilie_Rates_Load(object sender, EventArgs e)
        {
            String month = dateTimePicker1.Value.ToString("MM-yyyy");
            List<String> dates = new List<string>();
            //List<int> rates = new List<int>();
            String date1;
            cmd.Connection = conn;
            conn.Open();
            //cmd.CommandText = ("CREATE VIEW rateview AS SELECT Lilie_Date,Rate FROM lilie_master WHERE Lilie_Date LIKE '%" + month + "%'");
            //String rView = (String)cmd.ExecuteScalar();

            cmd.CommandText = ("SELECT Lilie_Date,Rate FROM lilie_master WHERE Lilie_Date LIKE '%" + month + "%'");
            OleDbDataReader rd = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(rd);

            //int i = 0;
            //while (rd.Read())
            //{
                
            //    date1 = rd["Lilie_Date"].ToString();
            //    if (dates.Contains(date1))
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        dates.Add(date1);
            //        tbl.Rows[i].ItemArray[i].ToString();


            //    }

            //}

            conn.Close();

            //DataTable dt = ListToDataTable(dates);
            //tbl.Columns.Add("Lilie_Date");
            //tbl.Columns.Add("Rate");
            dataGridView1.DataSource = tbl;
            dataGridView1.Refresh();

            //String month = dateTimePicker1.Value.ToString("MM-yyyy");

            //dtbl = new DataTable();

            //dtbl.Columns.Add("Lilie_Date");
            //dtbl.Columns.Add("Rate");

            //dtbl.Columns["Lilie_Date"].ReadOnly = true;

            //dataGridView1.DataSource = dtbl;
            //dataGridView1.Refresh();
            //String query1 = "SELECT Lilie_Date,Rate FROM lilie_master WHERE Lilie_Date LIKE '%" + month + "%'";
            //OleDbDataAdapter adapter = new OleDbDataAdapter(query1, conn);
            //OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            //DataTable tbl = new DataTable();

            //adapter.Fill(dtbl);
            //for (int i = 0; i < tbl.Rows.Count; i++)
            //{

            //    dataGridView1.Rows.Add(dtbl.Rows[i][0], dtbl.Rows[i][1]);


            //}
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            String month = dateTimePicker1.Value.ToString("MM-yyyy");
            List<String> dates = new List<string>();

            String date1;
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = ("SELECT Lilie_Date,Rate FROM lilie_master WHERE Lilie_Date LIKE '%" + month + "%'");
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

                }
            }

            conn.Close();

            DataTable dt = ListToDataTable(dates);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }

        private static DataTable ListToDataTable(List<String> list)
        {

            DataTable table = new DataTable();
            // DateTime dtime;

            table.Columns.Add("Lilie_Date");
            table.Columns.Add("Rate");

            table.Columns["Lilie_Date"].ReadOnly = true;

            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }
            foreach (var array in list)
            {
                table.Rows.Add(array);
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
                //int lls = 0;
                //if (int.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out lls))


                cmd.CommandText = ("UPDATE lilie_master SET Rate='" + i + "' WHERE Lilie_Date =" + dts + "");
                cmd.ExecuteNonQuery();//dataGridView1.Rows[i].Cells["Rate"].Value
                conn.Close();
            }
            MessageBox.Show("Rates updated");
        }

    }

}
