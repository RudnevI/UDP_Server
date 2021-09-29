using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_FileServer
{
    class Program
    {

        public class FileInfo
        {
            public string FileType { get; set; }
            public long FileSize { get; set; }
        }

        public static UdpClient Server = new UdpClient(5002);

        public static IPEndPoint EndPoint = null;

        public static byte[] receiveBytes = new byte[0];

        static void Main(string[] args)
        {
            Console.WriteLine("-- Awaiting files --");
            receiveBytes = Server.Receive(ref EndPoint);

            FileStream fs = new FileStream("file.jpg", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

            fs.Write(receiveBytes, 0, receiveBytes.Length);
            fs.Close();
            Server.Close();
            Console.ReadLine();
        }
    }
}
