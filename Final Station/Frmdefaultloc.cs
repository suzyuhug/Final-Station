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
    public partial class Frmdefaultloc : Form
    {
        public Frmdefaultloc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpn.Text!="" && txtol.Text!="")
            {
                if (txtpn.Text.Substring(0, 1) == "P")
                {
                    txtpn.Text = txtpn.Text.Remove(0, 1);
                }
                string strsql = $"exec usp_insertDefloc '{txtpn.Text}','{txtol.Text}'";
                if (SqlHelper.ExecuteNonQuery(strsql) )
                {
                    Server_Class.onoffled(txtol.Text,0); 
                  
                    if (checkBox1.Checked ==false)
                    {
                        txtpn.Clear(); txtol.Clear(); txtpn.Focus();
                    }
                    else
                    {
                        txtol.Clear(); txtol.Focus();
                    }

                }
            }
        }

        private void txtpn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtol.Focus();

            }
        }

        private void txtol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,e);
            }
        }
    }
}
