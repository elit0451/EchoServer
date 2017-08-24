using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class EchoServerFacade
    {
        TcpClient serverSocket;
        NetworkStream netStream;
        StreamReader reader;
        StreamWriter writer;
        int serverPort = 0;
        string serverName = "";

        public EchoServerFacade(string ipAddress, int port)
        {
            serverName = ipAddress;
            serverPort = port;
            Open();
        }

        private void Open()
        {
            serverSocket = new TcpClient(serverName, serverPort);
            netStream = serverSocket.GetStream();
            reader = new StreamReader(netStream);
            writer = new StreamWriter(netStream);
            writer.AutoFlush = true;
        }

        private void Close()
        {
            reader.Close();
            writer.Close();
            netStream.Close();
            serverSocket.Close();
        }

        public void Dispose()
        {
            reader.Dispose();
            writer.Dispose();
            netStream.Dispose();
            serverSocket.Dispose();
        }

        public void Echo(string message)
        {
            SendToServer(message);
            Console.WriteLine(ReceiveFromServer());

        }

        public void EchoUpper()
        {

        }


        private string ReceiveFromServer()
        {
            return reader.ReadLine();
        }

        private void SendToServer(string message)
        {
            writer.WriteLine(message);
        }



    }
}
