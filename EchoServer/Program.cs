using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
            Console.ReadKey();
        }

        private void Run()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 11000);
            listener.Start();

            Console.WriteLine("Ready");

            while (true)
            {
                ClientHandler clientHandl = new ClientHandler(listener.AcceptSocket());
                Console.WriteLine("A client connected.");
                Thread clientThread = new Thread(clientHandl.RunClient);
                clientThread.Start();
            }
            

        }
    }
}
