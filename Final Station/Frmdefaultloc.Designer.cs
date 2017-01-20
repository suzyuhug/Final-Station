namespace Final_Station
{
    partial class Frmdefaultloc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpn = new System.Windows.Forms.TextBox();
            this.txtol = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PartNumber:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location:";
            // 
            // txtpn
            // 
            this.txtpn.Location = new System.Drawing.Point(176, 42);
            this.txtpn.Name = "txtpn";
            this.txtpn.Size = new System.Drawing.Size(147, 20);
            this.txtpn.TabIndex = 2;
            this.txtpn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpn_KeyDown);
            // 
            // txtol
            // 
            this.txtol.Location = new System.Drawing.Point(176, 82);
            this.txtol.Name = "txtol";
            this.txtol.Size = new System.Drawing.Size(147, 20);
            this.txtol.TabIndex = 3;
            this.txtol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtol_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frmdefaultloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 265);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtol);
            this.Controls.Add(this.txtpn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frmdefaultloc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "默认库位绑定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpn;
        private System.Windows.Forms.TextBox txtol;
        private System.Windows.Forms.Button button1;
    }
}