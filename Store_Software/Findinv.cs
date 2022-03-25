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
    public partial class Findinv : Form
    {
        public Findinv()
        {
            InitializeComponent();
        }
        SqlConnection con = globals.cnstring;
        int n1;
        double qq = 0;
        double qw = 0;
        double pw = 0;

        string xx = "";
        string yy = "";
        string zz = "";
        string aw, bw, cw, dw;
        double[] ew = new double[100];
        double[] fw = new double[100];
        int n = 0;

        private void totcode_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void totcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (con.State != ConnectionState.Open)
                {
                    con.Close();
                    con.Open();
                }
                try
                {
                    string qqq = totcode.Text;
                    string q2 = "SELECT * FROM [tab" + qqq + "]";
                    SqlDataAdapter SD2 = new SqlDataAdapter(q2, con);
                    DataTable dt2 = new DataTable();
                    SD2.Fill(dt2);

                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = (n + 1).ToString();
                        dataGridView1.Rows[n].Cells[1].Value = dr2["item"].ToString();
                        dataGridView1.Rows[n].Cells[2].Value = dr2["quantity"].ToString();
                        dataGridView1.Rows[n].Cells[3].Value = dr2["amount"].ToString();
                        dataGridView1.Rows[n].Cells[4].Value = dr2["type"].ToString();
                        dataGridView1.Rows[n].Cells[5].Value = dr2["vat"].ToString();
                    }

                    string q = "SELECT * FROM Invoices where invno='" + totcode.Text + "'";
                    SqlDataAdapter SD = new SqlDataAdapter(q, con);
                    DataTable dt = new DataTable();
                    SD.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        comboBox2.Text = dr["customid"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(dr["tim"].ToString());
                        yy = dr["dat"].ToString();
                        dateTimePicker2.Value = Convert.ToDateTime(yy.Substring(0, 10));
                        totsub.Text = dr["sub"].ToString();
                        tottotal.Text = dr["total"].ToString();
                        totvat.Text = dr["vat"].ToString();
                        textBox2.Text = dr["discount"].ToString();
                        textBox3.Text = dr["credit"].ToString();
                        textBox1.Text = dr["debit"].ToString();
                        label5.Text = dr["usr"].ToString();

                    }
                    string q1 = "SELECT * FROM [tab" + totcode.Text + "]";
                    SqlDataAdapter SD1 = new SqlDataAdapter(q1, con);
                    DataTable dt1 = new DataTable();
                    SD1.Fill(dt1);
                    qq = 0;
                    qw = 0;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        n1 = dataGridView1.Rows.Add();
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
                }
                catch
                {
                    MessageBox.Show("It seems that the given Invoice does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            private void Findinv_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double dc = Convert.ToDouble(textBox3.Text);
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            double az = 0;
            double bz = 0;
            double bbz = 0;
            string y = "";
            string x = "";
            string z = "";
            zz = "";

            string q2 = "SELECT * FROM [tab" + totcode.Text + "]";
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
            string q1 = "SELECT * FROM [tab" + totcode.Text + "] where type='Merchandise'";
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
                   
                }
            }
            string user = globals.score;

            string qqq = "UPDATE Invoices set customid='" + comboBox2.Text + "',itemid='" + z.ToString() + "',quantities='" + zz.ToString() + "',dat='" + dateTimePicker2.Value.ToString("d") + "',tim='" + dateTimePicker1.Value.ToString("T") + "',sub='" + aw.ToString() + "'" +
                ",vat='" + bw.ToString() + "',discount='" + cw.ToString() + "',total='" + dw.ToString() + "',credit='" + textBox3.Text + "',debit='" + textBox1.Text + "',usr='" + user + "' WHERE invno='" + totcode.Text+"'";
            SqlDataAdapter SDA = new SqlDataAdapter(qqq, con);
            SDA.SelectCommand.ExecuteNonQuery();

            dataGridView1.Rows.Clear();
            MessageBox.Show("Invoice updated successfully");

        }

        private void totcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && totcode.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
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
            try
            {
                if (MessageBox.Show("Do you want to remove this invoice?", "Remove invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }
                    string query = "DELETE FROM invoices WHERE invno='" + totcode.Text + "'";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.ExecuteNonQuery(); 
                    string quey = "Drop table [tab" + totcode.Text+"]";
                    SqlDataAdapter DA = new SqlDataAdapter(quey, con);
                    DA.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Deleted successfully");
                }
                else
                {
                    MessageBox.Show("Invoice was not deleted");
                }
            }
            catch
            {
                MessageBox.Show("It seems that the given Item does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

            e.Graphics.DrawString("Date Time:" + dateTimePicker2.Value.ToString("d")+" "+dateTimePicker1.Value.ToString("T"), new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(550, 330));
            e.Graphics.DrawString("User ID:" + globals.score, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(550, 310));

            string q1 = "SELECT * FROM [tab"+totcode.Text+"]";
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
                e.Graphics.DrawString(dr1["amount"].ToString(), new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(710, ypos));
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







            e.Graphics.DrawString(line.Text, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(25, ypos - 20));

            e.Graphics.DrawString("Sub Total:المجموع " + aw, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos));
            e.Graphics.DrawString("VAT @ 5%:مجموع ضريبة " + bw, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos + 30));
            e.Graphics.DrawString("Discount:خصم" + cw, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos + 60));
            e.Graphics.DrawString("Total Paid :المبلغ المدفوع" + co, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos + 90));
            e.Graphics.DrawString("Total Remaining: :المجموع المتبقي" + db, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(600, ypos + 120));
            Bitmap bm = Properties.Resources.foot_h;
            Image im = bm;
            e.Graphics.DrawImage(im, 55, 980, im.Width, im.Height);

        }
    }
}
