using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ExcelFileRead
{
    class TcpChat
    {
        private const string _serverHost = "localhost";
        private const int _serverPort = 9933;
        private static Thread _serverThread;

        private static void handlerCommands(string cmd)
        {
            cmd = cmd.ToLower();
            if(cmd.Contains("/getusers"))
            {
                int countUsers = ChatServer.Clients.Count;
                for(int i=0;i<countUsers;i++)
                {
                    Console.WriteLine("[{0}]: {1}",ChatServer.Clients[i].UserName);
                }
            }
        }

        public static void startServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Listen(1000);
            Console.WriteLine("Сервер был запущен по IP: {0}",ipEndPoint);
            while(true)
            {
                try
                {
                    Socket user = socket.Accept();
                    ChatServer.NewClient(user);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Ошибка: {0}",ex.Message);
                }
            }
        }
    }
}
