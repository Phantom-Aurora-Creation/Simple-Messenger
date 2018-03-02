using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using static SimpleMessager.Messager;

namespace SimpleMessager
{
    public partial class Main : Form
    {
        /// <summary>
        /// 操作成功的返回值
        /// </summary>
        public static string success = "successful";

        public string timeStamp = "201803011632";
        //fixme
        public string password = "SimpleMessager";

        public static string def = "";

        public static string ServerHost = "server.r-ay.cn";
        public static IPAddress ServerIP = IPAddress.Parse("114.31.124.36");
        public static int ServerPort = 50000;

        public static bool recivable = true;

        public Main()
        {
            InitializeComponent();
            
            //Todo
            timeStamp = SocketWorker.Connect(ServerHost, ServerPort);

            string ptr = MessageMaker(MsgType.Handshake, SendName.Plugin, password, timeStamp);
            SocketWorker.Post(ptr);
            //MessageBox.Show(timeStamp);
            //MessageBox.Show(ptr);
            //Console.ReadLine();

            SocketWorker.Recive();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            string str = MessageMaker(MsgType.Minecraft, "name", TestBoxInput.Text);
            string status = SocketWorker.Post(str);
            if(status == success)
            {
                //MessageBox.Show("Successful!");
            }
            else
            {
                MessageBox.Show(status);
            }

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult status = MessageBox.Show("真的要退出吗？", "森破信使 SimpleMessager", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (status == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                SocketWorker.Exit();
            }
        }

        //XXX
        /*public static void ListBoxLogModifier()
        {
            ListBox log = new ListBoxLog();
            object o = 0;
            ListBoxLog.Items.Add(o);
        }*/
    }
}
