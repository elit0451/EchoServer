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
    class Server
    {
        private int lastSessionId = 0;
        private Dictionary<int, Session> listOfSessions = new Dictionary<int, Session>();
        static void Main(string[] args)
        {
            Server myProgram = new Server();
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
                Session session = StartSession(listener.AcceptSocket());
                Console.WriteLine("A client connected.");
                Thread clientThread = new Thread(session.ConnectedClientHandler.RunClient);
                clientThread.Start();
            }

        }

        private void EndSession(int sessionId)
        {
            listOfSessions.Remove(sessionId);
        }

        private Session GetSession(int sessionId)
        {
            return listOfSessions[sessionId];
        }

        private Session StartSession(Socket client)
        {
            EchoService es = new EchoService();
            ClientHandler ch = new ClientHandler(client, es);
            Session session;

            int clientId = int.Parse(ch.reader.ReadLine());

            if (clientId != -1)
            {
                session = GetSession(clientId);
                ch.es = session.ConnectedClientHandler.es;
                session.ConnectedClientHandler = ch;
            }
            else
            {
                lastSessionId++;
                clientId = lastSessionId;
                session = new Session(ch, es, lastSessionId);

                listOfSessions.Add(lastSessionId, session);
            }

            session.ConnectedClientHandler.writer.WriteLine(clientId);
            
            return session;
        }
    }
}
