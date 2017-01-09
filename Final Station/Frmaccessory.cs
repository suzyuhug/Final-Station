﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Final_Station
{
    public partial class Frmaccessory : Form
    {
        public Frmaccessory()
        {
            InitializeComponent();
        }

        private void butadd_Click(object sender, EventArgs e)
        {
            
            if (!Regex.IsMatch(txtpn.Text.Trim(),"TDN-?"))
            {
                MessageBox.Show("请输入正确的PartNumber", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpn.Clear();txtpn.Focus();
                return;
            }
            if (numqty.Value < 1)
            {
                MessageBox.Show("请输入正确的数量", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numqty.Value = 1; numqty.Select(0, numqty.Value.ToString().Length);
                return;
            }
            string strsql = $"exec usp_InsertBoxItem '{int.Parse(txtpo.Text )}','{txtpn.Text.Trim()}','{numqty.Value}'";
            if (SqlHelper.ExecuteNonQuery(strsql))
            {
                listlog.Items.Insert(0,$"PO:{txtpo.Text}  PN:{txtpn.Text}  QTY:{numqty.Value}");
                txtpn.Clear();numqty.Value = 1;
                txtpn.Focus();
            }
            else
            {
                MessageBox.Show("数据保存失败，请重试", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void butstart_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch (txtpo.Text , @"^\d{6}"))
            {
                if (butstart.Text == "Start")
                {
                    txtpo.Enabled = false;
                    panel1.Visible = true;
                    butstart.Text = "End";
                    txtpn.Focus();
                }
                else if (butstart.Text == "End")
                {
                    txtpo.Enabled = true;
                    txtpo.Clear();
                    txtpo.Focus();
                    panel1.Visible = false;
                    butstart.Text = "Start";
                }
            }
            else 
            {
                MessageBox.Show("请输入正确的PO号", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpo.Focus();
            }

               
            
           
           
        }

        private void txtpn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numqty.Focus();
                numqty.Select(0, numqty.Value.ToString().Length);
            }
        }

        private void numqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butadd_Click(sender,e);
            }
        }

        private void txtpo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butstart_Click(sender,e);
            }
        }
    }
}
