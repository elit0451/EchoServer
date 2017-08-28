using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            EchoServerFacade esf = new EchoServerFacade("localhost", 11000);

            while (true)
            {
                string messageClient = Console.ReadLine();

                string messageCommand = messageClient.Split(' ')[0];
                switch (messageCommand)
                {
                    case "echo": esf.Echo(messageClient);
                        break;
                    case "echoU": esf.EchoUpper(messageClient);
                        break;
                    case "last": esf.Echo(messageClient);
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

            }

            Console.ReadKey();
        }
    }
}
