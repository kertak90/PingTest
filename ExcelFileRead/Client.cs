using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;


namespace ExcelFileRead
{
    class ChatClient
    {
        private string _userName;                   //Имя клиента
        private Socket _handler;                    //Сокет клиента
        private Thread _userThread;                 //отдельный поток клиента

        public ChatClient(Socket socket)            //Конструктор Клиента
        {
            _handler = socket;                      //
            _userThread = new Thread(listner);      //Инициализация потока
            _userThread.IsBackground = true;        //Поток фоновый
            _userThread.Start();                    //Запуск потока клиента
        }

        public string UserName
        {
            get { return _userName; }
        }

        private void listner()                      //Поток клиента
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];                                 //Буфер для данных из сокета
                    int bytesRec = _handler.Receive(buffer);                        //Получение данных из сокета
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);     //декодирование последовательности байтов в строку
                    handleComand(data);                                             //передача строки из сокета в метод обработки сообщения 
                }
                catch
                {
                    ChatServer.EndClient(this);
                }
            }
        }

        private void handleComand(string data)                                      //Метод обработки входящего сообщения из сокета                                  
        {
            if (data.Contains("#setname"))                                          //команда установить имя нового пользователя
            {
                _userName = data.Split('&')[1];                                     //Деление строки по символу &. вторая половина сообщения будет содержать Имя клиента
                UpdateChat();                                                       //Обновить чат
                return;                                                             //вернуться в место вызова метода
            }
            if(data.Contains("#newmsg"))                                            //команда Добавить новое сообщение в чат
            {
                string message = data.Split('&')[1];                                //Деление строки по символу &. вторая половина сообщения будет содержать Новое сообщение
                ChatController.AddMessage(_userName,message);                       //Вызов метода добавления в чат нового сообщения. передаем в него имя клиента и само собщение
                return;                                                             //вернуться в место вызова метода
            }
        }

        public void End()                                                           //Метод закрытия 
        {
            try
            {
                _handler.Close();                                                   //Закрыть подключение к сокету
                try
                {
                    _userThread.Abort();                                            //Вызов метода заверщающего поток клиента
                }
                catch { } // г
            }
            catch (Exception exp) { Console.WriteLine("Error with end: {0}.", exp.Message); }
        }

        public void UpdateChat()                                                    //Метод обновления чата
        {
            Send(ChatController.GetChat());                                         //Вызов метода отправки команды управления по сокету. GetChat возвращает команду управления чатом. будет содержать #updatechat&
        }

        public void Send(string command)                                            //Метод отправки команды управления чатом в сокет
        {
            try
            {
                byte[] buffer = new byte[8196];                                     //Объявление буфера(байтов данных)
                int byteSent = _handler.Send(buffer);                               //Отправка в Сокет данных буфера. byteSent содержит число отправленных байт
                if (byteSent > 0)                                                   //Если отправлено байт больше нуля, то успешно
                    Console.WriteLine("Успешно");
            }
            catch(Exception exp)
            {
                Console.WriteLine("Ошибка при отправке команды: {0}", exp.Message);
                ChatServer.EndClient(this);                                         //Вызов метода по удалению данного клиента
            }
        }
    }
}
