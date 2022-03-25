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
    public partial class back : Form
    {
        public back()
        {
            InitializeComponent();
        }
        SqlConnection con = globals.cnstring;

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            label1.Text = DateTime.Now.ToShortDateString();
            label1.Text = label1.Text.Replace("/", "-");
            string query = "Backup database new to disk ='E:\\database\\new"+label1.Text+".bak'WITH FORMAT,MEDIANAME = 'C_SQLServerBackups',NAME = 'Full Backup of MyDatabase'; ";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Backup is complete. The file name is  new" + label1.Text + ". Please do not rename the file");
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            try { 
            label1.Text = dateTimePicker1.Value.ToString("dd/MMM/yy");
            label1.Text = label1.Text.Replace("/", "-");
            string query = "USE master; ALTER DATABASE new SET SINGLE_USER with ROLLBACK IMMEDIATE RESTORE DATABASE new FROM DISK = 'E:\\database\\new"+label1.Text+ ".BAK'WITH REPLACE;ALTER DATABASE new SET MULTI_USER;";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Restore is complete. The file name was " + label1.Text);
            }
               
            catch
            {
                MessageBox.Show("Sorry but the database at the date selected was not present in the given directory or the name of dabase was not of the correct format");
            }
            con.Close();
        }

        private void back_Load(object sender, EventArgs e)
        {

        }
    }
}
