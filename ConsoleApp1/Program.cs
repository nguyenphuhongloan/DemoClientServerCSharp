using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
    internal static class Program
    {
        static void Main()
        {
           

            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(iep);
            Console.WriteLine("Kết nối tới server");
            NetworkStream ns = new NetworkStream(client);
            byte[] data;
            while (true)
            {
                string input = Console.ReadLine();
                data = Encoding.ASCII.GetBytes(input);
                ns.Write(data, 0, data.Length);
                if (input.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Ngắt kết nối tới server");
                    break;
                }
                data = new byte[1024];
                int rec = ns.Read(data, 0, data.Length);
                string s = Encoding.ASCII.GetString(data, 0, rec);
                Console.WriteLine(s);
            }
            client.Close();

        }
    }
}