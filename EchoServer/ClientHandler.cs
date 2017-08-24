using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class ClientHandler
    {
        private Socket clientSocket;
        private NetworkStream netStream;
        private StreamReader reader;
        private StreamWriter writer;

        public ClientHandler(Socket clientS)
        {
            clientSocket = clientS;
            netStream = new NetworkStream(clientSocket);
            reader = new StreamReader(netStream);
            writer = new StreamWriter(netStream);
            writer.AutoFlush = true;
        }

        private void DoDialog(string messageClient)
        {
            Console.WriteLine(messageClient);
            SendToClient(messageClient);
        }

        private void ExecuteCommand()
        {
            string messageClient = "";

            messageClient = ReceiveFromClient();
            string command = messageClient.Split(' ')[0];
            Console.WriteLine(command);
            switch(command)
            {
                case "echo": DoDialog(EchoService.Echo(messageClient.Substring(5)));
                    break;
                case "echoU": DoDialog(EchoService.EchoUpper(messageClient.Substring(6)));
                    break;
                default: DoDialog("Invalid command");
                    break;
            }
            
        }

        private string ReceiveFromClient()
        {
            return reader.ReadLine();
        }

        public void RunClient()
        {
            bool clientConnected = true;

            while (clientConnected)
            {
                try
                {
                    ExecuteCommand();
                }
                catch(Exception e)
                {
                    clientConnected = false;
                }
            }

        }

        private void SendToClient(string messageClient)
        {
            writer.WriteLine(messageClient);
        }

    }
}
