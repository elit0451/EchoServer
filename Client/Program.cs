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
            TcpClient server = new TcpClient("localhost", 11000);

            string serverMessage = "";

            NetworkStream stream = server.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            writer.AutoFlush = true;

            while (true)
            {
                writer.WriteLine(Console.ReadLine());
                serverMessage = reader.ReadLine();
                Console.WriteLine(serverMessage);
            }

            Console.ReadKey();
        }
    }
}
