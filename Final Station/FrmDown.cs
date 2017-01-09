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
    public partial class Frmdown : Form
    {
        public Frmdown()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtloc.Text !="")
            {
                string strsql = $"exec usp_locempty '{txtloc.Text.Trim()}'";
                if (SqlHelper.ExecuteNonQuery(strsql))
                {
                    listBox1.Items.Insert(0,$"库位 {txtloc.Text } 已清空");
                    txtloc.Clear();txtloc.Focus();
                }
                else
                {
                    MessageBox.Show("Error:3008 数据库查询失败", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请输入Location", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }

        private void txtloc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
