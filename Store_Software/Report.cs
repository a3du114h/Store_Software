using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Software
{
    public partial class Report : Form
    {
        public Report()
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
            string q = "SELECT * FROM items where dat between'" + fromdt.Value.ToString() + "' and '" + todt.Value.ToString() + "'";
            SqlDataAdapter SD = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SD.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = n.ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr["name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr["events"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr["dat"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr["quan"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr["prof"].ToString();
 
            }
            con.Close();

        }

        private void rpt_Load(object sender, EventArgs e)
        {

        }
    }

}
