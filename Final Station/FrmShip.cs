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
            if (textBox1.Text != "")
            {
                Frmmessage frm = new Frmmessage();
                frm.Show();
                Application.DoEvents();
                try
                {
                    SqlConnection cn = new SqlConnection(Server_Class.SqlData);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_POsearch '" + textBox1.Text.Trim() + "'", cn);
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    Existpo = new DataTable();
                    dp.Fill(Existpo);

                    cn.Close();
                    nopo();
                    tovpo(textBox1.Text);

                    dataGridView1.DataSource = Existpo;
                    frm.Close();
                    if (dataGridView1.RowCount > 0)
                    {
                        button2.Visible = true;
                    }
                    else
                    {
                        button2.Visible = false;
                    }
                }
                catch (Exception err)
                {
                    frm.Close();
                    MessageBox.Show(err.Message);
                    textBox1.Clear(); textBox1.Focus();
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
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (textBox2.Text == dataGridView1.Rows[i].Cells["Location"].Value.ToString() && dataGridView1.Rows[i].Cells["zt"].Value == null)
                        {
                            dataGridView1.Rows[i].Cells["zt"].Value = "√";
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


                if (num == dataGridView1.RowCount)
                {
                    MessageBox.Show("备料完成", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dataGridView1.DataSource=null ;
                    tabControl1.Visible = false;
                    textBox1.Clear();textBox1.Focus();


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
