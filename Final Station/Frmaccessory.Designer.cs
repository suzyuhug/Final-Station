namespace Final_Station
{
    partial class Frmaccessory
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
            this.txtpo = new System.Windows.Forms.TextBox();
            this.POLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listlog = new System.Windows.Forms.ListBox();
            this.butstart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numqty = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.butadd = new System.Windows.Forms.Button();
            this.txtpn = new System.Windows.Forms.TextBox();
            this.PNlabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numqty)).BeginInit();
            this.SuspendLayout();
            // 
            // txtpo
            // 
            this.txtpo.Location = new System.Drawing.Point(98, 29);
            this.txtpo.Name = "txtpo";
            this.txtpo.Size = new System.Drawing.Size(166, 20);
            this.txtpo.TabIndex = 0;
            this.txtpo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpo_KeyDown);
            // 
            // POLabel
            // 
            this.POLabel.AutoSize = true;
            this.POLabel.Location = new System.Drawing.Point(41, 32);
            this.POLabel.Name = "POLabel";
            this.POLabel.Size = new System.Drawing.Size(32, 13);
            this.POLabel.TabIndex = 1;
            this.POLabel.Text = "PO#:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listlog);
            this.groupBox1.Location = new System.Drawing.Point(34, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 160);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志信息";
            // 
            // listlog
            // 
            this.listlog.FormattingEnabled = true;
            this.listlog.Location = new System.Drawing.Point(18, 19);
            this.listlog.Name = "listlog";
            this.listlog.Size = new System.Drawing.Size(381, 121);
            this.listlog.TabIndex = 0;
            // 
            // butstart
            // 
            this.butstart.Location = new System.Drawing.Point(308, 28);
            this.butstart.Name = "butstart";
            this.butstart.Size = new System.Drawing.Size(87, 21);
            this.butstart.TabIndex = 8;
            this.butstart.Text = "Start";
            this.butstart.UseVisualStyleBackColor = true;
            this.butstart.Click += new System.EventHandler(this.butstart_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numqty);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.butadd);
            this.panel1.Controls.Add(this.txtpn);
            this.panel1.Controls.Add(this.PNlabel);
            this.panel1.Location = new System.Drawing.Point(15, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 76);
            this.panel1.TabIndex = 9;
            this.panel1.Visible = false;
            // 
            // numqty
            // 
            this.numqty.Location = new System.Drawing.Point(82, 47);
            this.numqty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numqty.Name = "numqty";
            this.numqty.Size = new System.Drawing.Size(166, 20);
            this.numqty.TabIndex = 12;
            this.numqty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numqty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numqty_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "QTY:";
            // 
            // butadd
            // 
            this.butadd.Location = new System.Drawing.Point(294, 24);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(86, 28);
            this.butadd.TabIndex = 10;
            this.butadd.Text = "Add";
            this.butadd.UseVisualStyleBackColor = true;
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // txtpn
            // 
            this.txtpn.Location = new System.Drawing.Point(83, 11);
            this.txtpn.Name = "txtpn";
            this.txtpn.Size = new System.Drawing.Size(166, 20);
            this.txtpn.TabIndex = 9;
            this.txtpn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpn_KeyDown);
            // 
            // PNlabel
            // 
            this.PNlabel.AutoSize = true;
            this.PNlabel.Location = new System.Drawing.Point(26, 14);
            this.PNlabel.Name = "PNlabel";
            this.PNlabel.Size = new System.Drawing.Size(25, 13);
            this.PNlabel.TabIndex = 8;
            this.PNlabel.Text = "PN:";
            // 
            // Frmaccessory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 324);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butstart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.POLabel);
            this.Controls.Add(this.txtpo);
            this.Name = "Frmaccessory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frmaccessory";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numqty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpo;
        private System.Windows.Forms.Label POLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listlog;
        private System.Windows.Forms.Button butstart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numqty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butadd;
        private System.Windows.Forms.TextBox txtpn;
        private System.Windows.Forms.Label PNlabel;
    }
}