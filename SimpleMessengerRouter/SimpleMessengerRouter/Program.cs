using SimpleMessengerRouter.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerRouter
{
    class Program
    {
        public static int Port = 37201;
        public static int MaxConnection = 233;

        public static Dictionary<MyEnum.ClientType, Socket> Clients = new Dictionary<MyEnum.ClientType, Socket>();

        public static bool IsRunning = false;

        static void Main(string[] args)
        {
            SocketWorker Socket = new SocketWorker();

            Socket.Init(Port);
            Socket.Start(MaxConnection);

            IsRunning = true;

            Logger.Info("Welcome!");

            while (true)
            {
                string input = Console.ReadLine();
                Logger.WriteToFile(input);
                switch (input)
                {
                    case "stop":
                        Socket.Stop();
                        Console.Read();
                        Environment.Exit(0);
                        break;
                    default:
                        Logger.Error("No such command.");
                        continue;
                }
            }
        }
    }
}
