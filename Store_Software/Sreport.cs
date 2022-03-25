using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace Store_Software
{
    public partial class Sreport : Form
    {
        public Sreport()
        {
            InitializeComponent();
        }
        SqlConnection con = globals.cnstring;

        private void Sreport_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            string q = "SELECT * FROM invoices where dat between'" + fromdt.Value.ToString() + "' and '"+ todt.Value.ToString() +"'";
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
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            preview.Document = print;
            preview.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            print.Print();

        }

        private void print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);

            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
