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
        public StreamReader reader;
        public StreamWriter writer;
        public EchoService es;

        public ClientHandler(Socket clientS, EchoService eService)
        {
            clientSocket = clientS;
            netStream = new NetworkStream(clientSocket);
            reader = new StreamReader(netStream);
            writer = new StreamWriter(netStream);
            writer.AutoFlush = true;

            es = eService;
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
            switch (command)
            {
                case "echo":
                    DoDialog(es.Echo(messageClient.Substring(5)));
                    break;
                case "echoU":
                    DoDialog(es.EchoUpper(messageClient.Substring(6)));
                    break;
                case "last":
                    DoDialog(es.ReturnLastMessage());
                    break;
                default:
                    DoDialog("Invalid command");
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
                catch (Exception e)
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
