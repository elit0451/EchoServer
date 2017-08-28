using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
     class EchoService
    {
        private string lastMessage = "";
        public string Echo(string message)
        {
            lastMessage = message;
            return lastMessage;
        }

        public string EchoUpper(string message)
        {
            lastMessage = message.ToUpper();
            return lastMessage;
        }

        public string ReturnLastMessage()
        {
            return lastMessage;
        }
    }
}
