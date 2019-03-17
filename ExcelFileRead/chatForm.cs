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
    public partial class chatForm : Form
    {
        private delegate void printer(string data);                 //Объявили делегат с аргументом string
        private delegate void cleaner();                            //Объявили делегат
        printer Printer;                                            //Объявили экземпляр делегата Printer, но не привязали его к методу
        cleaner Cleaner;                                            //Объявили экземпляр делегата Cleaner, но не привязали его к методу
        private Socket _serverSocket;                               //Объявили переменную типа Socket
        private Thread _clientThread;                               //Объявили поток _clientThread, но не привязали его к методу
        //private const string _serverHost = "localhost";
        private string _serverHost = "192.168.1.69";                //Значение IP по умолчанию на домашнем ноутбуке
        
        private const int _serverPort = 904;                        //Значение порта по умолчанию

        public chatForm()                                           //Инициализация формы
        {
            InitializeComponent();
            Printer = new printer(print);                           //привязали делегат к методу. Printer есть второе имя метода print
            Cleaner = new cleaner(clearChat);                       //привязали делегат к методу. Cleaner есть второе имя метода clearChat
            //connect();
            _clientThread = new Thread(listner);                    //Привязали поток _clientThread к методу listner, но запустим его при нажатии кнопки соединиться
            _clientThread.IsBackground = true;                      //Поток является фоновым
            //_clientThread.Start();
        }
        private void listner()
        {
            while (_serverSocket.Connected)
            {
                try
                {
                    byte[] buffer = new byte[8196];                                 //Массив байтов для информации из Сокета 
                    int bytesRec = _serverSocket.Receive(buffer);                   //Возвращает количество байтов для декодирования, метод получает массив байтов и записывает в buffer
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);     //Декодирование массива байтов в строку
                    if (data.Contains("#updatechat"))                               //Если в начале строки был текст "#updatechat" то
                    {
                        UpdateChat(data);                                           //Вызовем метод для обновления чата 
                        continue;                                                   //Продолжим прослушивание сокета
                    }
                }
                catch
                {

                }                
            }
        }
        private void connect()
        {
            try
            {
                //IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);                                             //Разрешает заданный IP адрес для подключения
                //IPAddress ipAddress = ipHost.AddressList[0];                                                    //Хранит разрешенный IP адресс
                //IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);                                 //Параметры удаленного узла(сервера)
                //_serverSocket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);    //Инициализировали Сокет
                //_serverSocket.Connect(ipEndPoint);                                                              //Установление подключения к удаленному узлу(серверу)

                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Connect(_serverHost, _serverPort);
               

            }
            catch { print("Сервер недоступен!"); }
        }
        private void clearChat()                                                                                //Метод для очистки чата
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Cleaner);                                                                           //Выполняет делегат              
                return;
            }
            chatBox.Clear();                                                                                    //Удаляет весь текст из текстового поля
        }
        private void UpdateChat(string data)                                                                    //Метод для обновления чата
        {
            //#updatechat&userName~data|username~data
            clearChat();                                                                                        //сначала очистим чат
            string[] messages = data.Split('&')[1].Split('|');                                                  //Строку data разделим по знаку &. Вторую половину сообщения разделим по | . messages будет хранить данные пользователя и сообщение
            int countMessages = messages.Length;                                                                //количество сообщений                                                           
            if (countMessages <= 0) return;                                                                     //Если сообщения нет то выходим из метода
            Console.Beep(500, 200);                                                                             
            for (int i = 0; i < countMessages; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    print(String.Format("[{0}]:{1}.", messages[i].Split('~')[0], messages[i].Split('~')[1]));   //{0} - хранит Имя пользователя, {1} - хранит команду пользователя
                    
                }
                catch { continue; }
            }
        }        

        private void print(string msg)                                                              //Метод для добавления сообщения в конец chatBox
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg);
                return;
            }
            if (chatBox.Text.Length == 0)
            {
                chatBox.AppendText(msg);                
            }                                                                          
            else
            {
                chatBox.AppendText(Environment.NewLine + msg);                
            }
                
        }

        private void enterChat_Click(object sender, EventArgs e)                                    //Метод для соединения с Сервером
        {
            string Name = userName.Text;                                                            //Переменной Name присвоим значение из текстового поля Name
            if (string.IsNullOrEmpty(Name)) return;
            connect();                                                                              //Метод connect, который устанавливает подключение
            chatBox.Enabled = true;
            chat_msg.Enabled = true;
            chat_send.Enabled = true;
            userName.Enabled = false;
            enterChat.Enabled = false;
            ServerHost.Enabled = false;

            _serverHost = ServerHost.Text;
            _clientThread.Start();                                                                  //Запуск потока с бесконечным циклом 
            send("#setname&" + Name);                                                               //Отправим на сервер команду регистрации на сервере
        }

        private void send(string data)                                                              //Метод для отправки сообщения в сокет
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);                                       //Кодируем сообщение в байтовый массив
                int bytesSent = _serverSocket.Send(buffer);                                         //Отправляем байтовые данные в Сокет 
            }
            catch { print("Связь с сервером прервалась..."); }
        }

        private void chat_send_Click(object sender, EventArgs e)
        {
            sendMessage();                                                                          //Вызов метода отправки сообщения
        }

        private void sendMessage()                                                                  //Метод для отправки сообщения на сервер(в чат)
        {
            try
            {
                string data = chat_msg.Text;                                                        //скопируем сообщение из поля ввода в data
                if (string.IsNullOrEmpty(data)) return;                                             //Если сообщение пустое то отправки не происходит
                send("#newmsg&" + data);                                                            //отправка сообщения
                chat_msg.Text = string.Empty;                                                       //очистим поле ввода сообщения
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }
        private void chatBox_KeyDown(object sender, KeyEventArgs e)                                 //Нажатие Enter при вводе сообщения 
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

        private void chat_msg_KeyDown(object sender, KeyEventArgs e)                                //Нажатие кнопки отправить сообщение
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

        private void ServerHost_TextChanged(object sender, EventArgs e)                             //Ввод IP в поле ввода
        {
            _serverHost = ServerHost.Text;
        }
    }
}
