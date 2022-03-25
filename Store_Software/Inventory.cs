using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Store_Software
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();

        }
        SqlConnection con = globals.cnstring;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int a = rnd.Next(1, 999999);
            totcode.Text = a.ToString();

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Merchandise")
            {
                con.Open();
                string q = "SELECT * FROM inventory";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                SD.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["code"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["name"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["stock"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["total"].ToString();

                }
                con.Close();
            }
            else if (comboBox1.Text == "Service") {
                con.Open();
                string q = "SELECT * FROM inventory_tax";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                SD.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["code"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["name"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["govt"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["credit"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["Total"].ToString();

                }
                con.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox1.Text == "Service")
            {
                string uery = "SELECT count(*) FROM Inventory_tax WHERE name = '" + txtname.Text + "'";
                SqlDataAdapter DA = new SqlDataAdapter(uery, con);
                DataTable dt = new DataTable();
                DA.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Service already exists. Please update the service or create a new one with different name.");
                }
                else
                {
                    string query = "INSERT INTO Inventory_tax (code,name,govt,credit,vat,total) VALUES ('" + totcode.Text + "','" + txtname.Text + "','" + txtcprice.Text + "','" + txtsprice.Text + "','" + totvat.Text + "','" + tottotal.Text + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    string que = "INSERT INTO items (name,quan,dat,events) VALUES ('" + txtname.Text + "','" + txtstock.Text + "','"+ DateTime.Now.ToString()+"','Item Created')";
                    SqlDataAdapter SD = new SqlDataAdapter(que, con);
                    SD.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Inserted successfully");
                }
            }
            else if(comboBox1.Text=="Merchandise"){
                string uery = "SELECT count(*) FROM Inventory WHERE name = '" + txtname.Text + "'";
            SqlDataAdapter DA = new SqlDataAdapter(uery, con);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Item already present in the inventory. Please update the item or create a new one with different name.");
            }
            else
            {
                string query = "INSERT INTO Inventory (code,name,cprice,sprice,stock,profit,vat,total) VALUES ('" + totcode.Text + "','" + txtname.Text + "','" + txtcprice.Text + "','" + txtsprice.Text + "','" + txtstock.Text + "','" + totprofit.Text + "','" + totvat.Text + "','" + tottotal.Text + "')";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
            
                    string que = "INSERT INTO items (name,dat,events) VALUES ('" + txtname.Text + "','" + DateTime.Now.ToString() + "','Service Created')";
                    SqlDataAdapter SD = new SqlDataAdapter(que, con);
                    SD.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("Inserted successfully");

            }
            }
            con.Close();

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox1.Text == "Merchandise")
            {
                string query = "SELECT count(*) FROM Inventory WHERE name='" + txtname.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string q = "SELECT * FROM inventory WHERE name='" + txtname.Text + "'";
                    SqlDataAdapter SD = new SqlDataAdapter(q, con);
                    DataTable dtt = new DataTable();
                    SD.Fill(dtt);
                    double y = 0;
                    double yy = 0;

                    foreach (DataRow dr in dtt.Rows)
                    {
                        string x = dr["stock"].ToString();
                        y = Convert.ToDouble(x);
                        yy = Convert.ToDouble(txtstock.Text);
                        yy = yy + y;
                    }

                    if (txtcprice.Text == "" || txtsprice.Text == "")
                    {
                        string quer = "UPDATE inventory SET stock='" + yy.ToString() + "'WHERE name='" + txtname.Text + "'";
                        SqlDataAdapter SDt = new SqlDataAdapter(quer, con);
                        SDt.SelectCommand.ExecuteNonQuery();
                        string que = "INSERT INTO items (name,quan,dat,events) VALUES ('" + txtname.Text + "','" + yy.ToString() + "','" + DateTime.Now.ToString() + "','Stock added')";
                        SqlDataAdapter S = new SqlDataAdapter(que, con);
                        S.SelectCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string qery = "UPDATE inventory SET cprice='" + txtcprice.Text + "',sprice='" + txtsprice.Text + "',stock='" + yy.ToString() + "',profit='" + totprofit.Text + "',vat='" + totvat.Text + "',total='" + tottotal.Text + "'WHERE name='" + txtname.Text + "'";
                        SqlDataAdapter DA = new SqlDataAdapter(qery, con);
                        DA.SelectCommand.ExecuteNonQuery();
                        string que = "INSERT INTO items (name,quan,dat,events) VALUES ('" + txtname.Text + "','" + yy.ToString() + "','" + DateTime.Now.ToString() + "','Prices were updated')";
                        SqlDataAdapter D = new SqlDataAdapter(que, con);
                        D.SelectCommand.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Item does not exist");
                }
            }else if (comboBox1.Text == "Service")
            {
                string query = "SELECT count(*) FROM Inventory_tax WHERE name='" + txtname.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string qery = "UPDATE inventory_tax SET govt='" + txtcprice.Text + "',credit='" + txtsprice.Text + "',total='" + tottotal.Text + "',vat='" + totvat.Text + "'WHERE name='" + txtname.Text + "'";
                    SqlDataAdapter DA = new SqlDataAdapter(qery, con);
                    DA.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Service updated successfully");
                    string que = "INSERT INTO items (name,dat,events) VALUES ('" + txtname.Text + "','" + DateTime.Now.ToString() + "','Service prices updated')";
                    SqlDataAdapter SD = new SqlDataAdapter(que, con);
                    SD.SelectCommand.ExecuteNonQuery();

                }
                else
                {
                    MessageBox.Show("Service does not exist");
                }
                
            }
            con.Close();
        }
        
            

        private void btndel_Click(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox1.Text == "Merchandise")
            {
            try
            {
                    if (MessageBox.Show("Do you want to remove this Item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                       
                        string query = "DELETE FROM inventory WHERE name='" + txtname.Text + "'";
                        SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                        SDA.SelectCommand.ExecuteNonQuery();
                        MessageBox.Show("Deleted successfully");
                        string que = "INSERT INTO items (name,dat,events) VALUES ('" + txtname.Text + "','" + DateTime.Now.ToString() + "','Item was Deleted')";
                        SqlDataAdapter SD = new SqlDataAdapter(que, con);
                        SD.SelectCommand.ExecuteNonQuery();
                       
                    }
                    else
                    {
                        MessageBox.Show("item was not deleted");
                    }
            }
            catch
            {
                MessageBox.Show("It seems that the given Item does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }else if (comboBox1.Text=="Services") {
                try
                {
                    if (MessageBox.Show("Do you want to remove this service?", "Remove Service", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string query = "DELETE FROM inventory_tax WHERE name='" + txtname.Text + "'";
                        SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                        SDA.SelectCommand.ExecuteNonQuery();
                        string que = "INSERT INTO items (name,dat,events) VALUES ('" + txtname.Text + "','" + DateTime.Now.ToString() + "','Service was deleted')";
                        SqlDataAdapter SD = new SqlDataAdapter(que, con);
                        SD.SelectCommand.ExecuteNonQuery();
                        MessageBox.Show("Deleted successfully");
                    }
                    else
                    {
                        MessageBox.Show("Service was not deleted");
                    }
                }
                catch
                {
                    MessageBox.Show("It seems that the given service does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventory main = new Inventory();
            main.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Double cp = Convert.ToDouble(txtcprice.Text);
                Double sp = Convert.ToDouble(txtsprice.Text);
                double prof = sp - cp;
                double vat = (sp * 0.05);
                double tot = (vat + sp);
                totprofit.Text = prof.ToString();
                tottotal.Text = tot.ToString();
                totvat.Text = vat.ToString();
            }
            catch
            {
                MessageBox.Show("Please give data correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtstock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
            else
            {
                return;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            if (comboBox1.Text == "Service")
            {
                SqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT name from Inventory_tax";
                cmd.ExecuteNonQuery();
                DataTable db = new DataTable();
                SqlDataAdapter dq = new SqlDataAdapter(cmd);
                txtname.Items.Clear();
                dq.Fill(db);
                foreach (DataRow dr in db.Rows)
                {
                    txtname.Items.Add(dr["Name"].ToString());

                }

                label5.Text = "Govt. Fees"; label1.Refresh();
                label4.Text = "Credit"; label1.Refresh();
                button2.Visible = false;
                totprofit.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label8.Visible = false;
                txtstock.Visible = false;
            }
            else if (comboBox1.Text == "Merchandise")
            {
                SqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT name from Inventory";
                cmd.ExecuteNonQuery();
                DataTable db = new DataTable();
                SqlDataAdapter dq = new SqlDataAdapter(cmd);
                dq.Fill(db);
                txtname.Items.Clear();
                foreach (DataRow dr in db.Rows)
                {
                    txtname.Items.Add(dr["Name"].ToString());

                }
                totprofit.Visible = true;
                button2.Visible = true;
                label6.Visible = true;
                label10.Visible = true;
                label8.Visible = true;
                txtstock.Visible = true;
                label5.Text = "Cost Price"; label1.Refresh();
                label4.Text = "Sale Price"; label1.Refresh();

            }
            con.Close();

        }

        private void txtsprice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (comboBox1.Text == "Service")
                    {
                        double bb = 0;
                        double aa = 0;
                        double cc = 0;
                        aa = Convert.ToDouble(txtsprice.Text);
                        bb = aa / 1.05;
                        bb = aa - bb;
                        Convert.ToString(bb);
                        String.Format("{0:0.00}", bb);
                        Convert.ToDouble(bb);

                        cc = Convert.ToDouble(txtsprice.Text) + Convert.ToDouble(txtcprice.Text);
                        totvat.Text = bb.ToString();
                        tottotal.Text = cc.ToString();

                    }
                    else
                    {
                        return;

                    }
                }
            }
            catch
            {
                MessageBox.Show("An error occured please write the data correctly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void txtcprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch==46 && txtcprice.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if(!char.IsDigit(ch)&& ch !=8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtsprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtsprice.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtstock.Text.IndexOf('.') != -1)
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
