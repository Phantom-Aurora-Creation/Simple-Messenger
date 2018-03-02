using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessager
{
    class SocketWorker
    {
        public static string suc = "successful";

        private static Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private static Thread thread = new Thread(ReciveWorker);

        private static void Init() { }

        public static string Connect(IPAddress ip, int port)
        {
            socket.Connect(ip, port);
            return TimeStamp();
        }

        public static string Connect(string host, int port)
        {
            socket.Connect(host, port);
            return TimeStamp();
        }

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

            return suc;
        }

        public static void Recive()
        {
            thread.IsBackground = true;
            thread.Start(socket);
        }

        public static void Exit()
        {
            //MessageBox.Show("");
            thread.Abort();
            socket.Close();
        }

        private static void ReciveWorker(object o)
        {
            Socket send = o as Socket;
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
                //Main.ListBoxLog.Items.Add();
                //ListBox log = new Main.ListBoxLog();
                MessageBox.Show(str);

            }
        }

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
