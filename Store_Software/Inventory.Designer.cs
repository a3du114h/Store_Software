namespace Store_Software
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.label1 = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btncreate = new System.Windows.Forms.Button();
            this.btnview = new System.Windows.Forms.Button();
            this.txtsprice = new System.Windows.Forms.TextBox();
            this.txtcprice = new System.Windows.Forms.TextBox();
            this.txtstock = new System.Windows.Forms.TextBox();
            this.totvat = new System.Windows.Forms.Label();
            this.totcode = new System.Windows.Forms.Label();
            this.totprofit = new System.Windows.Forms.Label();
            this.tottotal = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Govt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btndel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F);
            this.label1.Location = new System.Drawing.Point(24, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.Red;
            this.btnexit.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.btnexit.ForeColor = System.Drawing.SystemColors.Info;
            this.btnexit.Location = new System.Drawing.Point(758, 423);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(87, 35);
            this.btnexit.TabIndex = 11;
            this.btnexit.Text = "&Exit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(25, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Create new item or update an existing one";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F);
            this.label3.Location = new System.Drawing.Point(25, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F);
            this.label4.Location = new System.Drawing.Point(26, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sale Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F);
            this.label5.Location = new System.Drawing.Point(26, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cost Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 12F);
            this.label6.Location = new System.Drawing.Point(25, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Profit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 12F);
            this.label7.Location = new System.Drawing.Point(25, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "VAT Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 12F);
            this.label8.Location = new System.Drawing.Point(25, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "Add Stock";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 12F);
            this.label9.Location = new System.Drawing.Point(25, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 19);
            this.label9.TabIndex = 10;
            this.label9.Text = "Total Price";
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnupdate.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.btnupdate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnupdate.Location = new System.Drawing.Point(210, 424);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(83, 32);
            this.btnupdate.TabIndex = 7;
            this.btnupdate.Text = "&Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btncreate
            // 
            this.btncreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btncreate.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.btncreate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncreate.Location = new System.Drawing.Point(116, 424);
            this.btncreate.Name = "btncreate";
            this.btncreate.Size = new System.Drawing.Size(79, 32);
            this.btncreate.TabIndex = 6;
            this.btncreate.Text = "&Create";
            this.btncreate.UseVisualStyleBackColor = false;
            this.btncreate.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnview
            // 
            this.btnview.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.btnview.Location = new System.Drawing.Point(308, 423);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(82, 32);
            this.btnview.TabIndex = 8;
            this.btnview.Text = "&View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // txtsprice
            // 
            this.txtsprice.Location = new System.Drawing.Point(127, 206);
            this.txtsprice.Name = "txtsprice";
            this.txtsprice.Size = new System.Drawing.Size(100, 20);
            this.txtsprice.TabIndex = 4;
            this.txtsprice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsprice_KeyDown);
            this.txtsprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsprice_KeyPress);
            // 
            // txtcprice
            // 
            this.txtcprice.Location = new System.Drawing.Point(127, 165);
            this.txtcprice.Name = "txtcprice";
            this.txtcprice.Size = new System.Drawing.Size(100, 20);
            this.txtcprice.TabIndex = 3;
            this.txtcprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcprice_KeyPress);
            // 
            // txtstock
            // 
            this.txtstock.Location = new System.Drawing.Point(126, 331);
            this.txtstock.Name = "txtstock";
            this.txtstock.Size = new System.Drawing.Size(100, 20);
            this.txtstock.TabIndex = 5;
            this.txtstock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtstock_KeyDown);
            this.txtstock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtstock_KeyPress);
            // 
            // totvat
            // 
            this.totvat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.totvat.Font = new System.Drawing.Font("Cambria", 12F);
            this.totvat.Location = new System.Drawing.Point(126, 291);
            this.totvat.Name = "totvat";
            this.totvat.Size = new System.Drawing.Size(100, 21);
            this.totvat.TabIndex = 0;
            // 
            // totcode
            // 
            this.totcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.totcode.Font = new System.Drawing.Font("Cambria", 12F);
            this.totcode.Location = new System.Drawing.Point(126, 47);
            this.totcode.Name = "totcode";
            this.totcode.Size = new System.Drawing.Size(100, 21);
            this.totcode.TabIndex = 0;
            // 
            // totprofit
            // 
            this.totprofit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.totprofit.Font = new System.Drawing.Font("Cambria", 12F);
            this.totprofit.Location = new System.Drawing.Point(126, 246);
            this.totprofit.Name = "totprofit";
            this.totprofit.Size = new System.Drawing.Size(100, 21);
            this.totprofit.TabIndex = 25;
            // 
            // tottotal
            // 
            this.tottotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tottotal.Font = new System.Drawing.Font("Cambria", 12F);
            this.tottotal.Location = new System.Drawing.Point(126, 379);
            this.tottotal.Name = "tottotal";
            this.tottotal.Size = new System.Drawing.Size(100, 21);
            this.tottotal.TabIndex = 26;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.Item,
            this.Stock,
            this.Govt,
            this.Credit,
            this.Price});
            this.dataGridView1.Location = new System.Drawing.Point(255, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(591, 358);
            this.dataGridView1.TabIndex = 10;
            // 
            // SrNo
            // 
            this.SrNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SrNo.FillWeight = 18.49606F;
            this.SrNo.HeaderText = "Code";
            this.SrNo.Name = "SrNo";
            this.SrNo.Width = 50;
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item.FillWeight = 369.5431F;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // Stock
            // 
            this.Stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Stock.FillWeight = 5.980393F;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.Width = 70;
            // 
            // Govt
            // 
            this.Govt.HeaderText = "Govt Fees";
            this.Govt.Name = "Govt";
            // 
            // Credit
            // 
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Price.FillWeight = 5.980393F;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.Width = 70;
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btndel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.btndel.Location = new System.Drawing.Point(405, 423);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(82, 32);
            this.btndel.TabIndex = 9;
            this.btndel.Text = "&Delete";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(504, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "Clea&r";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(12, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 32);
            this.button2.TabIndex = 26;
            this.button2.Text = "Calculate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtname
            // 
            this.txtname.FormattingEnabled = true;
            this.txtname.Location = new System.Drawing.Point(126, 123);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(100, 21);
            this.txtname.TabIndex = 2;
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 9F);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(92, 354);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 14);
            this.label10.TabIndex = 65;
            this.label10.Text = "*Press Enter to calculate";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "--Select--",
            "Service",
            "Merchandise"});
            this.comboBox1.Location = new System.Drawing.Point(126, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 12F);
            this.label11.Location = new System.Drawing.Point(25, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 19);
            this.label11.TabIndex = 67;
            this.label11.Text = "Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cambria", 9F);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(92, 229);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 14);
            this.label12.TabIndex = 68;
            this.label12.Text = "*Press Enter to calculate";
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(867, 470);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tottotal);
            this.Controls.Add(this.totprofit);
            this.Controls.Add(this.totcode);
            this.Controls.Add(this.totvat);
            this.Controls.Add(this.txtstock);
            this.Controls.Add(this.txtcprice);
            this.Controls.Add(this.txtsprice);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.btncreate);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create or Update Items";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btncreate;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.TextBox txtsprice;
        private System.Windows.Forms.TextBox txtcprice;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.Label totvat;
        private System.Windows.Forms.Label totcode;
        private System.Windows.Forms.Label totprofit;
        private System.Windows.Forms.Label tottotal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox txtname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Govt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Label label12;
    }
}