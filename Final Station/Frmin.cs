using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Station
{
    public partial class Frmin : Form
    {
        public Frmin()
        {
            InitializeComponent();
            //========================================================

            //写到关闭备料时更新Partdata  de mark
            //========================================================
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtpn.Text != "")
            {
                string sn = null;
                if (txtsn.Visible == true && txtsn.Text != "")
                {
                    sn = txtsn.Text.Trim();
                }
                else
                {
                    sn = null;
                }
                string tmepid = null, Olid = null;
                string strsql = $"exec usp_OLNotnullInsertPN '{txtpn.Text.Trim()}','{sn}'";
                DataSet ds = new DataSet();
                ds = SqlHelper.ExcuteDataSet(strsql);
                if (ds != null)
                {
                    tmepid = ds.Tables[0].Rows[0]["out"].ToString();
                    Olid = ds.Tables[0].Rows[0]["ol"].ToString();
                }
                if (tmepid == "1")
                {

                    labloc.Text = Olid;
                    Server_Class.onoffled(Olid, 0);
                    affirmloc();


                    //====================================olid open led==================================================

                }
                else
                {
                    groupview();

                }




            }
        }
        private void groupview()
        {
            txtloc.Clear();
            groupBox.Width = 350;groupBox.Height = 200;
            groupBox.Left = (Width / 2) - (groupBox.Width / 2);
            groupBox.Top = (Height / 2) - (groupBox.Height / 2);
            groupBox.Visible = true;
            txtloc.Focus();
        }

        private void txtloc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                olnullinsert();
            }
        }
        private void olnullinsert()
        {
            if (txtloc.Text != "")
            {
                string sn = null;
                if (txtsn.Visible == true && txtsn.Text != "")
                {
                    sn = txtsn.Text.Trim();
                }
                else
                {
                    sn = null;
                }


                string strsql = $"exec usp_OLNullInsertPN '{txtloc.Text.Trim()}','{txtpn.Text.Trim()}','{sn}'";

                if (SqlHelper.ExcuteStr(strsql) == "1")
                {
                    groupBox.Visible = false;
                    labsn.Visible = false;txtsn.Visible = false;
                    txtpn.Clear();txtpn.Focus();
                    //======================LED灯闪烁=============================
                    leds(txtloc.Text);
                }
                else
                {
                    MessageBox.Show("库位不存在或库位上有料，请扫描正确的库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtloc.Clear();txtloc.Focus();
                }

            }

        }
        private void leds(string ol)
        {
            Server_Class.onoffled(ol, 0);
            Thread.Sleep(1000);
            Server_Class.onoffled(ol, 1);


        }

        private void butpo_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtpo.Text, @"^\d{6}"))
            {
                string strsql = $"exec usp_insertPO '{txtpo.Text}','{txtpoloc.Text}'";
                if (SqlHelper.ExcuteStr(strsql )=="1")
                {
                    leds(txtpoloc.Text);
                    txtpo.Clear();txtpoloc.Clear();txtpo.Focus();

                }
                else
                {
                    MessageBox.Show("库位上有料，请使用新的库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpoloc.Clear();txtpoloc.Focus();
                }
            }
        }

        private void txtpn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtpn.Text!="")
                {


                    if (txtpn.Text.Substring(0, 1) == "P")
                    {
                        txtpn.Text = txtpn.Text.Remove(0, 1);
                    }
                    txtsn.Clear();
                    string strsql = $"exec usp_SNDesired '{txtpn.Text}'";
                    if (SqlHelper.ExcuteStr(strsql) == "1")
                    {
                        labsn.Visible = true; txtsn.Visible = true;
                        txtsn.Focus();
                    }
                    else
                    {
                        button1_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("请输入料号，不可以为空", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtsn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void txtpo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpoloc.Focus();
            }
        }

        private void txtpoloc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               butpo_Click(sender,e);
            }

        }
        private void affirmloc()
        {
            panel1.Width = tabPage1.Width;
            panel1.Height = tabPage1.Height;
            panel1.Top = 0;panel1.Left = 0;
            groupBox1.Top = (panel1.Height / 2) - (groupBox1.Height / 2);
            groupBox1.Left = (panel1.Width / 2) - (groupBox1.Width / 2);
            labsn.Visible = false; txtsn.Visible = false;
            txtpn.Clear(); txtpn.Focus();
            panel1.Visible = true;
            txtrloc.Clear();txtrloc.Focus();

        }

        private void txtrloc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              
                if (txtrloc.Text==labloc.Text)
                {
                    //=====================关闭LED===================
                    Server_Class.onoffled(txtrloc.Text, 1);
                    panel1.Visible = false;
                    txtpn.Focus();

                }
                else
                {
                    MessageBox.Show("扫描正确的库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtrloc.Clear();txtrloc.Focus();

                }


            }

        }

        private void Frmin_Load(object sender, EventArgs e)
        {
           
        }
    }
}
