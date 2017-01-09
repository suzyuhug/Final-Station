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
    public partial class Frmwip : Form
    {
        public Frmwip()
        {
            InitializeComponent();
        }

        private void Frmwip_Load(object sender, EventArgs e)
        {
            string str = "exec usp_wipview";
            DataSet ds = new DataSet();
            ds = SqlHelper.ExcuteDataSet(str);
            if (ds!=null )
            {
                dataGridView1.DataSource = ds.Tables[0]; 
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >0)
            {           
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel文件（*.xls）|*.xls";               
                sfd.FilterIndex = 1;
                sfd.FileName = DateTime.Now.ToString("yyyymmddhhmmss") ;               
                sfd.RestoreDirectory = true;              
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string localFilePath = sfd.FileName.ToString();
                    //===============================================================
                    //    写入EXCEL功能

                  
                }


            }
        }
    }
}
