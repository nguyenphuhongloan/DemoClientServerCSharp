using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Server
    {
        public static void Main(String[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            Socket server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(10);
            Console.WriteLine("Cho kết nối từ client");
            Socket client = server.Accept();
            Console.WriteLine("Chấp nhận kết nối từ client");
            Console.WriteLine("Chấp nhận kết nối từ {0}", client.RemoteEndPoint.ToString());
            Byte[] data;
            NetworkStream ns = new NetworkStream(client);
            while (true)
            {
                data = new byte[1024];
                int rec = ns.Read(data, 0, data.Length);
                string s = Encoding.ASCII.GetString(data, 0, data.Length);
                Console.WriteLine("Server nhận được", s);
                s = s.ToUpper();
                if (s.Equals("QUIT"))
                {
                    Console.WriteLine("Ngắt kết nối");
                    break;
                }
                data = Encoding.ASCII.GetBytes(s);
                ns.Write(data, 0, data.Length);
            }
            client.Close();
            server.Close();
        }

    }
}
