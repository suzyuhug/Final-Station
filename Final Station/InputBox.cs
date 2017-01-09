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
        string messtr = null;
        public InputBox(string str)
        {
            InitializeComponent();
            messtr = str;

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

        private void InputBox_Load(object sender, EventArgs e)
        {
            label1.Text = messtr;
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }       
        }
    }
}
