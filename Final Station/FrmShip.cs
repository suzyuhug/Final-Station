using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        DataTable NOpo;
        DataTable Existpo;
        private void nopo()
        {
            try
            {
                SqlConnection cn = new SqlConnection(Server_Class.SqlData);
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_POsearch ''", cn);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                NOpo = new DataTable();
                dp.Fill(NOpo);
                // dataGridView2.DataSource = NOpo;
                cn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }
        private void tovpo(string po)
        {

            try
            {
                string SqlData = "server=suznt019;database=TOV_BaaN;uid=TOV_TER;pwd=Tov@0916";
                SqlConnection cn = new SqlConnection(SqlData);
                cn.Open();
                string sql = "EXEC usp_PODetail_Extend '" + po + "',null";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dp.Fill(ds);
                cn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string tmeppn; string Category;
                    for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                    {
                        Category = ds.Tables[0].Rows[i]["Category"].ToString();
                        if (Category == "MC")
                        {
                            tmeppn = ds.Tables[0].Rows[i]["Component"].ToString();
                            DataRow[] ExistpoArr = Existpo.Select("PartNumber='" + tmeppn + "'");
                            if (ExistpoArr.Length <= 0)
                            {
                                DataRow[] NopoArr = NOpo.Select("PartNumber='" + tmeppn + "'");
                                if (NopoArr.Length > 0)
                                {
                                    DataRow row = Existpo.NewRow();
                                    row["PartNumber"] = tmeppn;
                                    row["Location"] = NopoArr[0]["Location"].ToString();
                                    Existpo.Rows.Add(row);

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtpo.Text, @"^\d{6}"))
            {
                Frmmessage frm = new Frmmessage();
                frm.Show();
                Application.DoEvents();
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
                            int qty = int.Parse(ds.Tables[0].Rows[i]["Extended Qty"].ToString());
                            GridViewPO.Rows.Insert(0);
                            GridViewPO.Rows[0].Cells["PartNumber"].Value = pn;
                            GridViewPO.Rows[0].Cells["QTY"].Value = qty;
                            string sql = $"exec usp_OLquery '{pn}'";
                            DataSet ds1 = new DataSet();
                            ds1 = SqlHelper.ExcuteDataSet(sql);
                            if (ds1.Tables[0].Rows.Count >0)
                            {
                                int q = 0;
                                for (int s = 0; s < ds1.Tables[0].Rows.Count; s++)
                                {
                                    int t = int.Parse(ds1.Tables[0].Rows[s]["Quantity"].ToString());
                                    q = t + q;
                                    if (q >= qty)
                                    {
                                        
                                        if (GridViewPO.Rows[0].Cells["Location"].Value == null)
                                        {
                                            GridViewPO.Rows[0].Cells["Location"].Value =ds1.Tables[0].Rows[s]["Location"].ToString();
                                        }
                                        else
                                        {
                                            GridViewPO.Rows[0].Cells["Location"].Value = $" {GridViewPO.Rows[0].Cells["Location"].Value}&{ds1.Tables[0].Rows[s]["Location"].ToString()}";
                                        }
                                       
                                        break;
                                    }

                                    if (q<qty)
                                    {
                                        if (GridViewPO.Rows[0].Cells["Location"].Value == null)
                                        {
                                            GridViewPO.Rows[0].Cells["Location"].Value =ds1.Tables[0].Rows[s]["Location"].ToString();
                                        }
                                        else
                                        {
                                            GridViewPO.Rows[0].Cells["Location"].Value = $"{ GridViewPO.Rows[0].Cells["Location"].Value}&{ds1.Tables[0].Rows[s]["Location"].ToString()}";
                                        }                                  
                                       
                                    }
                                           
                                }
                                 
                            } 
                        }
                    }

                    //==========================================
                    string posql = $"exec usp_BoxItemout '{int.Parse(txtpo.Text)}'";
                    DataSet ds2 = new DataSet();
                    ds2 = SqlHelper.ExcuteDataSet(posql);
                    if (ds2.Tables[0].Rows.Count >0)
                    {
                        for (int i = 0; i <ds2.Tables[0].Rows.Count; i++)
                        {
                            string boxpn = ds2.Tables[0].Rows[i]["PartNumber"].ToString();
                            for (int d = 0; d < GridViewPO.Rows.Count; d++)
                            {
                                if (GridViewPO.Rows[d].Cells["PartNumber"].Value.ToString() ==boxpn )
                                {
                                    GridViewPO.Rows[d].Cells["Location"].Value = ds2.Tables[0].Rows[i]["Location"].ToString();
                                   // break;
                                }

                            }

                        }

                    }

                    GridViewPO.DataSource = Existpo;
                }
               
            }
            else
            {
                MessageBox.Show("请输入PO#，不可以为空", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tabControl1.Visible = false;
            num = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            tabControl1.Visible = true;
            textBox2.Focus();
        }


        //=-==================================================================
        int num=0;
        int temp = 0;
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                temp = 0;
                    for (int i = 0; i < GridViewPO.RowCount; i++)
                    {
                        if (textBox2.Text == GridViewPO.Rows[i].Cells["Location"].Value.ToString() && GridViewPO.Rows[i].Cells["zt"].Value == null)
                        {
                            GridViewPO.Rows[i].Cells["zt"].Value = "√";
                        TakePart(textBox2.Text.Trim());
                            textBox2.Clear();
                            num++;
                            temp = 1;
                        }
                    }

                if (temp !=1)
                {
                    MessageBox.Show("请扫描正确的库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    textBox2.Clear();textBox2.Focus();
                }


                if (num == GridViewPO.RowCount)
                {
                    MessageBox.Show("备料完成", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    GridViewPO.DataSource=null ;
                    tabControl1.Visible = false;
                    txtpo.Clear();txtpo.Focus();


                }
               
            }
        }


        private void TakePart(string ol)
        {
            try
            {
                SqlConnection cn = new SqlConnection(Server_Class.SqlData);          
                SqlCommand cmd = new SqlCommand("usp_OutLoc '" + ol+ "'", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message );
            }

        }
       
    }
}
