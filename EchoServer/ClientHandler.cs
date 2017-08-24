﻿using System;
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

        public void Run(object connection)
        {
            Socket conn = (Socket)connection;
            Console.WriteLine("A client connected.");

            bool clientConnected = true;

            while (clientConnected)
            {
                try
                {
                    NetworkStream stream = new NetworkStream(conn);
                    StreamReader reader = new StreamReader(stream);
                    StreamWriter writer = new StreamWriter(stream);

                    writer.AutoFlush = true;

                    string messageClient = "";

                    messageClient = reader.ReadLine();
                    Console.WriteLine(messageClient);
                    writer.WriteLine(messageClient);

                }
                catch(Exception e)
                {
                    clientConnected = false;
                }


            }

        }

    }
}
