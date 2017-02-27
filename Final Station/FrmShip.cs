using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Station
{
    public partial class FrmShip : Form
    {
        public FrmShip()
        {
            InitializeComponent();
        }
       // DataTable NOpo;
        //DataTable Existpo;
        //private void nopo()
        //{
        //    try
        //    {
        //        SqlConnection cn = new SqlConnection(Server_Class.SqlData);
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand("usp_POsearch ''", cn);
        //        SqlDataAdapter dp = new SqlDataAdapter(cmd);
        //        NOpo = new DataTable();
        //        dp.Fill(NOpo);
        //        // dataGridView2.DataSource = NOpo;
        //        cn.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);

        //    }

        //}
        //private void tovpo(string po)
        //{

        //    try
        //    {
        //        string SqlData = "server=suznt019;database=TOV_BaaN;uid=TOV_TER;pwd=Tov@0916";
        //        SqlConnection cn = new SqlConnection(SqlData);
        //        cn.Open();
        //        string sql = "EXEC usp_PODetail_Extend '" + po + "',null";
        //        SqlCommand cmd = new SqlCommand(sql, cn);
        //        SqlDataAdapter dp = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        dp.Fill(ds);
        //        cn.Close();
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            string tmeppn; string Category;
        //            for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
        //            {
        //                Category = ds.Tables[0].Rows[i]["Category"].ToString();
        //                if (Category == "MC")
        //                {
        //                    tmeppn = ds.Tables[0].Rows[i]["Component"].ToString();
        //                    DataRow[] ExistpoArr = Existpo.Select("PartNumber='" + tmeppn + "'");
        //                    if (ExistpoArr.Length <= 0)
        //                    {
        //                        DataRow[] NopoArr = NOpo.Select("PartNumber='" + tmeppn + "'");
        //                        if (NopoArr.Length > 0)
        //                        {
        //                            DataRow row = Existpo.NewRow();
        //                            row["PartNumber"] = tmeppn;
        //                            row["Location"] = NopoArr[0]["Location"].ToString();
        //                            Existpo.Rows.Add(row);

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}
        private void upmark()
        {
            string strsql = "exec usp_updatemark";
            SqlHelper.ExecuteNonQuery(strsql); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtpo.Text, @"^\d{6}"))
            {
                Frmmessage frm = new Frmmessage();
                frm.Show();            
                Application.DoEvents();
                GridViewPO.Rows.Clear();
                string strsql = $"EXEC usp_PODetail_Extend '{int.Parse(txtpo.Text)}',null";
                DataSet ds = new DataSet();
                ds = SqlHelper.ExcutePODataSet(strsql);
                string Category;
                if (ds.Tables[0].Rows.Count >0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count-1 ; i++)
                    {
                        Category = ds.Tables[0].Rows[i]["Category"].ToString();
                        if (Category=="MC")
                        {
                            string pn = ds.Tables[0].Rows[i]["Component"].ToString();
                            string strsql1 = $"exec usp_OLquery '{pn}'";
                            string ol = SqlHelper.ExcuteStr(strsql1); 
                            if (ol!="")
                            {
                                GridViewPO.Rows.Insert(0);
                                GridViewPO.Rows[0].Cells["Location"].Value = ol;
                                GridViewPO.Rows[0].Cells["PartNumber"].Value = pn;
                                GridViewPO.Rows[0].Cells["POslot"].Value = "";
                            }
                        }
                    }

                    string strsql2 = $"exec usp_POquery '{txtpo.Text}'";
                    DataSet ds1 = new DataSet();
                    ds1 = SqlHelper.ExcuteDataSet(strsql2);
                    if (ds1.Tables[0].Rows.Count>0)
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            GridViewPO.Rows.Insert(0);
                            GridViewPO.Rows[0].Cells["Location"].Value =ds1.Tables[0].Rows[i]["Location"].ToString();
                            GridViewPO.Rows[0].Cells["PartNumber"].Value = "";
                            GridViewPO.Rows[0].Cells["POslot"].Value =txtpo.Text;

                        }

                    }
                    if (GridViewPO.Rows.Count >0)
                    {
                        button2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("此PO所需要的物料货架上没有", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpo.Clear();txtpo.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("请输入正确PO，PO不存在", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
                frm.Close();               
            }
            else
            {
                MessageBox.Show("请输入PO#，不可以为空", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        int num1 = 0;
        private void button2_Click(object sender, EventArgs e)
        {
                                
            button2.Visible = false;
            tabControl1.Visible = true;
            textBox2.Focus();
            Application.DoEvents();           
            Thread th = new Thread(thled);
            th.Start();


        }

        private void thled()
        {
            Server_Class.Error("1");
            Thread.Sleep(1000);
            this.Invoke((EventHandler)delegate
        {                     
            num1 = 0;
          
            for (int i = 0; i < GridViewPO.RowCount; i++)
            {
                if (GridViewPO.Rows[i].Cells["Location"].Value.ToString() != "")
                {
                    num1++;                                     
                    Server_Class.onoffled(GridViewPO.Rows[i].Cells["Location"].Value.ToString(), 0);
                }
            }           
        });          
        }


        int num=0;
        int temp = 0;
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                temp = 0;
                for (int i = 0; i < GridViewPO.RowCount; i++)
                {
                    if (GridViewPO.Rows[i].Cells["Location"].Value != null)
                    {
                        if (textBox2.Text == GridViewPO.Rows[i].Cells["Location"].Value.ToString() && GridViewPO.Rows[i].Cells["zt"].Value == null)
                        {
                            GridViewPO.Rows[i].Cells["zt"].Value = "√";
                            TakePart(textBox2.Text.Trim());
                            Server_Class.onoffled(textBox2.Text.Trim(),1);
                            textBox2.Clear();
                            num++;
                            temp = 1;
                            break;
                        }
                    }
                }

                if (temp != 1)
                {
                    Server_Class.Error("0");
                    str = "请扫描正确的库位";
                  
                    textBox2.Clear(); textBox2.Focus();
                }


                if (num ==num1)
                {
                    Thread.Sleep(1000);
                    Server_Class.Error("2");                   
                    MessageBox.Show("备料完成", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    GridViewPO.DataSource = null;
                    tabControl1.Visible = false;
                    txtpo.Clear(); txtpo.Focus();
                }
            }
        }


        private void TakePart(string ol)
        {
            string strsql = "usp_OutLoc '" + ol + "'";
            SqlHelper.ExecuteNonQuery(strsql);
        }

        private void txtpo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,e);
            }        
        }

        private void FrmShip_Load(object sender, EventArgs e)
        {
      
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtpn.Text!=""||txtsn.Text !="")
            {
                if (txtpn.Text!="")
                {
                    if (txtpn.Text.Substring(0, 1) == "P")
                    {
                        txtpn.Text = txtpn.Text.Remove(0, 1);
                    }
                }               
                string strsql = $"exec usp_searchItem '{txtpn.Text.Trim()}','{txtsn.Text.Trim()}'";
                DataSet ds = new DataSet();
                ds = SqlHelper.ExcuteDataSet(strsql);
                if (ds!=null)
                {
                    if (ds.Tables[0].Rows.Count >0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("没有查到任何记录", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpn.Clear();txtsn.Clear();txtpn.Focus();
                    }                  
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (dataGridView1.CurrentRow.Cells ["Column5"].Value.ToString()=="取料" )
                {
                    label6.Text = dataGridView1.CurrentRow.Cells["Column1"].Value.ToString();
                    Server_Class.onoffled(label6.Text,0);
                    dataGridView1.CurrentRow.Cells["Column5"].Value = "拿走了";
                    enterloc();
                }
            }
        }

        private void enterloc()
        {
            panel1.Width = tabPage3.Width;
            panel1.Height = tabPage3.Height;
            panel1.Top = 0;panel1.Left = 0;
            groupBox1.Top = (panel1.Height / 2) - (groupBox1.Height / 2);
            groupBox1.Left = (panel1.Width / 2) - (groupBox1.Width / 2);
            panel1.Visible = true;
            txtrloc.Focus();
        }

        private void txtrloc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtrloc.Text==label6.Text)
                {
                    string strsql = $"exec usp_pnout '{txtrloc.Text.Trim()}'";
                    if (SqlHelper.ExecuteNonQuery(strsql))
                    {
                        Server_Class.onoffled(txtrloc.Text ,1);
                        panel1.Visible = false;
                        txtpn.Clear();txtsn.Clear();txtpn.Focus();                        
                    }
                }
                else
                {
                    Server_Class.Error("0");
                    str = "请扫描正确的库位";                 
                    txtrloc.Clear();txtrloc.Focus();
                }
            }
        }

        private void FrmShip_FormClosed(object sender, FormClosedEventArgs e)
        {
            upmark();
            Server_Class.offled();
        }
        string str = "没有错误消息";
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(str, "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
