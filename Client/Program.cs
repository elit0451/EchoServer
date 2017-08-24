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
            EchoServerFacade esf = new EchoServerFacade("localhost", 11000);

            while (true)
            {
                esf.Echo(Console.ReadLine());
            }

            Console.ReadKey();
        }
    }
}
