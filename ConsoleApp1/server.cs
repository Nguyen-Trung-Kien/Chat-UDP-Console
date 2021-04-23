using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
    class server
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] buff = new byte[1024];
            byte[] byteRecieve = new byte[1024];

            string str, s;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.Bind(serverEndPoint);


            Console.WriteLine("Dang cho Client ket noi den...");


            //tao 1 endpoint gui nhan du lieu
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Romote = (EndPoint)(sender);

            //nhan va gui du lieu
            recv = serverSocket.ReceiveFrom(buff, ref Romote);

            Console.WriteLine("client:" + Encoding.ASCII.GetString(buff,0,recv));

            buff = new byte[1024];
            buff = Encoding.ASCII.GetBytes("------------Hello Client-------------");
            serverSocket.SendTo(buff, Romote);
            try 
            {
                while(true)
                {
                    buff = new byte[1024];
                    recv = serverSocket.ReceiveFrom(buff, ref Romote);
                    s = Encoding.ASCII.GetString(buff, 0, recv);
                    if (s.ToLower().Equals("exit")) break;
                    Console.WriteLine("client:" +s );
                    buff = new byte[1024];
                    Console.WriteLine("Nhap thong diep chi client:");
                    str = Console.ReadLine();
                    buff = Encoding.ASCII.GetBytes(str);
                    serverSocket.SendTo(buff, Romote);
                }
                
            }
            catch
            {
                Console.WriteLine("ket noi ket thuc");
                return;
            }

            
            //while(true)
            //{
            //    Console.WriteLine("Nhap thong diep gui cho client: \n");
            //    string str = Console.ReadLine();
            //    buff = Encoding.ASCII.GetBytes(str);
            //    serverSocket.SendTo(buff,serverEndPoint);


            //    //Console.WriteLine("Dang doi thong diep cua client");

            //    //int byteRecieve1 = serverSocket.ReceiveFrom(buff, ref Remote);
            //    //Console.WriteLine(Encoding.ASCII.GetString(buff,0,byteRecieve1));

            //}

            Console.ReadLine();
        }
    }
}
