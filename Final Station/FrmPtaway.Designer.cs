﻿namespace Final_Station
{
    partial class FrmPtaway
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPtaway));
            this.label1 = new System.Windows.Forms.Label();
            this.txtpn = new System.Windows.Forms.TextBox();
            this.butenter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NumQty = new System.Windows.Forms.NumericUpDown();
            this.GridViewItem = new System.Windows.Forms.DataGridView();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.附件上架ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.txtloc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewItem)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "P/N:";
            // 
            // txtpn
            // 
            this.txtpn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpn.Location = new System.Drawing.Point(128, 46);
            this.txtpn.Name = "txtpn";
            this.txtpn.Size = new System.Drawing.Size(180, 29);
            this.txtpn.TabIndex = 3;
            this.txtpn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpn_KeyDown);
            // 
            // butenter
            // 
            this.butenter.Location = new System.Drawing.Point(385, 84);
            this.butenter.Name = "butenter";
            this.butenter.Size = new System.Drawing.Size(80, 38);
            this.butenter.TabIndex = 4;
            this.butenter.Text = "Enter";
            this.butenter.UseVisualStyleBackColor = true;
            this.butenter.Click += new System.EventHandler(this.butenter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "QTY:";
            // 
            // NumQty
            // 
            this.NumQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumQty.Location = new System.Drawing.Point(128, 93);
            this.NumQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumQty.Name = "NumQty";
            this.NumQty.Size = new System.Drawing.Size(180, 29);
            this.NumQty.TabIndex = 6;
            this.NumQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumQty_KeyDown);
            // 
            // GridViewItem
            // 
            this.GridViewItem.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridViewItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridViewItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartNumber,
            this.Location,
            this.Quantity,
            this.Description,
            this.InsertDate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridViewItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridViewItem.Location = new System.Drawing.Point(27, 219);
            this.GridViewItem.Name = "GridViewItem";
            this.GridViewItem.RowHeadersVisible = false;
            this.GridViewItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewItem.Size = new System.Drawing.Size(917, 366);
            this.GridViewItem.TabIndex = 7;
            // 
            // PartNumber
            // 
            this.PartNumber.DataPropertyName = "PartNumber";
            this.PartNumber.HeaderText = "PartNumber";
            this.PartNumber.Name = "PartNumber";
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // InsertDate
            // 
            this.InsertDate.DataPropertyName = "DateAdded";
            this.InsertDate.HeaderText = "InsertDate";
            this.InsertDate.Name = "InsertDate";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.附件上架ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 附件上架ToolStripMenuItem
            // 
            this.附件上架ToolStripMenuItem.Name = "附件上架ToolStripMenuItem";
            this.附件上架ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.附件上架ToolStripMenuItem.Text = "附件上架";
            this.附件上架ToolStripMenuItem.Click += new System.EventHandler(this.附件上架ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 610);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(971, 40);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "LOC:";
            // 
            // txtloc
            // 
            this.txtloc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtloc.Location = new System.Drawing.Point(128, 145);
            this.txtloc.Name = "txtloc";
            this.txtloc.Size = new System.Drawing.Size(180, 29);
            this.txtloc.TabIndex = 11;
            this.txtloc.TextChanged += new System.EventHandler(this.txtloc_TextChanged);
            this.txtloc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtloc_KeyDown);
            // 
            // FrmPtaway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 650);
            this.Controls.Add(this.txtloc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.GridViewItem);
            this.Controls.Add(this.NumQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butenter);
            this.Controls.Add(this.txtpn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPtaway";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IN Main";
            this.Load += new System.EventHandler(this.FrmPtaway_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewItem)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpn;
        private System.Windows.Forms.Button butenter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumQty;
        private System.Windows.Forms.DataGridView GridViewItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 附件上架ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertDate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtloc;
    }
}