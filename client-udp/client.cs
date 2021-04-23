using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client_udp
{
    class client
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] buff = new byte[1024];
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),8888);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //tao 1 endpoint gui nhan du lieu
            EndPoint remote = (EndPoint)serverEndpoint;


            string helo = "Hello server!";
            buff = Encoding.ASCII.GetBytes(helo);
            server.SendTo(buff,remote);

            buff = new byte[1024];
            recv = server.ReceiveFrom(buff,ref remote);
            string s = Encoding.ASCII.GetString(buff, 0, recv);
            Console.WriteLine("Server:" + s); 
            try
            {
                
                while (true)
                {
                    buff = new byte[1024];
                    Console.WriteLine("Nhap thong diep cho server:");
                    s = Console.ReadLine();
                    buff = Encoding.ASCII.GetBytes(s);
                    server.SendTo(buff, remote);
                    if (s.ToUpper().Equals("exit")) break;

                    buff = new byte[1024];
                    recv = server.ReceiveFrom(buff, ref remote);
                    s = Encoding.ASCII.GetString(buff, 0, recv);
                    Console.WriteLine("server:" + s);
                    
                }
                server.Close();
            }
            catch
            {
                Console.WriteLine("Khong the ket noi");
            }
            

            //EndPoint receiveEp = new IPEndPoint(IPAddress.Any, 0);

            //EndPoint Remote = (EndPoint)(receiveEp);
            //Console.WriteLine("THong diep nhan ddc:");
            //int recv = server.ReceiveFrom(buff, ref Remote);
            //Console.WriteLine(Encoding.ASCII.GetString(buff,0,recv));



            //while (true)
            //{
            //    Console.WriteLine("Dang doi thong diep cua server...");
       
            //    int recv = server.ReceiveFrom(buff, ref Remote);
            //    Console.WriteLine(Encoding.ASCII.GetString(buff,0,recv));
            //    recv = serverSocket.ReceiveFrom(buff, ref Remote);

            //    Console.WriteLine(Encoding.ASCII.GetString(buff, 0, recv));

            //    //Console.WriteLine("\nNhap thong diep cho server: ");
            //    //string str = Console.ReadLine();
            //    //buff = Encoding.ASCII.GetBytes(str);
            //    //server.SendTo(buff, serverEndpoint);




            //}

            Console.ReadLine();
            
        }
    }
}
