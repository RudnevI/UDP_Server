using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(5001);

            IPEndPoint remoteEndPoint = null;

            try
            {
                Console.WriteLine("-- CHAT --");

                while (true)
                {
                    byte[] receiveBytes = server.Receive(ref remoteEndPoint);

                    string receiveMessage = Encoding.UTF8.GetString(receiveBytes);
                    string str = $"--> ({remoteEndPoint.Address})";

                    Console.WriteLine($"-->{receiveMessage}");

                }
            }
            catch (SocketException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }
    }
}
