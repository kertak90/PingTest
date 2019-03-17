using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;



namespace ExcelFileRead
{
    public partial class FormTCPChat : Form
    {
        private delegate void printer(string data);                                     //Создание делегата вывода сообщений в чате
        private delegate void cleaner();                                                //Создание делегата очистки
        printer Printer;                                                                //Объявление делегата 
        cleaner Cleaner;                                                                //Объявление делегата
        private Socket _serverSocket;                                                   //Объявление Сокета сервера
        private Thread _clientThread;                                                   //Объявление потока клиента
        private static Thread _serverThread;                                            //Объявление потока сервера

        private const string _serverHost = "localhost";                                 //IP сервера
        private const int _serverPort = 9933;                                           //Порт сервера

        public FormTCPChat()
        {
            InitializeComponent();                                                      //Инициализация формы

            Printer = new printer(print);                                               //Объявление и инициализация делегата метода print
            Cleaner = new cleaner(clearChat);                                           //Объявление и инициализация делегата метода clearChat
            InitServer();                                                               //Метод который запускает сервер
            connect();                                                                  //Метод который устанавливает соединение с сервером 

            

            _clientThread = new Thread(listner);                                        //Запуск потока для прослушивания сети
            _clientThread.IsBackground = true;                                          //Поток фоновый
            _clientThread.Start();                                                      //Запуск потока         
            
        }

        private void InitServer()                                                       //Метод который запускает сервер
        {
            _serverThread = new Thread(startServer);                        //Инициализация потока для запуска сервера
            _serverThread.IsBackground = true;                              //Поток фоновый
            _serverThread.Start();                                          //Запуск сервреа
            while (true)                                                    //Цикл в который ожидает команду админимтратора на сервере
                handlerCommands(Console.ReadLine());            
        }

        public static void startServer()                                                //Фоновый поток работы сервера
        {
            IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            socket.Listen(1000);
            Console.WriteLine("Сервер был запущен по IP: {0}", ipEndPoint);

            while (true)
            {
                try
                {
                    Socket user = socket.Accept();
                    ChatServer.NewClient(user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                }
            }
        }

        private static void handlerCommands(string cmd)                                 //Метод, который читает команды администратора сервера
        {
            cmd = cmd.ToLower();
            if (cmd.Contains("/getusers"))                                              //Команда в консоли сервера "/getusers", выводит всех подключенных пользователей
            {
                int countUsers = ChatServer.Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    Console.WriteLine("[{0}]: {1}", i, ChatServer.Clients[i].UserName);
                }
            }
        }

        private void listner()                                                          //Фоновый поток, который получает данные из связанного сокета
        {
            while(_serverSocket.Connected)                                              //Пока соединение активное, работает бесконечный цикл
            {
                byte[] buffer = new byte[8196];                                         //Объявление массива для записи байтовой информации с сокета
                int bytesRec = _serverSocket.Receive(buffer);                           //Запись в буфер байтовой информации из сокета
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);             //Декодирование последовательности байтов буфера в строку
                if(data.Contains("#updatechat"))                                        //Если в полученной строке был данный текст "#updatechat", то обновляем чат добавив в него новое сообщение из data
                {
                    UpdateChat(data);                                                   //Вызов метода обновления чата
                    continue;                                                           //Продолжить цикл
                }
            }
        }

        private void UpdateChat(string data)                                            //Метод обновления чата с добавлением новой строки в чат
        {
            //#updatechat&userName~data|username~data
            string[] messages = data.Split('&')[1].Split('|');                          //строку data делим по знаку &. после деления, вторую половину делим по знаку |. это и является самим сообщением
            int countMessages = messages.Length;                                        //содержит длину массива строк
            if(countMessages<=0)                                                        //Если массив строк <=0 то сообщение было пустым, возвращаемся в цикл прослушивания сокета
            {
                return;                                                                 //Возврат в место вызова метода обновления чата
            }
            for (int i = 0; i < countMessages; i++)                                     //Если сообщение не было пустым
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    print(String.Format("[{0}]:{1}.", messages[i].Split('~')[0], messages[i].Split('~')[1]));   //Вызов метода, который добавляет в чат строку([Ник]:Сообщение пользователя)
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        private void Send(string data)                                                  //Метод для отправки строки data на подключенный сокет
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int byteSent = _serverSocket.Send(buffer);
            }
            catch
            {
                print("Связь с сервером прервалась...");
            }
        }

        private void connect()                                                          //Метод который устанавливает соединение с сервером
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);                                         //IP сервера
                IPAddress ipAddress = ipHost.AddressList[0];                                                //
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);                             //

                _serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);   //Инициализация серверного Сокета
                _serverSocket.Connect(ipEndPoint);                                                          //Устанавливает подключение к удаленному узлу
            }
            catch(Exception ex)
            {
                print("Сервер недоступен!");
                Console.WriteLine("");
            }
        }

        private void clearChat()                                                        //Метод очищающий чат
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Cleaner);
                return;
            }
            chatBox.Clear();                                                            //Очистка Чата
        }

        private void print(string msg)                                                  //Метод обновления Чата
        {
            if(this.InvokeRequired)                                                     //
            {
                this.Invoke(Printer, msg);
                return;
            }
            if (chatBox.Text.Length == 0)
                chatBox.AppendText(msg);                                                //Добавление строки в Чат
            else
                chatBox.AppendText("\n" + msg);                                         //Добавление строки в Чат
        }     
       
        private void enterChat_Click_1(object sender, EventArgs e)                      //Кнопка "Войти в чат"
        {
            string Name = userName.Text;                                                //Присваиваем имя пользователя из поля userName
            if (string.IsNullOrEmpty(Name)) return;                                     //Если имя пустое то возвращаемся в место вызова метода
            Send("#setname&" + Name);                                                   //Отправляем на сервер сообщение с именем Пользователя с командой для добавления нового пользователя
            chatBox.Enabled = true;                                                     //доступен
            chat_msg.Enabled = true;                                                    //доступен
            chat_send.Enabled = true;                                                   //доступен
            userName.Enabled = false;                                                   //недоступен
            enterChat.Enabled = false;                                                  //недоступен
        }

        private void sendMessage()                                                      //Метод отправки сообщения на сервер
        {
            try
            {
                string data = chat_msg.Text;                                            //Копирование текста сообщения из поля сообщения
                if (string.IsNullOrEmpty(data)) return;                                 //если поле сообщений было пустым то возвращаемся в место вызова данного метода
                Send("#newmsg&" + data);                                                //Отправка сообщения с командой "#newmsg&" - новое сообщение
                chat_msg.Text = string.Empty;                                           //Очистка поля сообщений
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }

        private void chat_send_Click(object sender, EventArgs e)                        //Кнопка отправить сообщение        
        {
            sendMessage();                                                              //Вызов метода отправки сообщения на сервер
        }

        private void chatBox_KeyDown(object sender, KeyEventArgs e)                     //Кнопка Enter
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

        private void chat_msg_KeyDown(object sender, KeyEventArgs e)                    //Кнопка Enter
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }
    }
}
