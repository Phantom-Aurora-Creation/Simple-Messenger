using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace SimpleMessengerForVanilla
{
    class Program
    {
        public static readonly string Version = "1.0.0";

        private static Process Server = null;

        private static string ServerIP = "";
        private static int ServerPort = 33663;
        private static string StartName = "java";
        private static string StartArgs = "";

        private static Thread ServerProtectThread = null;
        private static bool IsRunning = false;

        private static SimpleMessengerWorker SimpleMessenger = null;

        private static Regex RegexUsername = new Regex("<(.*)>");
        private static Regex RegexMessage = new Regex("> (.*)");

        static void Main(string[] args)
        {
            // Parse arguments.
            if (args.Length == 0)
            {
                CLIWorker.OutputUsage();
                Environment.Exit(1);
            }

            Dictionary<string, string> arguments = CLIWorker.ParseParaneters(args);

            if (string.IsNullOrEmpty(arguments["ServerIP"]))
            {
                CLIWorker.OutputUsage();
                Environment.Exit(1);
            }
            else
            {
                ServerIP = arguments["ServerIP"];
            }

            if (!int.TryParse(arguments["ServerPort"], out ServerPort))
            {
                ServerPort = 33663;
            }

            if (arguments["IsJavaw"] == "true")
            {
                StartName = "javaw";
            }
            else
            {
                StartName = "java";
            }

            StartArgs = arguments["StartArgs"];

            Console.WriteLine($"[SimpleMessengerForVanilla] Starting...");
            Console.WriteLine($"[SimpleMessengerForVanilla] Version: {Version}.");

            SimpleMessenger = new SimpleMessengerWorker(ServerIP, ServerPort);

            StartServer();
            IsRunning = true;

            ServerProtectThread = new Thread(ServerProtect);
            ServerProtectThread.Start();

            while (true)
            {
                var input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    if (input == "stop" || input == "/stop")
                    {
                        IsRunning = false;
                        SimpleMessenger.Stop();
                    }

                    Server.StandardInput.WriteLine(input);
                }
            }
        }

        private static void StartServer()
        {
            Server = new Process();
            Server.StartInfo.FileName = StartName;
            Server.StartInfo.Arguments = StartArgs;
            Server.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Server.StartInfo.UseShellExecute = false;
            Server.StartInfo.RedirectStandardOutput = true;
            Server.StartInfo.RedirectStandardInput = true;
            Server.OutputDataReceived += RevceivedDataServerOutput;
            Server.Start();
            Server.BeginOutputReadLine();
            Server.StandardInput.AutoFlush = true;
        }

        internal static void Show(string name, string msg)
        {
            Server.StandardInput.WriteLine($"/say <{name}> {msg}");
        }

        private static void ServerProtect()
        {
            while (IsRunning)
            {
                if (Server.HasExited)
                {
                    Console.WriteLine($"\n" +
                        $"[SimpleMessengerForVanilla] Server has exited.\n" +
                        $"[SimpleMessengerForVanilla] Restarting...\n");
                    StartServer();
                }
                Thread.Sleep(10000);
            }
        }

        private static void RevceivedDataServerOutput(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                Console.WriteLine(e.Data);

                string name = RegexUsername.Match(e.Data).Value.Replace("<", "").Replace(">", "");
                string msg = RegexMessage.Match(e.Data).Value.Replace("> ", "");
                SimpleMessenger.Send(null, name, msg);
            }
        }
    }
}
