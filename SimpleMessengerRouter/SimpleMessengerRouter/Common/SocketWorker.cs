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
        }

        public void Listen(int Num)
        {
            socket.Listen(Num);
        }

    }
}
