using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerRouter.Common
{
    class SocketWorker
    {
        private readonly Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Socket GetSocket()
        {
            return socket;
        }

        public void Init(int Port)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, Port));
            Logger.Info($"Listener bind at localhost:{Port}.");
        }

        public void Start(int Num)
        {
            socket.Listen(Num);
            Logger.Info($"Listener is listening now, max connection is {Num}");
        }

        public void Stop()
        {
            socket.Close();
            Logger.Info("Listener stopped.");
        }
    }
}
