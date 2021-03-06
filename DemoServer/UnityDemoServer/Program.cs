﻿using System;
using System.Threading.Tasks;

namespace UnityDemoServer
{
    class Program
    {
        static void Main(string[] args)
        {
			var endport = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 26000);
			var port = new System.Net.Sockets.Socket(endport.AddressFamily, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
			port.Bind(endport);
			port.Listen(2);
			while (true)
			{
				var clientconn = port.Accept();
				new ClientStatusVariable(new sunny.Sockets.Socket(clientconn));
			}
        }
    }
}
