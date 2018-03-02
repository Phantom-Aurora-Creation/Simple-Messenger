using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using static SimpleMessager.Main;

namespace SimpleMessager
{
    class SocketWorker
    {
        /// <summary>
        /// 初始化 Socket 实体
        /// </summary>
        private static Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        /// <summary>
        /// 初始化 Thread 实体
        /// </summary>
        private static Thread thread = new Thread(ReciveWorker);

        /// <summary>
        /// 暂无用途
        /// </summary>
        private static void Init() { }

        /// <summary>
        /// 连接到某个网络地址
        /// </summary>
        /// <param name="ip">目标IP地址</param>
        /// <param name="port">目标的端口号</param>
        /// <returns>连接建立的时间，格式：yyyyMMddHHmm</returns>
        public static string Connect(IPAddress ip, int port)
        {
            socket.Connect(ip, port);
            return TimeStamp();
        }

        /// <summary>
        /// 连接到某个网络地址
        /// </summary>
        /// <param name="host">目标域名</param>
        /// <param name="port">目标的端口号</param>
        /// <returns>连接建立的时间，格式：yyyyMMddHHmm</returns>
        public static string Connect(string host, int port)
        {
            socket.Connect(host, port);
            return TimeStamp();
        }

        /// <summary>
        /// 向已连接的网络地址发送消息
        /// </summary>
        /// <param name="str">要发送的消息</param>
        /// <returns>若成功则返回 Main.success ，若失败则返回错误</returns>
        public static string Post(string str)
        {
            byte[] buffer = Encoding.Default.GetBytes(str);
            try
            {
                socket.Send(buffer);
            }
            catch(Exception ex)
            {
                return Convert.ToString(ex);
            }

            return Main.success;
        }

        /// <summary>
        /// 建立新的线程接收已连接的网络地址发来的消息
        /// </summary>
        public static void Recive()
        {
            thread.IsBackground = true;
            thread.Start(socket);
        }

        /// <summary>
        /// 终止接收线程，关闭Socket
        /// </summary>
        public static void Exit()
        {
            //MessageBox.Show("");
            thread.Abort();
            socket.Close();
        }

        /// <summary>
        /// 接收线程的执行体
        /// </summary>
        /// <param name="o"></param>
        private static void ReciveWorker(object o)
        {
            Socket send = o as Socket;
            int i = 0;
            while (Main.recivable)
            {
                byte[] buffer = new byte[1024 * 1024 * 2];
                int effective = send.Receive(buffer);
                if (effective == 0)
                {
                    //break;
                }
                string str = Encoding.Default.GetString(buffer, 0, effective);
                //Todo
                
                ListBox ListBoxLog = new ListBox();
                ListBoxLog.Items.Add(i);
                MessageBox.Show(str);

                i++;
            }
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns>时间戳，格式：yyyyMMddHHmm</returns>
        private static string TimeStamp()
        {
            string y = DateTime.Now.Year.ToString();
            string M = DateTime.Now.Month.ToString();
            string d = DateTime.Now.Day.ToString();
            string H = DateTime.Now.Hour.ToString();
            string m = DateTime.Now.Minute.ToString();

            switch (M){
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    M = "0" + M;
                    break;
                default:
                    break;
            }

            switch (d)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    d = "0" + d;
                    break;
                default:
                    break;
            }

            switch (H)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    H = "0" + H;
                    break;
                default:
                    break;
            }

            switch (m)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    m = "0" + m;
                    break;
                default:
                    break;
            }

            return y + M + d + H + m;
        }
    }
}
