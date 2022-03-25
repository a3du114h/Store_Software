using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Store_Software
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = globals.cnstring;
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string q = "SELECT * FROM data WHERE Username='" + textBox1.Text + "' and Password= '" + textBox2.Text + "' COLLATE SQL_Latin1_General_CP1_CS_AS";
                SqlDataAdapter SD = new SqlDataAdapter(q, con);
                DataTable dt1 = new DataTable();
                SD.Fill(dt1);

                foreach (DataRow dr in dt1.Rows)
                {
                    string type= dr["type"].ToString();
                    globals.tp = type;
                }
                string query = "SELECT count(*) FROM data WHERE Username='" + textBox1.Text + "' and Password= '" + textBox2.Text + "' COLLATE SQL_Latin1_General_CP1_CS_AS";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    globals.score = textBox1.Text;
                    con.Close();
                    this.Hide();
                    Home main = new Home();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect");
                }
            }catch{
                MessageBox.Show("Please enter correct alphabets and numbers.");
            }
            con.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
                else
                {
                return;
            }


        }
    }
}
public static class globals
{
    public static string score;
   // public static SqlConnection cnstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\new.mdf;Integrated Security=True;Connect Timeout=30");
    public static SqlConnection cnstring = new SqlConnection(@"Data Source=LAPTOP-HHCL09E9\sqlexpress;Initial Catalog=new;User id=sa;Password=aAa@121s;Integrated Security=False;Connect Timeout=30");
    public static string tp;

}
