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
           
        }
        string str="没有错误消息";

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
                }
                else
                {
                    Server_Class.Error("3");
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
                    leds(txtloc.Text);
                }
                else
                {
                    Server_Class.Error("0");
                    str = "库位不存在或库位上有料，请扫描正确的库位";                  
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
                    Server_Class.Error("0");
                    str = "库位上有料，请使用新的库位";                    
                    txtpoloc.Clear();txtpoloc.Focus();
                }
            }
        }

        private void txtpn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtpn.Text.Substring(0, 4) == "TDN-" || txtpn.Text.Substring(0, 5) == "PTDN-")
                {
                    if (txtpn.Text.Substring(0, 1) == "P")
                    {
                        txtpn.Text = txtpn.Text.Remove(0, 1);
                    }
                    txtsn.Clear();
                    string strsql = $"exec usp_SNDesired '{txtpn.Text}'";
                    if (SqlHelper.ExcuteStr(strsql) == "1")
                    {
                        Server_Class.Error("1");
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
                    str = "请输入正确的料号";
                    Server_Class.Error("0");
                    txtpn.Clear();txtpn.Focus();                   
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
                    Server_Class.onoffled(txtrloc.Text, 1);
                    Thread.Sleep(200);
                    Server_Class.Error("2");                  
                    panel1.Visible = false;
                    txtpn.Focus();
                }
                else
                {
                    Server_Class.Error("0");
                    str = "扫描正确的库位";                 
                    txtrloc.Clear();txtrloc.Focus();

                }
            }
        }
       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(str, "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Frmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Server_Class.offled();
        }

        private void Frmin_Load(object sender, EventArgs e)
        {

        }
    }
}
