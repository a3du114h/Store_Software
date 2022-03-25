using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Store_Software
{
    public partial class Total : Form
    {
        public Total()
        {
            InitializeComponent();
        }

        SqlConnection con = globals.cnstring;
        double yy = 0;
        double yyy=0;

        private void btnview_Click(object sender, EventArgs e)
        {
            double aw = 0, bw = 0, cw = 0, dw = 0, ew=0, fw=0;
            string bq = "", cq = "", dq = "", fq = "", eq = "";
            SqlCommand sqlCom = new SqlCommand("SELECT COUNT(*) FROM Invoices");
            sqlCom.Connection = con;

            aw = Convert.ToInt32(sqlCom.ExecuteScalar());
            string q = "SELECT * FROM invoices where dat between'" + fromdt.Value.ToString() + "' and '" + todt.Value.ToString() + "'";
            SqlDataAdapter SD = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SD.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                bq = dr["sub"].ToString();
                cq = dr["vat"].ToString();
                dq = dr["total"].ToString();
                eq = dr["credit"].ToString();
                fq = dr["debit"].ToString();
                bw = Convert.ToDouble(bq) + bw;
                cw = Convert.ToDouble(cq) + cw;
                dw = Convert.ToDouble(dq) + dw;
                ew = Convert.ToDouble(eq) + ew;
                fw = Convert.ToDouble(fq) + fw;
            }
            totinv.Text = aw.ToString();

            totpro.Text = bw.ToString();
            totsale.Text = dw.ToString();
            totvat.Text = cw.ToString();
            totbal.Text = ew.ToString();
            totdeb.Text = fw.ToString();
            con.Close();
        }

        private void Total_Load(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            try
            {
                SqlCommand cmn;
            cmn = con.CreateCommand();
            cmn.CommandType = CommandType.Text;
            cmn.CommandText = "SELECT name from Inventory";
            cmn.ExecuteNonQuery();
            DataTable dbt = new DataTable();
            SqlDataAdapter dqa = new SqlDataAdapter(cmn);
            dqa.Fill(dbt);
                foreach (DataRow dra in dbt.Rows)
                {
                    comboBox1.Items.Add(dra["Name"].ToString());

                }
            
            }
            catch
            {
                MessageBox.Show("It seems that there are Items in the data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            try
            {
                yy = 0;

                yyy = 0;

                SqlCommand cmn;
                cmn = con.CreateCommand();
                cmn.CommandType = CommandType.Text;
                cmn.CommandText = "SELECT * from items where name='" + comboBox1.Text + "' AND events ='Item Sold' AND dat between'" + fromdt.Value.ToString() + "' and '" + todt.Value.ToString() + "'";
                cmn.ExecuteNonQuery();
                DataTable dbt = new DataTable();
                SqlDataAdapter dqa = new SqlDataAdapter(cmn);
                dqa.Fill(dbt);

                foreach (DataRow dra in dbt.Rows)
                {
                    string xx = dra["quan"].ToString();
                    string zz = dra["prof"].ToString();
                    yy = Convert.ToDouble(xx) + yy;
                    yyy = Convert.ToDouble(zz) + yyy;

                }
                itemquan.Text = yy.ToString();
                itemprof.Text = yyy.ToString();
            }
            catch
            {
                MessageBox.Show("It seems that no such item was sold in this time frame!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
