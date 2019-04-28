using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SimpleMessengerForVanilla
{
    class SimpleMessengerWorker
    {
        private bool IsConnected = false;

        private readonly Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private readonly Thread ReceiveThread = null;

        internal SimpleMessengerWorker(string ip, int port)
        {
            Console.WriteLine($"[SimpleMessengerForVanilla] Connecting simple messenger server at {ip}:{port}.");

            try
            {
                Socket.Connect(ip, port);
            }
            catch (Exception)
            {
                Console.WriteLine("[SimpleMessengerForVanilla] Connection not established.");
                Environment.Exit(2);
            }

            IsConnected = true;

            ReceiveThread = new Thread(InternalReceive);
            ReceiveThread.IsBackground = true;
            ReceiveThread.Start(Socket);
        }

        internal void Stop()
        {
            ReceiveThread.Abort();
        }

        private void InternalReceive(object obj)
        {
            var socket = obj as Socket;
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024 * 10];
                int realReceive = socket.Receive(buffer);
                if (realReceive == 0)
                {
                    continue;
                }
                else
                {
                    string str = Encoding.Default.GetString(buffer, 0, realReceive);
                    Receive(str);
                }
            }
        }

        private void InternalSend(byte[] bytes)
        {
            try
            {
                if (IsConnected)
                {
                    Socket.Send(bytes);
                }
            }
            catch (Exception)
            {

            }
        }

        internal void Send(string uid, string name, string text, MsgType type = MsgType.msg)
        {
            var message = new Message();
            message.Ver = 9;
            message.Type = type;
            message.Time = DateTime.Now.ToString("yyyyMMddHHmmss");
            message.ID = 1;
            message.Parts = 1;
            message.AllParts = 1;
            message.From = MsgFrom.Console;
            message.Uid = uid;
            message.Name = name;
            message.Msg = text;

            InternalSend(Encoding.Default.GetBytes(JsonConvert.SerializeObject(message)));
        }

        private void Receive(string str)
        {
            var message = JsonConvert.DeserializeObject<Message>(str);
            if (message.Type == MsgType.msg)
            {
                Program.Show(message.Name, message.Msg);
            }
        }

        struct Message
        {
            internal int Ver;
            internal MsgType Type;
            internal string Time;
            internal int ID;
            internal int Parts;
            internal int AllParts;
            internal MsgFrom From;
            internal string Uid;
            internal string Name;
            internal string Msg;
        }

        internal enum MsgType
        {
            msg,
            img,
            handshake,
            control,
            error
        }

        internal enum MsgFrom
        {
            QQ,
            Bukkit,
            Sponge,
            Client,
            Bungee,
            Console,
            Other
        }
    }
}
