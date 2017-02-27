using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Station
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }      
       

        private void FrmMain_Load(object sender, EventArgs e)
        {
            label1.Text = "版本：" + Application.ProductVersion; 
        }

 
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            toolStripStatusLabel2.Text = dt.ToString();
        }

       

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Final_Station.Properties.Resources._1; 

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frmin frm = new Frmin();
            frm.Show();
        }      
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Final_Station.Properties.Resources._1_1 ;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Final_Station.Properties.Resources._2 ;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Final_Station.Properties.Resources._2_2;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Final_Station.Properties.Resources._3 ;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Final_Station.Properties.Resources._3_2 ;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmShip ship = new FrmShip();
            ship.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Frmsetting setting = new Final_Station.Frmsetting();
            setting.Show();
        }
    }
}
