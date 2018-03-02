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
            
            string ptr = MessageMaker(MsgType.Handshake, SendName.Plugin, password, timeStamp);
            SocketWorker.Post(ptr);
            //MessageBox.Show(timeStamp);
            //MessageBox.Show(ptr);

            Console.ReadLine();


        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            string str = MessageMaker(MsgType.Minecraft, "name", TestBoxInput.Text);
            string status = SocketWorker.Post(str);
            if(status == "successful")
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
