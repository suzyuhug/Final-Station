using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Final_Station
{
    public partial class FrmPtaway : Form
    {
        public FrmPtaway()
        {
            InitializeComponent();
        }       
        private void txtpo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpn.Focus();
            }
        }

        private void txtpn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NumQty.Focus();
                NumQty.Select(0, NumQty.Value.ToString().Length);
            }
        }



        
        private void butenter_Click(object sender, EventArgs e)
        {
            string Olid = null;
            string tmepid = null;
            if (txtpn.Text == "" || NumQty.Value < 1)
            {
                MessageBox.Show("料号或数量错误", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtpn.Text.Substring(0, 1) == "P")
                {
                    txtpn.Text = txtpn.Text.Remove(0, 1);
                }

                string strsql = $"exec usp_OLNotnullInsertPN '{txtpn.Text.Trim()}','{NumQty.Value}'";
                DataSet ds = new DataSet();
                ds = SqlHelper.ExcuteDataSet(strsql);
                if (ds != null)
                {
                    tmepid = ds.Tables[0].Rows[0]["out"].ToString();
                    Olid = ds.Tables[0].Rows[0]["ol"].ToString();
                }
                if (tmepid == "1")
                {
                    //====================================olid open led==================================================
                    gbl = true;
                    Server_Class.onoffled(Olid, 0);
                    addlist(txtpn.Text.Trim(), Olid, NumQty.Value);
                }
                else
                {

                    //==========================加入错误报警信息======无法自动分配库位====================
                    gbl = false;
                    txtloc.Focus();

                    //InputBox input = new InputBox($"请输入{txtpn.Text}放置的库位");
                    //input.ShowDialog();
                    //Olid = Server_Class.olval;
                    //if (Olid != null)
                    //{
                    //    strsql = $"exec usp_OLNullInsertPN '{Olid}','{txtpn.Text.Trim()}','{NumQty.Value}'";

                    //    if (SqlHelper.ExcuteStr(strsql) == "1")
                    //    {

                    //        addlist(txtpn.Text.Trim(), Olid, NumQty.Value);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("库位不存在或库位上有料，请扫描正确的库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }

                    //}
                }
            }

        }
        private void insertloc(string ol)
        {
           
            
            if (ol!= "")
            {
                string strsql = $"exec usp_OLNullInsertPN '{ol}','{txtpn.Text.Trim()}','{NumQty.Value}'";

                if (SqlHelper.ExcuteStr(strsql) == "1")
                {

                    addlist(txtpn.Text.Trim(), ol, NumQty.Value);
                    leds(ol);


                }
                else
                {
                    MessageBox.Show("库位不存在或库位上有料，请扫描正确的库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private void leds(string ol)
        {
            Server_Class.onoffled(ol,0);
            Thread.Sleep(1000);
            Server_Class.onoffled(ol,1);


        }


        string gloc = null;
        bool gbl;
        private void addlist(string pn,string ol,Decimal qty)//===填加Gridview
        {

            DataRow dr = gds.Tables[0].NewRow();
            string a = $"exec usp_PNDes '{pn}'";
            dr["PartNumber"] = pn;
            dr["Location"] = ol;
            dr["Quantity"] = qty;
            dr["Description"] = SqlHelper.ExcuteStr(a);
            dr["DateAdded"] = DateTime.Now.ToString();
            gds.Tables[0].Rows.InsertAt(dr, 0);
            GridViewItem.DataSource = gds.Tables[0];
            if (gbl)
            {
                gloc = ol;
                txtloc.Focus();
            }
           


            

        }
        private void offled(String ol)
        {
            Server_Class.onoffled(ol, 1);

        }
        DataSet gds = new DataSet();
        private void FrmPtaway_Load(object sender, EventArgs e)
        {
           
            string strsql = $"exec usp_ExistItem";
           // DataSet gds = new DataSet();
            gds = SqlHelper.ExcuteDataSet(strsql);
            if (gds!=null)
            {
                GridViewItem.DataSource = gds.Tables[0];
               
            }
        }

        private void 附件上架ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmaccessory frm = new Frmaccessory();
            frm.ShowDialog();
        }

        private void NumQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butenter_Click(sender,e);
            }
        }

        private void txtloc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtlockey(gloc);                
            }
           
        }
        private void txtlockey(string gloc)
        {

            if (txtloc.Text == gloc && gbl)
            {
                offled(txtloc.Text);
                NumQty.Value = 1; txtpn.Clear();txtloc.Clear(); txtpn.Focus();
            }
            else if (txtloc.Text!=""  && !gbl)
            {
                insertloc(txtloc.Text );
                NumQty.Value = 1; txtpn.Clear();txtloc.Clear(); txtpn.Focus();
            }
            else
            {
                MessageBox.Show("请扫描正确的库位号！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtloc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
