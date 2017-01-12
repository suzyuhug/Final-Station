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
    public partial class Frmonoffled : Form
    {
        public Frmonoffled()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtloc.Text!="")
            {
                int a=0;
                if (radioButton1.Checked==true )
                {
                    a = 0;
                }
                else if (radioButton2.Checked=true )
                {
                    a = 1;
                }
                Server_Class.onoffled(txtloc.Text,a);
                txtloc.Clear();txtloc.Focus();
            }
        }

        private void txtloc_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void txtloc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,e);
            }
        }
    }
}
