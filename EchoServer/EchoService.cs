using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    static class EchoService
    {
        public static string Echo(string message)
        {
            return message;
        }

        public static string EchoUpper(string message)
        {
            return message.ToUpper();
        }
    }
}
