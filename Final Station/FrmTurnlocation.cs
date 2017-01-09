using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Station
{
    public partial class FrmTurnlocation : Form
    {
        public FrmTurnlocation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnew.Text != "" && txtold.Text != "")
            {


                string strsql = $"exec usp_Turnlocation '{txtnew.Text.Trim()}','{txtold.Text.Trim()}'";
                string a = SqlHelper.ExcuteStr(strsql);
                if (a == "0")
                {
                    MessageBox.Show("新的库位上有料，无法转移库位", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listBox1.Items.Insert(0, $"{txtold.Text}无法转移到{txtnew.Text}库位");
                    txtnew.Clear(); txtnew.Focus();
                }
                else if (a == "1")
                {
                    listBox1.Items.Insert(0, $"{txtold.Text}成功转移到{txtnew.Text}库位");
                    txtnew.Clear(); txtold.Clear(); txtold.Focus();
                }
               
            }
            else
            {
                MessageBox.Show("新的库位或老的库位不能为空", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
