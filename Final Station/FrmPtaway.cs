using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
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
            if (txtpn.Text == "" && NumQty.Value <= 0)
            {
                MessageBox.Show("料号或数量错误", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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
                    DataRow dr = gds.Tables[0].NewRow();
                    string a = $"exec usp_PNDes '{txtpn.Text.Trim()}'";                   
                    dr["PartNumber"] = txtpn.Text.Trim();
                    dr["Location"] = Olid ;
                    dr["Quantity"] = NumQty.Value;
                    dr["Description"] = SqlHelper.ExcuteStr(a);
                    dr["DateAdded"] =DateTime.Now.ToString(); 
                    gds.Tables[0].Rows.InsertAt(dr, 0);
                    GridViewItem.DataSource = gds.Tables[0];
                    NumQty.Value = 1; txtpn.Clear(); txtpn.Focus();
                }
                else
                {
                    //MessageBox.Show($"无法给 {txtpn.Text} 分配库位，请点击确定手动选择库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InputBox input = new InputBox($"请输入{txtpn.Text}放置的库位");
                    input.ShowDialog();
                    Olid = Server_Class.olval;
                    if (Olid != null)
                    {
                        strsql = $"exec usp_OLNullInsertPO";

                        if (SqlHelper.ExcuteStr(strsql) == "1")
                        {
                            MessageBox.Show("保存成功", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            NumQty.Value = 1; txtpn.Clear(); txtpn.Focus();
                        }
                        else
                        {
                            MessageBox.Show("库位不存在或库位上有料，请扫描正确的库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
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

       
    }
}
