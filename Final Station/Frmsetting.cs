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
    public partial class Frmsetting : Form
    {
        public Frmsetting()
        {
            InitializeComponent();
        }


        int i = 0;
        DataSet ds;
        private void LEDONOFF(object sender, EventArgs e)
        {
            i++;
            if (i <= PB.Maximum)
            {
                PB.Value = i;
                label2.Text = i + " 盏灯";
                if (LabLEDview.Text == "l")
                {
                    LabLEDview.Text = "";
                }
                else
                {
                    LabLEDview.Text = "l";
                }
               
                //===========================================================通过DS Table打开LED
            }
            else
            {
                button1.Text = "打开LED"; button2.Text = "关闭LED";
                button4.Visible = false; PB.Visible = false;
                label1.Visible = false; label2.Visible = false;
            }

        }

        private void LEDport()
        {

            try
            {
                string str = "exec usp_LEDONOFF";
                ds = SqlHelper.ExcuteDataSet(str);              
                PB.Maximum = ds.Tables[0].Rows.Count - 1;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "打开LED")
            {
                PB.Top = button1.Top + button1.Height;
                button4.Top = button1.Top;
                label1.Text = "已打开";
                butview();
            }
            else if (button1.Text == "停止")
            {
                timer1.Enabled = false;
                PB.Visible = false; button4.Visible = false;
                label1.Visible = false;label2.Visible = false;LabLEDview.Visible = false;


            }
            button1.Text = button1.Text == "打开LED" ? "停止" : "打开LED";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "关闭LED")
            {
                PB.Top = button2.Top + button2.Height;
                button4.Top = button2.Top;
                label1.Text = "已关闭";
                butview();
            }
            else if (button2.Text == "停止")
            {
                timer1.Enabled = false;
                PB.Visible = false; button4.Visible = false;
                label1.Visible = false; label2.Visible = false;
            }
            button2.Text = button2.Text == "关闭LED" ? "停止" : "关闭LED";
        }
        private void butview()
        {
            i = 0;
            button4.Text = "暂停";button1.Text = "打开LED";button2.Text = "关闭LED";
            PB.Visible = true;
            button4.Visible = true;
            LEDport();
            timer1.Enabled = true;
            label1.Visible = true; label2.Visible = true;LabLEDview.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "暂停")
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
            button4.Text = button4.Text == "暂停" ? "启动" : "暂停";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frmdown frm = new Frmdown();
            frm.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmTurnlocation  frm = new FrmTurnlocation();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frmwip frm = new Frmwip();
            frm.ShowDialog();
        }
    }
}
