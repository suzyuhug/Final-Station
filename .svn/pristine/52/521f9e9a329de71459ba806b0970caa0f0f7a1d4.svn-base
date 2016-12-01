using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Station
{
    public class Server_Class
    {
        public static string SqlData = "server=10.194.48.150\\MySQL;database=Final Station;uid=sa;pwd=Aa123456";
        public static string olval;
        public void onoffled(string ol,string onoffid)
        {
          
            try
            {
                SqlConnection cn = new SqlConnection(Server_Class.SqlData);
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_ONOFFLED '" + ol +"'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                string tempip=null ;int tempport=0;string tempmess=null;
                while (dr.Read())
                {
                    tempip = dr["LED_IP"].ToString();
                    tempport= int.Parse (dr["LED_Port"].ToString ());
                    tempmess= dr["LED_Message"].ToString();
                }

                System.Windows.Forms.MessageBox.Show(tempip +"   "+ tempport +"   "+ tempmess+"_"+onoffid);


                cn.Close();
            }
            catch (Exception err)
            {

                System.Windows.Forms.MessageBox.Show(err.Message);
            }




        }
    }   
}
