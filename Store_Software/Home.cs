using System;
using System.Windows.Forms;

namespace Store_Software
{
    public partial class Home : Form
    {
        private int childFormNumber = 0;

        public Home()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gototal_Click(object sender, EventArgs e)
        {
            Total main = new Total();
            main.ShowDialog();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (globals.tp == "su")
            {
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label2.Text = "Welcome Super User Abdullah";
                bckbtn.Visible = true;
            }
            else if (globals.tp == "user")
            {
                label2.Text = "Welcome " + globals.score;
                gototal.Visible = false;
                godreport.Visible = false;
                gosreport.Visible = false;
            }
            else if (globals.tp == "admin")
            {
                label2.Text = "Welcome " + globals.score;
                label4.Visible = true;
                label6.Visible = true;
                bckbtn.Visible = true;
            }
            else
            {
                label2.Text = "Welcome " + globals.score;
                gototal.Visible = false;
                godreport.Visible = false;
                gosreport.Visible = false;
            }
        }

        private void goinvoice_Click(object sender, EventArgs e)
        {
            Invoice main = new Invoice();
            main.ShowDialog();
        }

        private void goitem_Click(object sender, EventArgs e)
        {
            Inventory main = new Inventory();
            main.ShowDialog();
        }

        private void gocustom_Click(object sender, EventArgs e)
        {
            Customer main = new Customer();
            main.ShowDialog();
        }

        private void godreport_Click(object sender, EventArgs e)
        {
            Dreport main = new Dreport();
            main.ShowDialog();
        }

        private void gosreport_Click(object sender, EventArgs e)
        {
            Sreport main = new Sreport();
            main.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void goinvent_Click(object sender, EventArgs e)
        {
            Inventory main = new Inventory();
            main.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
            }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            aa main = new aa();
            main.ShowDialog();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Findinv main = new Findinv();
            main.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            all main = new all();
            main.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            user main = new user();
            main.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Report main = new Report();
            main.ShowDialog();
        }

        private void bckbtn_Click(object sender, EventArgs e)
        {
            back main = new back();
            main.ShowDialog();
        }
    }
}
