using System;
using System.Collections;
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
        public static string SqlData = "server=suznt004;user id=andy;password=123;database=FindStation;Connect Timeout=5";
        public static string olval;
        public static ArrayList list1 = new ArrayList();
        public static void onoffled(string ol,int onoffid)
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
                    if (onoffid==0)
                    {
                        Server_Class.list1.Add(ol);
                    }
                    else if(onoffid ==1)
                    {
                        Server_Class.list1.Remove(ol);
                    }

                    gip = ds.Tables[0].Rows[0]["LED_IP"].ToString();
                    gport = int.Parse(ds.Tables[0].Rows[0]["LED_Port"].ToString());
                    gmsg = $"{ds.Tables[0].Rows[0]["LED_Message"].ToString()}_{onoffid}";
                    pip = ds.Tables[0].Rows[0]["LED_IP1"].ToString();
                    pport = int.Parse(ds.Tables[0].Rows[0]["LED_Port1"].ToString());
                    pmsg = $"{ds.Tables[0].Rows[0]["LED_Message1"].ToString()}_{onoffid}";
                    onoff =int.Parse(ds.Tables[0].Rows[0]["ONOFF"].ToString());
                    if (onoff == 0)
                    {
                        Thread.Sleep(200);
                        LEDOnOff(pip, pport, pmsg);
                    }
                    Thread.Sleep(200);
                    LEDOnOff(gip, gport, gmsg);
                    
                    
                }

            }

           
        }
       public static  bool bl=true;

        public static void Error(string id)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Error1));
            t.Start(id);
        }
        public static void Error1(object data)
        {
            string id = data as string;
            if (Server_Class.bl)
            {


                Server_Class.bl = false;
                string tempip = "192.168.0.55";
                int tempport = 1031;
                string redled = "led23", yellowled = "led17", greenled = "led19", sound = "led21";

                switch (id)
                {
                    case "0"://red led

                        LEDOnOff(tempip, tempport, sound + "_0");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, redled + "_0");
                        Thread.Sleep(1000);
                        LEDOnOff(tempip, tempport, redled + "_1");                        
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_1");
                        break;
                    case "1"://yellow led
                        LEDOnOff(tempip, tempport, sound + "_0");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, yellowled + "_0");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_1");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_0");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, yellowled + "_1");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_1");                                             
                        break;
                    case "2"://green led
                        LEDOnOff(tempip, tempport, greenled + "_0");                       
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_0");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_1");                        
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, greenled + "_1");
                        break;
                    case "3"://sound
                        LEDOnOff(tempip, tempport, sound + "_0");
                        Thread.Sleep(200);                                         
                        LEDOnOff(tempip, tempport, sound + "_1");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_0");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_1");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_0");
                        Thread.Sleep(200);
                        LEDOnOff(tempip, tempport, sound + "_1");
                        break;

                    default:
                        break;
                }
                Server_Class.bl = true;
            }
        }
        public static void offled()
        {
            string strsql = "exec usp_updatePortStatus";
            SqlHelper.ExecuteNonQuery(strsql);

            int s = Server_Class.list1.Count;
            if (s >0)
            {
                for (int i = 0; i < s; i++)
                {
                    Server_Class.onoffled(Server_Class.list1[0].ToString(),1);

                }

            }


        }
        public static void LEDOnOff(string ip,int port,string message)
        {
            bool bl =true ;
            if (bl)
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
            else
            {

            }
           
        }
    }   
}
