using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Store_Software
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }
        SqlConnection con = globals.cnstring;

        private void btnfetch_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            try
            {
                string q = "SELECT * FROM Invoices where usr like '%" + textBox1.Text + "%' and dat between'" + fromdt.Value.ToString() + "' and '" + todt.Value.ToString() + "'";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                SD.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["invno"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["customid"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["itemid"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["quantities"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["tim"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["dat"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["sub"].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dr["vat"].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = dr["discount"].ToString();
                    dataGridView1.Rows[n].Cells[9].Value = dr["total"].ToString();
                    dataGridView1.Rows[n].Cells[10].Value = dr["credit"].ToString();
                    dataGridView1.Rows[n].Cells[11].Value = dr["debit"].ToString();
                    dataGridView1.Rows[n].Cells[12].Value = dr["usr"].ToString();

                }
            }
            catch
            {
                MessageBox.Show("Please enter part of existing username which you want to view");
            }
            con.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnfetch_Click(this, new EventArgs());
            }
        }
    }
}
