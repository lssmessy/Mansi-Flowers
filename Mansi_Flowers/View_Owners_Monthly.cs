﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mansi_Flowers
{
    public partial class View_Owners_Monthly : Form
    {
        private static String connectionString = Global_Connection.conn;
        

        SqlCeConnection conn = new SqlCeConnection(connectionString);
        SqlCeCommand cmd = new SqlCeCommand();
        DataSet ds = new DataSet("Owners_Dataset");
        public View_Owners_Monthly()
        {
            InitializeComponent();
        }

        private void View_Owners_Monthly_Load(object sender, EventArgs e)
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

                String query = "SELECT * FROM owner_master";
                
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, conn);
                SqlCeCommandBuilder commnder = new SqlCeCommandBuilder(adapter);
                
                DataTable dt = new DataTable();
                
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].Equals("1") && dt.Rows[i][1].Equals("2") && dt.Rows[i][3].Equals("")) { }
                    else
                    {
                        dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                    }
                }
                dt.TableName = "owner_tbl";
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("Owners_view.xsd");
                DataGridViewButtonColumn view_owner = new DataGridViewButtonColumn();
                view_owner.Name = "View Owner";
                view_owner.Text = "View Bill";
                
                view_owner.UseColumnTextForButtonValue = true;
                if (dataGridView1.Columns["View Owner"] == null)
                {
                    dataGridView1.Columns.Insert(4, view_owner);

                }
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
        void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Rows[1].Cells["View Bill"] = new DataGridViewTextBoxCell();
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
                //ds = new DataSet();
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
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void SettingsGrid_MouseEnter(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex != 4)  // ignore header row and any column
                    return;                                 
                if (dataGridView1.Columns[e.ColumnIndex].Name == "View Owner")
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    //MessageBox.Show("You clicked me " +dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    String owner = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int oid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //Bill bill = new Bill(owner,oid);
                    Bill bill = new Bill(owner, oid);
                    bill.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Report_View(ds,label3.Text).ShowDialog();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewCellEventArgs e1 = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

            if (e.KeyCode == Keys.Enter)
            {

                dataGridView1_CellContentClick(sender, e1);
            }
        }
    }
}
