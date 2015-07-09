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
            Boolean success = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (isempty()==false) {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = ("INSERT INTO owner_master(OwnerName,Contact_Number,Address) VALUES ('" + dataGridView1.Rows[i].Cells["OwnerName"].Value + "','" + dataGridView1.Rows[i].Cells["Contact_Number"].Value + "','" + dataGridView1.Rows[i].Cells["Address"].Value + "')");
                    //cmd.CommandText = ("INSERT INTO owner_master(OwnerName,Contact_Number,Address) VALUES ('" + dataGridView1.Rows[i].Cells["OwnerName"].Value + "','" + dataGridView1.Rows[i].Cells["Contact_Number"].Value + "','" + dataGridView1.Rows[i].Cells["Address"].Value + "')");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    success = true;
                }
                else 
                {
                    MessageBox.Show("You can not leave blank data");
                    success = false;
                    break;
                }
                
            }
            if (success == true)
            {
                MessageBox.Show("Your data has been saved successfully");
                this.Close();
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
            dtbl = new DataTable();
            dtbl.Columns.Add("OwnerName");
            dtbl.Columns.Add("Contact_Number");
            dtbl.Columns.Add("Address");
            dataGridView1.DataSource = dtbl;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridView1.CurrentCell;
            //var cellDisplayRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            if (cell.ColumnIndex == 1)
            {
                toolTip1.Show("You can enter number only here", dataGridView1,
                          2000);
            }
            dataGridView1.ShowCellToolTips = false;
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
    }
}
