using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMessengerRouter.Common
{
    class SocketWorker
    {
        private readonly Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private Thread AcceptThread;
        private Thread ThreadReceive;

        public void Init(int Port)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, Port));
            Logger.Info($"Listener bind at localhost:{Port}.");
        }

        public void Start(int Num)
        {
            socket.Listen(Num);
            Logger.Info($"Listener is listening now, max connection is {Num}");

            AcceptThread = new Thread(new ParameterizedThreadStart(OnAccept));
            AcceptThread.IsBackground = true;
            AcceptThread.Start();
        }

        public void Stop()
        {
            socket.Close();
            Logger.Info("Listener stopped.");
        }

        private void OnAccept(object obj)
        {
            Socket ListenSocket = obj as Socket;

            while (true)
            {
                Socket ClientSocket = ListenSocket.Accept();

                string RemoteIP = ClientSocket.RemoteEndPoint.ToString();
                Program.Clients.Add(RemoteIP, ClientSocket);

                Logger.Info($"{RemoteIP} has connected.");

                ThreadReceive = new Thread(new ParameterizedThreadStart(Receive));
                ThreadReceive.IsBackground = true;
                ThreadReceive.Start();
            }
        }

        private void Receive(object obj)
        {
            Socket ClientSocket = obj as Socket;

            while (true)
            {
                byte[] buffer = new byte[1024 * 10];
                int count = ClientSocket.Receive(buffer);

                if (count == 0)
                {
                    break;
                }
                else
                {
                    string msg = Encoding.Default.GetString(buffer, 0, count);
                    Logger.Debug($"Received {msg} from {ClientSocket.RemoteEndPoint}.");
                }
            }
        }
    }
}
