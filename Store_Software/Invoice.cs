using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Store_Software
{
    public partial class Invoice : Form
    {

        public Invoice()
        {
            InitializeComponent();
        }
        SqlConnection con = globals.cnstring;
        int n1;
        double qq = 0;
        double qw = 0;
        double pw = 0;

        double amm, am;
        double bm, cmm, dmm;
        double cm, cp;
        string xx = "";
        string yy = "";
        string zz = "";
        string aw, bw, cw, dw;
        double[] ew = new double[100];
        double[] fw = new double[100];
        double dm = 0;
        int n = 0;
        private void btnexit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void Invoice_Load(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            try {
                string q = "select top 1 [id] from Invoices order by [id] desc";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                SD.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    amm = Convert.ToDouble(dr["id"]);
                    if (dr["id"] == null)
                    {
                        amm = 10000;
                    }
                    else
                    {
                        amm = amm + 10000;
                    }
                }


                string query = "DELETE FROM [current]";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();

                SqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT name from Customer";
                cmd.ExecuteNonQuery();
                DataTable db = new DataTable();
                SqlDataAdapter dq = new SqlDataAdapter(cmd);
                dq.Fill(db);
                foreach (DataRow dr in db.Rows)
                {
                    comboBox2.Items.Add(dr["Name"].ToString());

                }
                comboBox2.SelectedIndex = 0;
                totcode.Text = amm.ToString();
            }
            catch
            {
                MessageBox.Show("There are no items in the inventory or customers available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            n1 = dataGridView1.Rows.Add();

            if (comboBox3.Text == "Merchandise")
            {
                string q = "SELECT * FROM Inventory WHERE name='" + comboBox1.Text + "'";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                SD.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    am = Convert.ToDouble(dr["sprice"]);
                    cp = Convert.ToDouble(txtquan.Text);
                    bm = am * cp;// This is price x quantity

                    ew[n] = am;
                    fw[n] = bm;
                    cm = Convert.ToDouble(dr["vat"]);
                    dm = (cm * cp); //this is vat x quantity
                    textBox3.Text = bm.ToString();

                }
                string query = "INSERT INTO [current] (item,quantity,amount,type,vat) VALUES ('" + comboBox1.Text + "','" + cp.ToString() + "','" + bm.ToString() + "','" + comboBox3.Text + "','" + dm.ToString() + "')";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();


                txtquan.Clear();

            } else if (comboBox3.Text == "Service")
            {
                string q = "SELECT * FROM Inventory_tax WHERE name='" + comboBox1.Text + "'";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                SD.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    am = Convert.ToDouble(textBox4.Text);
                    cp = Convert.ToDouble(txtquan.Text);
                    bm = am + cp;// This is typing + govt. fees
                    ew[n] = am;
                    fw[n] = bm;
                    cm = am / 1.05;//VAT of typing

                    cm = am - cm;               // bmm = bm + cm;
                    cm = Math.Round(cm, 2);
                    totvat.Text = cm.ToString();
                    tottotal.Text = bm.ToString();
                    totsub.Text = bm.ToString();
                }


                string query = "INSERT INTO [current] (item,amount,type,quantity,vat) VALUES ('" + comboBox1.Text + "','" + bm.ToString() + "','" + comboBox3.Text + "','" + "1" + "','" + cm.ToString() + "')";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();

            }
            string q1 = "SELECT * FROM [current]";
            SqlDataAdapter SD1 = new SqlDataAdapter(q1, con);
            DataTable dt1 = new DataTable();
            SD1.Fill(dt1);
            qq = 0;
            qw = 0;
            foreach (DataRow dr1 in dt1.Rows)
            {
                dataGridView1.Rows[n1].Cells[0].Value = (n1 + 1).ToString();
                dataGridView1.Rows[n1].Cells[1].Value = dr1["item"].ToString();
                dataGridView1.Rows[n1].Cells[2].Value = dr1["quantity"].ToString();
                dataGridView1.Rows[n1].Cells[3].Value = dr1["amount"].ToString();
                dataGridView1.Rows[n1].Cells[4].Value = dr1["type"].ToString();
                dataGridView1.Rows[n1].Cells[5].Value = dr1["vat"].ToString();

            }


            double b;
            string x = "0";
            int p = dataGridView1.Rows.Count - 1;
            for (int n = 0; n < p; n++)
            {
                x = dataGridView1.Rows[n].Cells["Price"].Value.ToString();
                b = Convert.ToDouble(x);
                qq = b + qq;//Price total
                x = dataGridView1.Rows[n].Cells["VAT"].Value.ToString();
                qw = qw + Convert.ToDouble(x);
            }
            pw = qq + qw;
            var sourceValue = textBox2.Text;
            double dist, doubleValue;
            if (double.TryParse(sourceValue, out doubleValue))
            {
                doubleValue = Convert.ToDouble(textBox2.Text);
                dist = pw - doubleValue;
                tottotal.Text = (dist).ToString();
                // Here you already can use a valid double 'doubleValue'
            }
            else
            {
                tottotal.Text = pw.ToString();
            }
            double dz = pw - doubleValue;//total

            aw = Convert.ToString(qq);//sub Total
            bw = Convert.ToString(qw);//vat total
            cw = Convert.ToString(doubleValue);// discount
            dw = Convert.ToString(dz);// Total

            textBox3.Text = dw;
            textBox1.Text = "0";
            totsub.Text = qq.ToString();
            totvat.Text = qw.ToString();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btncreate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            preview.Document = print;
            preview.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                { double dc = Convert.ToDouble(textBox3.Text);
                    double db = Convert.ToDouble(tottotal.Text);
                    double po = db - dc;
                    textBox1.Text = po.ToString();
                }
                catch
                {
                    MessageBox.Show("Please enter the credit in real numbers or enter item before pressing enter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            print.Print();
        }


        private void totcode_Click(object sender, EventArgs e)
        {

        }

        private void txtquan_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_Click(this, new EventArgs());
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox3.Text == "Service")
            {
                label12.Text = "Service"; label12.Refresh();
                label14.Text = "Credit"; label14.Refresh();
                label6.Text = "Govt."; label6.Refresh();
                label15.Text = "Typing"; label15.Refresh();
                label11.Visible = true;
                label8.Visible = true;
                textBox1.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;

                SqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT name from Inventory_tax";
                cmd.ExecuteNonQuery();
                DataTable db = new DataTable();
                SqlDataAdapter dq = new SqlDataAdapter(cmd);
                dq.Fill(db);
                comboBox1.Items.Clear();
                foreach (DataRow dr in db.Rows)
                {
                    comboBox1.Items.Add(dr["Name"].ToString());

                }
                comboBox1.SelectedIndex = 0;

            }
            else if (comboBox3.Text == "Merchandise")
            {
                SqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT name from Inventory";
                cmd.ExecuteNonQuery();
                DataTable db = new DataTable();
                SqlDataAdapter dq = new SqlDataAdapter(cmd);
                dq.Fill(db);
                comboBox1.Items.Clear();
                foreach (DataRow dr in db.Rows)
                {
                    comboBox1.Items.Add(dr["Name"].ToString());
                }
                comboBox1.SelectedIndex = 0;
                label11.Visible = true;
                label14.Visible = true;
                label15.Visible = false;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox1.Visible = true;

                label12.Text = "Item"; label12.Refresh();
                label6.Text = "Quantity"; label6.Refresh();

            }


        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox3.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox1.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void txtquan_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtquan.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox4.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox2.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            try
            {
                string q = "select top 1 [id] from Invoices order by [id] desc";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                SD.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    amm = Convert.ToDouble(dr["id"]);
                    if (dr["id"] == null)
                    {
                        amm = 10000;
                    }
                    else
                    {
                        amm = amm + 10000;
                    }
                    totcode.Text = amm.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Error occured. please try again");
            }
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            if (comboBox3.Text == "Service")
            {
                string q = "SELECT * FROM inventory_tax WHERE name='" + comboBox1.Text + "'";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                SD.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    dmm = Convert.ToDouble(dr["govt"]);
                    cmm = Convert.ToDouble(dr["credit"]);
                    txtquan.Text = dmm.ToString();
                    textBox4.Text = cmm.ToString();
                    //      textBox3.Text = ((cmm * 0.05) + cmm + dmm).ToString();
                    //    textBox1.Text = "0";
                }

            }
            else if (comboBox3.Text == "Merchandise")
            {
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_Click(this, new EventArgs());
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var sourceValue = textBox2.Text;
                double dist, doubleValue;

                if (double.TryParse(sourceValue, out doubleValue))
                {
                    doubleValue = Convert.ToDouble(textBox2.Text);
                    dist = qq + qw - doubleValue;
                    tottotal.Text = (dist).ToString();
                    double mn = Convert.ToDouble(textBox3.Text);
                    textBox3.Text = (mn - doubleValue).ToString();
                    // Here you already can use a valid double 'doubleValue'
                }
                else
                {
                    tottotal.Text = (qq + qw).ToString();
                }
                double dz = qq + qw - doubleValue;//total
                aw = Convert.ToString(qq);//Price Total
                bw = Convert.ToString(qw);//vat total
                cw = Convert.ToString(doubleValue);// discount
                dw = Convert.ToString(dz);//

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double az = 0;
            double bz = 0;
            double bbz = 0;



            string y = "";
            string x = "";
            string z = "";
            zz = "";
            string q2 = "SELECT * FROM [current]";
            SqlDataAdapter SD2 = new SqlDataAdapter(q2, con);
            DataTable dt2 = new DataTable();
            SD2.Fill(dt2);
            n = 0;
            foreach (DataRow dr2 in dt2.Rows)
            {
                y = dr2["item"].ToString();
                x = dr2["quantity"].ToString();

                z = z + " : " + y;//Items
                zz = zz + " : " + x;//Quantity

            }
            string q1 = "SELECT * FROM [current] where type='Merchandise'";
            SqlDataAdapter SD1 = new SqlDataAdapter(q1, con);
            DataTable dt1 = new DataTable();
            SD1.Fill(dt1);
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow dr1 in dt1.Rows)
            {
                n1 = dataGridView1.Rows.Add();
                dataGridView1.Rows[n1].Cells[0].Value = (n1 + 1).ToString();
                dataGridView1.Rows[n1].Cells[1].Value = dr1["item"].ToString();
                dataGridView1.Rows[n1].Cells[2].Value = dr1["quantity"].ToString();
            }
            int p = dataGridView1.Rows.Count - 1;
            for (int n = 0; n < p; n++)
            {
                xx = dataGridView1.Rows[n].Cells["Quantity"].Value.ToString();
                yy = dataGridView1.Rows[n].Cells["Item"].Value.ToString();
                az = Convert.ToDouble(xx);

                string q = "SELECT * FROM inventory WHERE name='" + yy.ToString() + "'";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                SD.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    bz = Convert.ToDouble(dr["stock"]);
                    bbz = Convert.ToDouble(dr["profit"]);
                    double baz = bbz * az;
                    bz = bz - az;
                    if (bz >= 0)
                    {
                        string query = "UPDATE inventory SET stock='" + bz.ToString() + "' WHERE name ='" + yy.ToString() + "'";
                        SqlDataAdapter SA = new SqlDataAdapter(query, con);
                        SA.SelectCommand.ExecuteNonQuery();

                        string qqw = "INSERT INTO items(name,quan,dat,prof,events)VALUES ('" + yy.ToString() + "', '" + az.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + baz.ToString() + "','Item Sold')";
                        SqlDataAdapter SDp = new SqlDataAdapter(qqw, con);
                        SDp.SelectCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Sorry the item in the invoice is more than the stock present.");
                    }
                }
            }
            if (bz >= 0)
            {
                try
                {
                    string user = globals.score;
                    string qqq = "INSERT INTO Invoices(customid,itemid,quantities,dat,tim,sub,vat,discount,total,invno,credit,debit,usr ) VALUES ('" + comboBox2.Text + "', '" + z.ToString() + "', '" + zz.ToString() + "', '" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() + "', '" + aw.ToString() + "', '" + bw.ToString() + "', '" + cw.ToString() + "', '" + dw.ToString() + "','" + amm.ToString() + "','" + textBox3.Text + "','" + textBox1.Text + "','" + user + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(qqq, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    string qqwp = "SELECT * into [tab" + totcode.Text + "] from [current]";
                    SqlDataAdapter SDpp = new SqlDataAdapter(qqwp, con);
                    SDpp.SelectCommand.ExecuteNonQuery();

                    dataGridView1.Rows.Clear();
                    MessageBox.Show("Invoice posted successfully");
                }
                catch {
                    MessageBox.Show("Please complete the data before posting");

                }
            }
            else
            {
                MessageBox.Show("Invoice not posted");

            }
            con.Close();
            Invoice main = new Invoice();
            main.ShowDialog();
            this.Close();
        }

        private void preview_Load(object sender, EventArgs e)
        {
                
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            preview.Document = print;
            preview.ShowDialog();

        }

        private void print_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.head_h;
            Image img = bmp;
            e.Graphics.DrawImage(img, 260, 0, img.Width, img.Height);
            string q = "SELECT * FROM customer WHERE name='" + comboBox2.Text + "'";
            SqlDataAdapter SD = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SD.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                e.Graphics.DrawString("Customer Name:" + dr["name"].ToString(), new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, 280));
                e.Graphics.DrawString("اسم الزبون", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, 260));

                e.Graphics.DrawString("Contact:" + dr["contact1"].ToString(), new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, 330));
                e.Graphics.DrawString("اتصل", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, 310));

                e.Graphics.DrawString("Address:" + dr["address"].ToString(), new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, 370));
                e.Graphics.DrawString("عنوان", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, 350));

            }

            e.Graphics.DrawString("Tax Invoice / فاتورة الضريبة", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(300, 210));

            e.Graphics.DrawString("Invoice No.:" + totcode.Text, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(550, 280));
            e.Graphics.DrawString("الرقم فاتورة", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(550, 260));

            e.Graphics.DrawString("Date Time:" + DateTime.Now, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(550, 330));
            e.Graphics.DrawString("User ID:" + globals.score, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(550, 310));


            string q1 = "SELECT * FROM [current]";
            SqlDataAdapter SD1 = new SqlDataAdapter(q1, con);
            DataTable dt1 = new DataTable();
            SD1.Fill(dt1);
            int n2 = 1;
            int ypos = 430;
            double co = 0;
            double db = 0;
           foreach (DataRow dr1 in dt1.Rows)
            {

                co = Convert.ToDouble(textBox3.Text);

                db = Convert.ToDouble(textBox1.Text);
                
                e.Graphics.DrawString((n2).ToString(), new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(60, ypos));
                e.Graphics.DrawString(dr1["item"].ToString(), new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(120, ypos));
                e.Graphics.DrawString(dr1["quantity"].ToString(), new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(550, ypos));
               // e.Graphics.DrawString(co.ToString(), new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(450, ypos));
                //e.Graphics.DrawString(db.ToString(), new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(550, ypos));
                e.Graphics.DrawString(dr1["amount"].ToString(), new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(710,ypos));
                ypos = ypos + 30;
                n2 = n2 + 1;
            }
            e.Graphics.DrawString(line.Text, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, 410));
            e.Graphics.DrawString("Sr.No", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(30, 410));
            e.Graphics.DrawString("Item Name", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(80, 410));
            e.Graphics.DrawString("Quantity", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(550, 410));
          //  e.Graphics.DrawString("Credit", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(430, 410));
            //e.Graphics.DrawString("Debit", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(530, 410));
            e.Graphics.DrawString("Total Amount", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(680, 410));

            e.Graphics.DrawString(line.Text, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, 372));
            e.Graphics.DrawString(" الرقم", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(35, 390));
            e.Graphics.DrawString("التفاصيل", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(85, 390));
            e.Graphics.DrawString("الكمية", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(555, 390));
           // e.Graphics.DrawString("ائتمان", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(435, 390));
            //e.Graphics.DrawString("مدين", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(535, 390));
            e.Graphics.DrawString("المبلغ", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(685, 390));

            string isNegative = "";
            string aiw = "";
            string number = textBox3.Text;
            number = Convert.ToDouble(number).ToString();

            if (number.Contains("-"))
            {
                isNegative = "Minus ";
                number = number.Substring(1, number.Length - 1);
            }
            if (number == "0")
            {
                aiw = "Zero Only";
            }
            else
            {
                aiw = "" + isNegative + ConvertToWords(number);
            }







            e.Graphics.DrawString(line.Text, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, ypos-20));

            e.Graphics.DrawString("Sub Total:المجموع " + aw, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos));
            e.Graphics.DrawString("VAT @ 5%:مجموع ضريبة " + bw, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos + 30));
            e.Graphics.DrawString("Discount:خصم" + cw, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos+ 60));
            e.Graphics.DrawString("Total Paid :المبلغ المدفوع" + co, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos + 90));
            e.Graphics.DrawString("Amount in Words                                  المبلغ بالكلمات", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, ypos + 60));
            e.Graphics.DrawString(aiw, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, ypos + 90));
            e.Graphics.DrawString("Total Remaining: :المجموع المتبقي" + db, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos + 120));
            Bitmap bm = Properties.Resources.foot_h;
            Image im = bm;
            e.Graphics.DrawImage(im, 55, 980, im.Width, im.Height);

        }
        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX  
                bool isDone = false;//test if already translated  
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))  
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric  
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping  
                    String place = "";//digit grouping name:hundres,thousand,etc...  
                    switch (numDigits)
                    {
                        case 1://ones' range  

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range  
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range  
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range  
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range  
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range  
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...  
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)  
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros  
                        //if (beginsZero) word = " and " + word.Trim();  
                    }
                    //ignore digit grouping names  
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }
        private static String ConvertToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "Only"; String endsStr = "Dirhams";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "Dirhams and";// just to separate whole numbers from points/cents  
                        endStr = "Fils " + endStr;//Cents  
                        endsStr = "";
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3} {4}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endsStr, endStr);
            }
            catch { }
            return val;
        }
        private static String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }

    }
}
