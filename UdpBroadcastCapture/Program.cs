using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UdpBroadcastCapture.ServiceReference1;

namespace UdpBroadcastCapture
{
    class Program
    {
        // https://msdn.microsoft.com/en-us/library/tst0kwb1(v=vs.110).aspx
        // IMPORTANT Windows firewall must be open on UDP port 7000
        // Use the network EGV5-DMU2 to capture from the local IoT devices
        private const int Port = 7000;

        //private static readonly IPAddress IpAddress = IPAddress.Parse("192.168.5.137"); 
        private static readonly IPAddress IpAddress = IPAddress.Any;

        // Listen for activity on all network interfaces
        // https://msdn.microsoft.com/en-us/library/system.net.ipaddress.ipv6any.aspx
        static void Main()
        {
            using (UdpClient socket = new UdpClient(new IPEndPoint(IPAddress.Any, Port)))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                    string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    Console.WriteLine(message);
                    if (message.Contains("Sound"))
                    {
                        var split = message.Split('!');

                        // Parse(message, out string light, out string temperature, out string potentiometer);
                        //Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                        //remoteEndPoint.Address, remoteEndPoint.Port, message);
                        using (ServiceReference1.Service1Client client =
                            new Service1Client())
                        {
                            var res = client.InsertNoise(split[0], split[1]);
                            //var result = client.InsertIntoDatabase(int.Parse(light), int.Parse(temperature),
                            //    int.Parse(potentiometer), 0);
                            if (res == 1)
                            {
                                Console.WriteLine("succesfull");
                            }
                            else
                            {
                                Console.WriteLine("Unsucessfull");
                            }

                            //}
                            //Console.WriteLine(datagramReceived);
                            //Parse(message);
                        }
                    }
                }
            }
            //private static void Parse(string response, out string light, out string temperature, out string potentiometer)
            //{
            //    light = null;
            //    temperature = null;
            //    potentiometer = null;

            //    string[] parts = response.Split(',');
            //    foreach (string part in parts)
            //    {
            //        var keyAndValue = part.Split(':');
            //        if (keyAndValue[0].Contains("Light"))
            //        {
            //            light = keyAndValue[1].Replace("\"", "").Replace("{", "").Replace("}", "").Trim();
            //        }
            //        if (keyAndValue[0].Contains("Potentiometer"))
            //        {
            //            potentiometer = keyAndValue[1].Replace("\"", "").Replace("{", "").Replace("}", "").Trim();
            //        }
            //        if (keyAndValue[0].Contains("Temperature"))
            //        {
            //            temperature = keyAndValue[1].Replace("\"", "").Replace("{", "").Replace("}", "").Trim();
            //        }
            //    }
            //}
            // To parse data from the IoT devices in the teachers room, Elisagårdsvej

        }
    }
}
