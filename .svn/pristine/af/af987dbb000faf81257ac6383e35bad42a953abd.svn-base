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
        SqlConnection cn  = new SqlConnection(Server_Class.SqlData);
        SqlCommand cmd;       
        SqlDataReader dr;
        string sql;

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
                butenter.Focus();
                butenter_Click(sender, e);


            }
        }
      



        private void butenter_Click(object sender, EventArgs e)
        {
            string Olid=null ;
            string tmepid = null;
            if (txtpn.Text == "" && txtpo.Text == "")
            {
                MessageBox.Show("PO与PN必须输入一个", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {                   
                    sql = "exec usp_OLNotnullInsertPO '" + txtpo.Text.Trim() + "','"+ txtpn.Text.Trim() + "'";
                    cn.Open();
                    cmd = new SqlCommand(sql, cn);
                    dr = cmd.ExecuteReader() ;
                    while (dr.Read())
                    {
                        tmepid=dr["out"].ToString();
                        Olid = dr["ol"].ToString();
                    }                  
                    cn.Close();
                    if (tmepid=="1")
                    {
                        //====================================olid open led==================================================
                        MessageBox.Show("保存成功", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk );
                        txtpo.Clear(); txtpo.Focus();txtpn.Clear();txtpn.Focus();
                    }
                    else
                    {
                        MessageBox.Show("无法自动分配库位，请手动选择一个库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        InputBox input = new InputBox();
                        input.ShowDialog();
                        Olid = Server_Class.olval;
                        if (Olid !=null)
                        {
                            sql = "exec usp_OLNullInsertPO '" + Olid + "','" + txtpo.Text.Trim() + "','" + txtpn.Text.Trim() + "'";
                            cn.Open();
                            cmd = new SqlCommand(sql, cn);
                            dr = cmd.ExecuteReader();
                            string i = null;
                            while (dr.Read())
                            {
                                i = dr["out"].ToString();
                            }
                            cn.Close();
                            if (i == "1")
                            {
                                MessageBox.Show("保存成功", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                txtpo.Clear(); txtpo.Focus(); txtpn.Clear(); txtpn.Focus();
                            }
                            else
                            {
                                MessageBox.Show("库位不存在或库位上有料，请扫描正确的库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }                  
                }
                catch (Exception)
                {
                    MessageBox.Show("数据库查询失败", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }     
    }
}
