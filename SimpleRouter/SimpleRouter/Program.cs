using Newtonsoft.Json;
using RUL;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace SimpleRouter
{
    class Program
    {
        private static Dictionary<string, (ClientType type, Socket socket)> Clients = new Dictionary<string, (ClientType type, Socket socket)>();

        private static Logger log = new Logger("Main");
        private static readonly Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            log.Info("Starting...");

            socket.Bind(new IPEndPoint(IPAddress.Any, 33663));
            socket.Listen(233);

            Thread threadListen = new Thread(Listen);
            threadListen.IsBackground = true;
            threadListen.Start();

            log.Info("Welcome!");
            
            while (true)
            {

            }
        }

        private static void Listen()
        {
            Socket client = null;

            while (true)
            {
                try
                {
                    
                    client = socket.Accept();
                    log.Info($"Client {client.RemoteEndPoint} connected!");

                    Thread thread = new Thread(Receive);
                    thread.IsBackground = true;
                    thread.Start(client);
                }
                catch (Exception)
                {

                }
            }
        }

        private static void Receive(object client)
        {
            Socket socketClient = client as Socket;
            while (true)
            {
                try
                {
                    string msg = InternalReceive(socketClient);
                    if (msg != "")
                    {
                        Message message = JsonConvert.DeserializeObject<Message>(msg);

                        if (message.Type == MsgType.handshake)
                        {
                            Clients.Add(socketClient.RemoteEndPoint.ToString(), (message.From, socketClient));
                        }
                        else
                        {
                            if (Clients.ContainsKey(socketClient.RemoteEndPoint.ToString()))
                            {
                                Console.WriteLine(msg);
                                foreach (var Client in Clients)
                                {
                                    if (Client.Key != socketClient.RemoteEndPoint.ToString())
                                    {
                                        Client.Value.socket.Send(Encoding.Default.GetBytes(msg));
                                    }
                                }
                            }
                            else
                            {
                                log.Info($"{socketClient.RemoteEndPoint} authentication needed!");
                                socketClient.Send(Encoding.Default.GetBytes("Authentication needed!"));
                                socketClient.Close();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Clients.Remove(socketClient.RemoteEndPoint.ToString());
                    log.Info($"{socketClient.RemoteEndPoint} lost connection.");
                    break;
                }
            }
        }

        private static string InternalReceive(Socket socket)
        {
            byte[] buffer = new byte[1024 * 1024];
            string message = "";
            int length = 0;

            length = socket.Receive(buffer);
            message = Encoding.Default.GetString(buffer, 0, length);

            return message;
        }

        private static string MessageBuild(MsgType msgType, ClientType clientType, string uid, string name, string message)
        {
            Message msg = new Message();

            msg.Ver = 9;
            msg.Type = msgType;
            msg.Time = DateTime.Now.ToString("yyyyMMddHHmm");
            msg.ID = 1;
            msg.Parts = 1;
            msg.AllParts = 1;
            msg.From = clientType;
            msg.Uid = uid;
            msg.Name = name;
            msg.Msg = message;

            return JsonConvert.SerializeObject(msg);
        }

        /*
        public static string GetAccessCode(string Password)
        {
            return GetMD5(GetMD5(Password) + TimeStamp());
        }

        private static string GetMD5(string str)
            {
            string result = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
            {
                result = result + s[i].ToString("x2");
            }
            return result;
        }

        private static string TimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        */

        struct Message
        {
            public int Ver;
            public MsgType Type;
            public string Time;
            public int ID;
            public int Parts;
            public int AllParts;
            public ClientType From;
            public string Uid;
            public string Name;
            public string Msg;
        }

        enum ClientType
        {
            QQ,
            Bukkit,
            Sponge,
            Client,
            Bungee,
            Console,
            Other
        }

        enum MsgType
        {
            msg,
            img,
            handshake,
            control,
            error
        }
    }
}
