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
        // https://msdn.microsoft.com/en-us/library/tst0kwb1(v=vs.110).aspx
        // IMPORTANT Windows firewall must be open on UDP port 7000
        // Use the network EGV5-DMU2 to capture from the local IoT devices
        private const int Port = 9090;

        //private static readonly IPAddress IpAddress = IPAddress.Parse("192.168.5.137"); 
        private static readonly IPAddress IpAddress = IPAddress.Any;

        // Listen for activity on all network interfaces
        // https://msdn.microsoft.com/en-us/library/system.net.ipaddress.ipv6any.aspx
        static void Main()
        {
            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPAddress ip1 = IPAddress.Parse("192.168.3.243");
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 9090);
            serverSocket.Start();

            while (true)
            {


                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                //Socket connectionSocket = serverSocket.AcceptSocket();
                Console.WriteLine("Server activated");
                //EchoService echoService = new EchoService(connectionSocket);
                Stream ns = connectionSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true; // enable automatic flushing
                int i = 0;
                var newFile = $"C:/Users/Universe/PhpstormProjects/SecuritySystemX/Images/AGP{i}.jpg";
               // var motionData = sr.ReadLine();
              
                while (true)
                {
                    //List<string> data = new List<string>();
                    //while (true)
                    //{



                        //string datagramReceived = sr.ReadToEnd();
                        //if (datagramReceived.Length > 0)
                        //{
                            //var bytesToWrite = Encoding.ASCII.GetBytes(datagramReceived);
                            //byte[] base64string = Encoding.Default.GetBytes(datagramReceived);
                            
                            using (var fs = new FileStream(newFile, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                
                                ns.CopyTo(fs);
                                
                                //foreach (var string1 in data)
                                //{
                                //    base64string += string1;

                                //}
                                // var bytes = Encoding.ASCII.GetBytes(base64string);
                                //fs.Write(base64string, 0, base64string.Length);
                                
                            }
                    //using (var fs1 = new FileStream(newFile, FileMode.Open, FileAccess.Read))
                    //{
                    //    fs1
                    //}
                    
                    //data.Add(datagramReceived);
                    //}
                    i++;
                    Console.WriteLine("Wrote");
                    //else
                    //{
                    //    break;
                    //}
                    //}

                    //{

                    //    //string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    //    ////datagramReceived = null;
                    //    //pictureArray.Add(message);

                    //}
                    //break;




                }
            }
            //string message = sr.ReadLine();
                //string answer = "";
                //while (message != null && message != "")
                //{
                //    Console.WriteLine("Client: " + message);
                //    answer = message.ToUpper();
                //    sw.WriteLine(answer);
                //    message = sr.ReadLine();
                //}
                //ns.Close();
                //ConnectionSocket.Close();
                ////echoService.DoIt();
                ////Thread myThread = new Thread(echoService.DoIt);
                //TaskFactory factory = new TaskFactory();
                //factory.StartNew(echoService.DoIt);
                using (UdpClient socket = new UdpClient(new IPEndPoint(IPAddress.Any, Port)))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    var newFile = "AleksandarGoshoPicture8.jpg";
                    //List<string> pictureArray = new List<string>();
                    //string picture = "";
                    while (true)
                    {
                        List<byte[]> data = new List<byte[]>();
                        while (true)
                        {


                            
                            byte[] datagramReceived = socket.Receive(ref remoteEndPoint);
                            if (datagramReceived.Length > 0)
                            {
                                data.Add(datagramReceived);
                            }
                            else
                            {
                                break;
                            }
                        }

                        {
                            using (var fs = new FileStream(newFile,FileMode.OpenOrCreate,FileAccess.Write))
                            {
                                foreach (var bytese in data)
                                {
                                    fs.Write(bytese, 0, bytese.Length);
                                }
                                
                                Console.WriteLine("Wrote");
                            }
                            //string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                            ////datagramReceived = null;
                            //pictureArray.Add(message);
                            
                        }
                       
                            
                      
                       
                        
                    }

                    //foreach (var pic in pictureArray)
                    //{
                    //    picture += pic;
                    //}
                    //string filePath = "MyImage.jpg";
                    //File.WriteAllBytes(filePath, Convert.FromBase64String(picture));
                    Console.WriteLine("Donedonedonedone");
                    //Console.WriteLine(message);

                    //if (message.Contains("Motion"))
                    //{
                    //    InserMotion(message);
                    //    // Parse(message, out string light, out string temperature, out string potentiometer);
                    //    //Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                    //    //remoteEndPoint.Address, remoteEndPoint.Port, message);
                    //    //using (ServiceReference1.Service1Client client =
                    //    //    new Service1Client())
                    //    //{
                    //    //    var res = client.InsertNoise(split[0], split[1]);
                    //    //    //var result = client.InsertIntoDatabase(int.Parse(light), int.Parse(temperature),
                    //    //    //    int.Parse(potentiometer), 0);
                    //    //    if (res == 1)
                    //    //    {
                    //    //        Console.WriteLine("succesfull");
                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        Console.WriteLine("Unsucessfull");
                    //    //    }

                    //    //}
                    //    //Console.WriteLine(datagramReceived);
                    //    //Parse(message);

                    //}
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

        public static async Task<int> InserMotion(string message)
        {
            var split = message.Split('!');
            Console.WriteLine(split[2]);
            Motion motion = new Motion()
            {
                MotionLevel = split[0],
                DateTime = split[1]

            };
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58087");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var customer1 = JsonConvert.SerializeObject(motion);
                var content = new StringContent(customer1, Encoding.UTF8, "Application/json");
                var response = await client.PostAsync("Service1.svc/motions/", content);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                return 0;
            }

        }
    }
}