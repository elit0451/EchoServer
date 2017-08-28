using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class Session
    {
        public ClientHandler ConnectedClientHandler { get; set; }
        public EchoService SessionEchoService { get; set; }
        public int SessionID { get; private set; }

        public Session(ClientHandler ch, EchoService es, int id)
        {
            ConnectedClientHandler = ch;
            SessionEchoService = es;
            SessionID = id;
        }

    }
}
