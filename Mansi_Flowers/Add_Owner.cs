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
    public partial class Add_Owner : Form
    {
        //private OleDbConnection conn;
        //private OleDbCommand cmd = new OleDbCommand();
        //private String connectionString = Global_Connection.conn;

        private static String connectionString = Global_Connection.conn;
        private DataTable dtbl;

        SqlCeConnection conn = new SqlCeConnection(connectionString);
        SqlCeCommand cmd = new SqlCeCommand();

       // private DataTable dtbl;
        public Add_Owner()
        {
            //conn = new OleDbConnection(connectionString);
            //cmd.Connection=co
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try{
            Boolean success = false;
    
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (isempty()==false) {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = ("INSERT INTO owner_master(OwnerName,Contact_Number,Address) VALUES (@owner_name,@contact,@address)");
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@owner_name", dataGridView1.Rows[i].Cells["OwnerName"].Value);
                    cmd.Parameters.AddWithValue("@contact", dataGridView1.Rows[i].Cells["Contact_Number"].Value);
                    cmd.Parameters.AddWithValue("@address", dataGridView1.Rows[i].Cells["Address"].Value);
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
            this.Cursor = Cursors.Default;
            this.Enabled = true;
            
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
                if (dataGridView1.Rows[i].Cells["OwnerName"].Value.ToString().Trim().Length==0) {
                    return true;
                }
            }
            return false;
        }

        private void Add_Owner_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                button1.Enabled = false;
                button4.Enabled = false;
            }
            try
            {
                dtbl = new DataTable();
                dtbl.Columns.Add("OwnerName");
                dtbl.Columns.Add("Contact_Number");
                dtbl.Columns.Add("Address");
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.PaleVioletRed;
                dataGridView1.EnableHeadersVisualStyles = false;
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
            dataGridView1.Columns["OwnerName"].Width = 170;
            dataGridView1.Columns["Contact_Number"].Width = 130;
            dataGridView1.Refresh();
            button1.Enabled = true;
            button4.Enabled = true;
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

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                button1.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            String s = dataGridView1.CurrentCell.Value.ToString();

            dataGridView1.CurrentCell.Value = (s.ToUpper()).ToString();
            
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) {
                button1.Enabled = true;
                button4.Enabled = true;
            }
        }

        
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteCellsIfNotInEditMode();
            }
        }
        private void DeleteCellsIfNotInEditMode()
        {
            if (!dataGridView1.CurrentCell.IsInEditMode)
            {
                foreach (DataGridViewCell selected_cell in dataGridView1.SelectedCells)
                {
                    selected_cell.Value = "";
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell.ColumnIndex==2)
            dataGridView1.BeginEdit(true);
        }
    }
}
