namespace Final_Station
{
    partial class Frmin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtrloc = new System.Windows.Forms.TextBox();
            this.txtsn = new System.Windows.Forms.TextBox();
            this.labsn = new System.Windows.Forms.Label();
            this.labloc = new System.Windows.Forms.Label();
            this.txtpn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtpoloc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtloc = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(29, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 543);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.txtsn);
            this.tabPage1.Controls.Add(this.labsn);
            this.tabPage1.Controls.Add(this.labloc);
            this.tabPage1.Controls.Add(this.txtpn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(831, 517);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "通过料号上架";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(737, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(31, 26);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtrloc);
            this.groupBox1.Location = new System.Drawing.Point(132, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 104);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "确认库位";
            // 
            // txtrloc
            // 
            this.txtrloc.Location = new System.Drawing.Point(52, 37);
            this.txtrloc.Name = "txtrloc";
            this.txtrloc.Size = new System.Drawing.Size(123, 20);
            this.txtrloc.TabIndex = 0;
            this.txtrloc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtrloc_KeyDown);
            // 
            // txtsn
            // 
            this.txtsn.Location = new System.Drawing.Point(142, 82);
            this.txtsn.Name = "txtsn";
            this.txtsn.Size = new System.Drawing.Size(200, 20);
            this.txtsn.TabIndex = 5;
            this.txtsn.Visible = false;
            this.txtsn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsn_KeyDown);
            // 
            // labsn
            // 
            this.labsn.AutoSize = true;
            this.labsn.Location = new System.Drawing.Point(51, 85);
            this.labsn.Name = "labsn";
            this.labsn.Size = new System.Drawing.Size(85, 13);
            this.labsn.TabIndex = 4;
            this.labsn.Text = "Serial Number：";
            this.labsn.Visible = false;
            // 
            // labloc
            // 
            this.labloc.AutoSize = true;
            this.labloc.Location = new System.Drawing.Point(746, 42);
            this.labloc.Name = "labloc";
            this.labloc.Size = new System.Drawing.Size(50, 13);
            this.labloc.TabIndex = 3;
            this.labloc.Text = "LOCview";
            // 
            // txtpn
            // 
            this.txtpn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpn.Location = new System.Drawing.Point(142, 35);
            this.txtpn.Name = "txtpn";
            this.txtpn.Size = new System.Drawing.Size(200, 20);
            this.txtpn.TabIndex = 1;
            this.txtpn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpn_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Number：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtpoloc);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtpo);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(831, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "通过PO上架";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtpoloc
            // 
            this.txtpoloc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpoloc.Location = new System.Drawing.Point(111, 86);
            this.txtpoloc.Name = "txtpoloc";
            this.txtpoloc.Size = new System.Drawing.Size(161, 20);
            this.txtpoloc.TabIndex = 4;
            this.txtpoloc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpoloc_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loc:";
            // 
            // txtpo
            // 
            this.txtpo.Location = new System.Drawing.Point(111, 45);
            this.txtpo.MaxLength = 6;
            this.txtpo.Name = "txtpo";
            this.txtpo.Size = new System.Drawing.Size(161, 20);
            this.txtpo.TabIndex = 1;
            this.txtpo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "PO#:";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.checkBox1);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtloc);
            this.groupBox.Location = new System.Drawing.Point(757, 1);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(33, 20);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "请扫描库位";
            this.groupBox.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(117, 85);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "保存到默认库位";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "PS:无法自动分配库位，请手动扫描库位";
            // 
            // txtloc
            // 
            this.txtloc.Location = new System.Drawing.Point(81, 59);
            this.txtloc.Name = "txtloc";
            this.txtloc.Size = new System.Drawing.Size(188, 20);
            this.txtloc.TabIndex = 0;
            this.txtloc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtloc_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 583);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(897, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Final_Station.Properties.Resources.i1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(218, 22);
            this.toolStripLabel1.Text = "PS:键盘输入时，输入完成请按回车键     ";
            // 
            // Frmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 608);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IN Main";
            this.Load += new System.EventHandler(this.Frmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtpn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtpo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labloc;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtloc;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtpoloc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsn;
        private System.Windows.Forms.Label labsn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtrloc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}