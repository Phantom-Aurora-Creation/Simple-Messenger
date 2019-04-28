using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMessengerForVanilla
{
    class CLIWorker
    {
        public static void OutputUsage()
        {
            Console.WriteLine($"Simple Messenger for Vanilla: \n" +
                    $"  Version: {Program.Version} \n" +
                    $"  Usage: dotnet SimpleMessengerForVanilla.dll [<options> ...] [<java args> ...] [<minecraft server args> ...]\n" +
                    $"    Options: \n" +
                    $"      --server=<server ip>: Simple messenger router server IP. (Important). \n" +
                    $"      --port=<server port>: Simple messenger router server port. (Default: 33663). \n" +
                    $"      --javaw: Start with command `javaw`. (Otherwise will start with command `java`). \n" +
                    $"    Example: \n" +
                    $"      dotnet SimpleMessengerForVanilla.dll --server=123.45.67.89 -jar server.jar nogui");
        }

        public static Dictionary<string, string> ParseParaneters(string[] args)
        {
            var arguments = new Dictionary<string, string>()
            {
                {"ServerIP", ""},
                {"ServerPort", ""}, 
                {"IsJavaw", "false"}, 
                {"StartArgs", ""}, 
            };

            foreach (var argu in args)
            {
                if (argu.StartsWith("--"))
                {
                    if (argu.StartsWith("--server"))
                    {
                        var array = argu.Split('=');
                        if (array.Length == 2)
                        {
                            arguments["ServerIP"] = array[1];
                        }
                    }
                    else if (argu.StartsWith("--port"))
                    {
                        var array = argu.Split('=');
                        if (array.Length == 2)
                        {
                            arguments["ServerPort"] = array[1];
                        }
                    }
                    else if (argu == "--javaw")
                    {
                        arguments["IsJavaw"] = "true";
                    }
                }
                else
                {
                    arguments["StartArgs"] += $" {argu}";
                }
            }
            return arguments;
        }
    }
}
