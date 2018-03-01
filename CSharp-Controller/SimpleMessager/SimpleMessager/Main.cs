using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using static SimpleMessager.Messager;

namespace SimpleMessager
{
    public partial class Main : Form
    {
        public string timeStamp = "201803011632";
        public string password = "SimpleMessanger";

        public static bool recivable = true;

        public Main()
        {
            InitializeComponent();
            
            //Todo
            timeStamp = SocketWorker.Connect("server.r-ay.cn", 33663);
            
            string ptr = MessageMaker(MsgType.Handshake, SendName.Console, password, timeStamp);
            SocketWorker.Post(ptr);
            //MessageBox.Show(timeStamp);
            //MessageBox.Show(ptr);

            Console.ReadLine();


        }

        //XXX
        /*public static void ListBoxLogModifier()
        {
            Main.ListBoxLog log = new ListBoxLog();
            object o = 0;
            ListBoxLog.Items.Add(o);
        }*/
    }
}
