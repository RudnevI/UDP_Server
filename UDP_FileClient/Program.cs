using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_FileClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UdpClient client = new UdpClient();
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(@"192.168.110.213"), 5002);
                Console.WriteLine("Type in path to the picture: ");
                string imagePath = Console.ReadLine();


                FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

                byte[] fileBytes = new byte[fs.Length];
                fs.Read(fileBytes, 0, fileBytes.Length);
                client.DontFragment = false;
                client.Send(fileBytes, fileBytes.Length, endPoint);
                fs.Close();
                client.Close();
            }
            catch(SocketException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
