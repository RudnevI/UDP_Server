using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetstatInfo
{
    class Program
    {




        static void Main(string[] args)
        {

            Ping ping = new Ping();
            PingOptions options = new PingOptions(64, true);
            string address = "192.168.110.110";

            /*ping.PingCompleted += Ping_PoingCompleted();*/

            byte[] buffer = Encoding.ASCII.GetBytes("ooooooooooooooooooooooo");
            ping.PingCompleted += new PingCompletedEventHandler(Ping_PingCompleted);
           
            while (true)
            {
                /*ping.SendAsync(address, 12000, buffer, options, null);*/
                ping.Send(address);
            }

            Console.ReadLine();

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            IPEndPoint[] endPoints = properties.GetActiveUdpListeners();

            foreach (IPEndPoint point in endPoints)
            {
                Console.Write($"address: {point.Address} / ");
                Console.WriteLine($"port: {point.Port}");

            }
        }

        private static void Ping_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            Console.WriteLine($"Adress: {e.Reply.Address}");
            Console.WriteLine($"Status: {e.Reply.Status}");
        }
    }
}
