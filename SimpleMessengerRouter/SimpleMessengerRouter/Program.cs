using SimpleMessengerRouter.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerRouter
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketWorker Socket = new SocketWorker();
            Socket.Init(37201);
            Socket.Listen(233);



            Logger.Info("Welcome!");
        }
    }
}
