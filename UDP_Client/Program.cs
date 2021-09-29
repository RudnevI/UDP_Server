using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                UdpClient client = new UdpClient();

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(@"192.168.110.13"), 5001);

                try
                {
                    Console.Write("-->");
                    byte[] bytes = Encoding.UTF8.GetBytes(Console.ReadLine());
                    client.Send(bytes, bytes.Length, endPoint);
                }
                catch(SocketException exception)
                {
                    Console.WriteLine($"Error: {exception.Message}");
                }
                finally
                {
                    client.Close();
                }
            }
        }
    }
}
