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
    public partial class Frmtest : Form
    {
        public Frmtest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server_Class.LEDOnOff(textBox1.Text, int.Parse(textBox2.Text), textBox3.Text);
        }
    }
}
