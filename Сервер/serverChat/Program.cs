﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace serverChat
{
    class Program
    {
        private const string _serverHost = "127.0.0.1";
        private const int _serverPort = 904;
        private static Thread _serverThread;

        static void Main(string[] args)
        {
            Console.Title = "Сервер чата";                                      //Переименовали окно
            _serverThread = new Thread(startServer);
            _serverThread.IsBackground = true;
            _serverThread.Start();
            while (true)
                handlerCommands(Console.ReadLine());
        }

        private static void handlerCommands(string cmd)
        {
            cmd = cmd.ToLower();
            if (cmd.Contains("/getusers"))
            {
                int countUsers = Server.Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    Console.WriteLine("[{0}]: {1}",i,Server.Clients[i].UserName);
                }
            }
        }

        private static void startServer()
        {
            //IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
            //IPAddress ipAddress = ipHost.AddressList[0];
            //IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
            //Socket socket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //socket.Bind(ipEndPoint);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, _serverPort));
            socket.Listen(10);

            Console.WriteLine("Server has been started on IP: {0} - port: {1}.", _serverHost, _serverPort);
            Console.WriteLine("Доступная команда: /getusers");
            while(true)
            {
                try
                {
                    Socket user = socket.Accept();
                    Server.NewClient(user);
                }
                catch (Exception exp) { Console.WriteLine("Error: {0}",exp.Message); }
            }
        }
    }
}
