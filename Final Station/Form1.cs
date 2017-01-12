using System;
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

       
       

        private void button2_Click(object sender, EventArgs e)
        {
            FrmShip ship =new FrmShip();
            ship.Show();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           
           
           
            try
            {


                SqlConnection cn = new SqlConnection(Server_Class.SqlData);
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_mainview", cn);
                SqlDataReader dr = cmd.ExecuteReader() ;
                while (dr.Read())
                {
                chart1.Series[0].Points[0].SetValueY(dr["existol"].ToString());
                chart1.Series[0].Points[1].SetValueY(dr["nullol"].ToString());
                }     
                   
                cn.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }


        }

        private void ButSetting_Click(object sender, EventArgs e)
        {
            Frmsetting setting = new Final_Station.Frmsetting();
            setting.Show();

        }

       
        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            Frmolview frm = new Final_Station.Frmolview();
            frm.ShowDialog();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void ButPtaway_Click(object sender, EventArgs e)
        {
            FrmPtaway frm = new FrmPtaway();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            toolStripStatusLabel2.Text = dt.ToString();



        }
    }
}
