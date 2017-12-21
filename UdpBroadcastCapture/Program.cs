using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UdpBroadcastCapture.ServiceReference1;

namespace UdpBroadcastCapture
{
    class Program
    {
        static void Main()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 9090);
            serverSocket.Start();
            while (true)
            {




                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated");
                Stream ns = connectionSocket.GetStream();
                int i = 0;
                var newFile = $"C:/Users/Universe/PhpstormProjects/SecuritySystemX/Images/AGP{i}.jpg";
                while (true)
                {
                    using (var fs = new FileStream(newFile, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        ns.CopyTo(fs);
                    }
                    i++;
                    Console.WriteLine("Wrote");
                }
            }
        }
    }
}