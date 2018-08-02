using System;
using System.Threading.Tasks;

namespace UnityDemoServer
{
    class Program
    {
        static void Main(string[] args)
        {
			var endport = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 26000);
<<<<<<< HEAD
            Console.WriteLine(System.Net.IPAddress.Any);
			System.Net.Sockets.Socket port = new System.Net.Sockets.Socket(endport.AddressFamily, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
=======
			var port = new System.Net.Sockets.Socket(endport.AddressFamily, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
>>>>>>> d949a35f1379c3d129ba1b87925aee157c9c5dd3
			port.Bind(endport);
			port.Listen(2);
			while (true)
			{
				var clientconn = port.Accept();
				
			}
        }
    }
}
