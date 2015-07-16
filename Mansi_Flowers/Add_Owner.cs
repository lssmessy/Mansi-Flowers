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
    public partial class Add_Owner : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private String connectionString = Global_Connection.conn;
        private DataTable dtbl;
        public Add_Owner()
        {
            conn = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
            Boolean success = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (isempty()==false) {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = ("INSERT INTO owner_master(OwnerName,Contact_Number,Address) VALUES ('" + dataGridView1.Rows[i].Cells["OwnerName"].Value + "','" + dataGridView1.Rows[i].Cells["Contact_Number"].Value + "','" + dataGridView1.Rows[i].Cells["Address"].Value + "')");
                    cmd.ExecuteNonQuery();
                    //cmd.CommandText=("SELECT `Owner_ID` FROM owner_master WHERE `OwnerName`='" + dataGridView1.Rows[i].Cells["OwnerName"].Value + "'");
                    //int oid=(int)cmd.ExecuteScalar();
                    //String owner_name = dataGridView1.Rows[i].Cells["OwnerName"].Value.ToString();
                    //cmd.CommandText=("INSERT INTO lilie_master(Owner_ID,OwnerName) VALUES('"+oid+"','"+owner_name+"')"); 
                    //cmd.ExecuteNonQuery();
                    
                    
                    conn.Close();
                    success = true;
                }
                else 
                {
                    MessageBox.Show("You can not leave blank data","Blank Data",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    success = false;
                    break;
                }
                
            }
            if (success == true)
            {
                MessageBox.Show("Your data has been saved successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                this.Close();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public Boolean isempty() {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                if (dataGridView1.Rows[i].Cells["Address"].Value.ToString() == "" && dataGridView1.Rows[i].Cells["Contact_Number"].Value.ToString() == "" && dataGridView1.Rows[i].Cells["OwnerName"].Value.ToString() == "") {
                    return true;
                    }
            }
            return false;
        }

        private void Add_Owner_Load(object sender, EventArgs e)
        {
            try
            {
                dtbl = new DataTable();
                dtbl.Columns.Add("OwnerName");
                dtbl.Columns.Add("Contact_Number");
                dtbl.Columns.Add("Address");
                dataGridView1.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow row = dtbl.NewRow();
            dtbl.Rows.Add(row);
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridView1.Rows.Remove(row);
                
            }
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {

        }
        private void SettingsGrid_MouseEnter(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }
    }
}
