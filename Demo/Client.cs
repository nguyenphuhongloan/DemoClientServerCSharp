using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Client
    {
        static IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
        static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static NetworkStream ns;
        public static void Connect()
        {
            client.Connect(iep);
         
            ns = new NetworkStream(client);
        }

        public static String Handle(String input)
        {

            byte[] data;
            data = Encoding.ASCII.GetBytes(input);
            ns.Write(data, 0, data.Length);
            if (input.ToUpper().Equals("QUIT"))
            {
                Console.WriteLine("Ngắt kết nối tới server");
                Disconnect();
            }
            data = new byte[1024];
            int rec = ns.Read(data, 0, data.Length);
            string s = Encoding.ASCII.GetString(data, 0, rec);
            return s;
        }
        public static void Disconnect()
        {
            client.Close();
        }





    }
}
