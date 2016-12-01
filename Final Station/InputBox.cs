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
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("请扫描一个库位，不可以为空", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();

            }
            else
            {
                Server_Class.olval = textBox1.Text.Trim();
                this.Close();
            }
        }
    }
}
