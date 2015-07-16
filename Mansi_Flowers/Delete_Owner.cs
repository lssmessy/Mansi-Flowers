﻿using System;
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
    public partial class Delete_Owner : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String connectionString = Global_Connection.conn;
        public Delete_Owner()
        {
            conn = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
            int count = dataGridView1.SelectedRows.Count;
            if (count == 0)
            {
                MessageBox.Show("Please Select rows first!!", "Select rows", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete ?", "Delete Owners", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int owner_id = Int32.Parse(row.Cells[0].Value.ToString());

                        if (!row.IsNewRow)
                        {

                            dataGridView1.Rows.Remove(row);
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.CommandText = "DELETE FROM owner_master WHERE Owner_ID=" + owner_id + "";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "DELETE FROM lilie_master WHERE Owner_ID=" + owner_id + "";
                            cmd.ExecuteNonQuery();
                            conn.Close();


                        }
                    }
                    
                }
                else
                {

                }
            }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Delete_Owner_Load(object sender, EventArgs e)
        {
            try{
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            String query = "SELECT * FROM owner_master";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder commnder = new OleDbCommandBuilder(adapter);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                    dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
             
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //String searchText = ;
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dataGridView1.DataSource;
            //bs.Filter = "OwnerName like '%" + textBox1.Text + "%'";// OR Contact_Number LIKE '%" + searchText + "%' OR Address LIKE '%" + searchText + "%')";
            //dataGridView1.DataSource = bs;

            try{
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            String searchText = textBox1.Text;
            String query = "SELECT * FROM owner_master WHERE OwnerName LIKE '%" + searchText + "%' OR Contact_Number LIKE '%" + searchText + "%' OR Address LIKE '%" + searchText + "%'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder commnder = new OleDbCommandBuilder(adapter);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
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

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            try
            {
                int count = dataGridView1.Rows.Count;
                
                for (int i = 0; i < count; i++)
                {
                 
                    
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = ("UPDATE owner_master SET OwnerName='" + dataGridView1.Rows[i].Cells[1].Value + "',Contact_Number='" + dataGridView1.Rows[i].Cells[2].Value + "',Address='" + dataGridView1.Rows[i].Cells[3].Value + "' WHERE Owner_ID=" + dataGridView1.Rows[i].Cells[0].Value + "");//Owner_ID=" + dataGridView1.Rows[i].Cells[0].Value + " 
                    cmd.ExecuteNonQuery();
                    

                    conn.Close();
                }
                
                MessageBox.Show("Data updated", "Owner Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}
