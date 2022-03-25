namespace Store_Software
{
    partial class Customer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer));
            this.totcode = new System.Windows.Forms.Label();
            this.txtpobox = new System.Windows.Forms.TextBox();
            this.txtcontact1 = new System.Windows.Forms.TextBox();
            this.txtcontact2 = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.btnview = new System.Windows.Forms.Button();
            this.btncreate = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Sr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtadr = new System.Windows.Forms.TextBox();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.btndel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // totcode
            // 
            this.totcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.totcode, "totcode");
            this.totcode.Name = "totcode";
            this.totcode.Click += new System.EventHandler(this.totcode_Click);
            // 
            // txtpobox
            // 
            resources.ApplyResources(this.txtpobox, "txtpobox");
            this.txtpobox.Name = "txtpobox";
            this.txtpobox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpobox_KeyPress);
            // 
            // txtcontact1
            // 
            resources.ApplyResources(this.txtcontact1, "txtcontact1");
            this.txtcontact1.Name = "txtcontact1";
            this.txtcontact1.TextChanged += new System.EventHandler(this.txtcprice_TextChanged);
            this.txtcontact1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcontact1_KeyPress);
            // 
            // txtcontact2
            // 
            resources.ApplyResources(this.txtcontact2, "txtcontact2");
            this.txtcontact2.Name = "txtcontact2";
            this.txtcontact2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcontact2_KeyPress);
            // 
            // txtname
            // 
            resources.ApplyResources(this.txtname, "txtname");
            this.txtname.Name = "txtname";
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // btnview
            // 
            resources.ApplyResources(this.btnview, "btnview");
            this.btnview.Name = "btnview";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // btncreate
            // 
            this.btncreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.btncreate, "btncreate");
            this.btncreate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncreate.Name = "btncreate";
            this.btncreate.UseVisualStyleBackColor = false;
            this.btncreate.Click += new System.EventHandler(this.btncreate_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.btnupdate, "btnupdate");
            this.btnupdate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnexit, "btnexit");
            this.btnexit.ForeColor = System.Drawing.SystemColors.Info;
            this.btnexit.Name = "btnexit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sr,
            this.Name1,
            this.Contact,
            this.Address});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // Sr
            // 
            this.Sr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.Sr, "Sr");
            this.Sr.Name = "Sr";
            this.Sr.ReadOnly = true;
            // 
            // Name1
            // 
            this.Name1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.Name1, "Name1");
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            // 
            // Contact
            // 
            this.Contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.Contact, "Contact");
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Address, "Address");
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // txtadr
            // 
            resources.ApplyResources(this.txtadr, "txtadr");
            this.txtadr.Name = "txtadr";
            this.txtadr.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtadr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtadr_KeyPress);
            // 
            // txtmail
            // 
            resources.ApplyResources(this.txtmail, "txtmail");
            this.txtmail.Name = "txtmail";
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.btndel, "btndel");
            this.btndel.Name = "btndel";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Customer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.txtmail);
            this.Controls.Add(this.txtadr);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.totcode);
            this.Controls.Add(this.txtpobox);
            this.Controls.Add(this.txtcontact1);
            this.Controls.Add(this.txtcontact2);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.btncreate);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.label1);
            this.Name = "Customer";
            this.Load += new System.EventHandler(this.Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label totcode;
        private System.Windows.Forms.TextBox txtpobox;
        private System.Windows.Forms.TextBox txtcontact1;
        private System.Windows.Forms.TextBox txtcontact2;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.Button btncreate;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtadr;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button button1;
    }
}