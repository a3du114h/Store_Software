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
    public partial class aa : Form
    {
        public aa()
        {
            InitializeComponent();
        }
        SqlConnection con = globals.cnstring;

        private void btncreate_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string query = "INSERT INTO data (Username,Password,type) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Inserted successfully");
            }
            catch
            {
                MessageBox.Show("Please enter only alphabets and digits or some special characters");
            }
            con.Close();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM data WHERE Username='" + textBox1.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted successfully");

            }
            catch
            {
                MessageBox.Show("It seems that the given Item does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void aa_Load(object sender, EventArgs e)
        {

        }
    }
}
