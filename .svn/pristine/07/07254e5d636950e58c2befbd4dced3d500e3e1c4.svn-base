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
    public partial class Frmolview : Form
    {
        public Frmolview()
        {
            InitializeComponent();
        }

        private void Frmolview_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(Server_Class.SqlData);
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_Olview", cn);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dp.Fill(ds);
                cn.Close();
                dataGridView1.DataSource = ds.Tables[0];
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    int s =int.Parse (dataGridView1.Rows[i].Cells["zt"].Value.ToString()) ;
                    dataGridView1.Rows[i].Cells["st"].Value = imageList1.Images[s];
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
    }
}
