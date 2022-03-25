using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Store_Software
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection con = globals.cnstring;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcprice_TextChanged(object sender, EventArgs e)
        {

        }



        private void Customer_Load(object sender, EventArgs e)
        {

            Random rnd = new Random();
            int a = rnd.Next(1, 999999);
            totcode.Text = a.ToString();

        }
        private void btncreate_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO customer (code,name,contact1,contact2,address,email,pobox) VALUES ('" + totcode.Text + "','" + txtname.Text + "','" + txtcontact1.Text + "','" + txtcontact2.Text + "','" + txtadr.Text + "','" + txtmail.Text + "','" + txtpobox.Text + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted successfully");

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            con.Open();
            string q = "SELECT * FROM customer";
            SqlDataAdapter SD = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SD.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr["name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr["contact1"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr["address"].ToString();

            }
            con.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
            con.Open();
            string query = "UPDATE customer SET code='" + totcode.Text + "',contact1='" + txtcontact1.Text + "',contact2='" + txtcontact2.Text + "',address='" + txtadr.Text + "',email='" + txtpobox.Text + "',pobox='" + txtmail.Text + "' WHERE name ='" + txtname.Text + "' ";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated successfully");

            }
            catch
            {
                MessageBox.Show("It seems that the given Customer does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void totcode_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            con.Open();
            string q = "SELECT * FROM customer";
            SqlDataAdapter SD = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SD.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                totcode.Text = dr["code"].ToString();
                txtname.Text = dr["name"].ToString();
                txtcontact2.Text = dr["contact2"].ToString();
                txtpobox.Text = dr["email"].ToString();
                txtmail.Text = dr["pobox"].ToString();
                txtcontact1.Text = dr["contact1"].ToString();
                txtadr.Text = dr["address"].ToString();
            }
            con.Close();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to remove this customer?","Remove Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    string query = "DELETE FROM customer WHERE name ='" + txtname.Text + "'";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Customer not deleted.");
                }
            }
            catch
            {
                MessageBox.Show("It seems that the given Customer does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer main = new Customer();
            main.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void txtadr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void txtcontact1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtcontact1.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void txtcontact2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtcontact2.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void txtpobox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtpobox.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }
    }
}
