using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Station
{
    public class Server_Class
    {
        public static string SqlData = "server=10.194.48.150\\MySQL;database=Final Station;uid=sa;pwd=Aa123456";
        public static string olval;
        public void onoffled(string ol,int onoffid)
        {
            string strsql = $"exec usp_ONOFFLED '{ol}','{onoffid}'";
            DataSet ds = new DataSet();
            ds = SqlHelper.ExcuteDataSet(strsql);
            string gip, gmsg, pip, pmsg;
            int gport, pport, onoff;
            if (ds!=null)
            {
                if (ds.Tables[0].Rows.Count >0)
                {
                    gip = ds.Tables[0].Rows[0]["LED_IP"].ToString();
                    gport = int.Parse(ds.Tables[0].Rows[0]["LED_Port"].ToString());
                    gmsg = ds.Tables[0].Rows[0]["LED_Message"].ToString();
                    pip = ds.Tables[0].Rows[0]["LED_IP1"].ToString();
                    pport = int.Parse(ds.Tables[0].Rows[0]["LED_Port1"].ToString());
                    pmsg = ds.Tables[0].Rows[0]["LED_Message1"].ToString();
                    onoff =int.Parse(ds.Tables[0].Rows[0]["ONOFF"].ToString());
                    if (onoff == 0)
                    {
                        LEDOnOff(pip, pport, pmsg);
                    }
                    Thread.Sleep(200);
                    LEDOnOff(gip, gport, gmsg);
                    
                    
                }

            }

           
        }
        public void LEDOnOff(string ip,int port,string message)
        {
            
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(IPAddress.Parse(ip), port);
            NetworkStream ntwStream = tcpClient.GetStream();
            if (ntwStream.CanWrite)
            {
                Byte[] bytSend = Encoding.UTF8.GetBytes(message);
                ntwStream.Write(bytSend, 0, bytSend.Length);
            }
            else
            {               
                ntwStream.Close();
                tcpClient.Close();
                return;
            }
            ntwStream.Close();
            tcpClient.Close();
        }
    }   
}
