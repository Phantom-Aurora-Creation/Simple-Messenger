using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static SimpleMessager.Messager;

namespace SimpleMessager
{
    public partial class Main : Form
    {
        public string timeStamp = "201803011632";
        public string password = "SimpleMessager";

        public Main()
        {
            InitializeComponent();
            
            //Todo
            timeStamp = SocketWorker.Connect("server.r-ay.cn", 33663);
            string ptr = Messager.MessageMaker(MsgType.Handshake, SendName.Console, password, timeStamp);
            SocketWorker.Post(ptr);
            //MessageBox.Show(st);
            //MessageBox.Show(ptr);

            Console.ReadLine();
        }
    }
}
