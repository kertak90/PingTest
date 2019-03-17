using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFileRead
{
    public class ChatController
    {
        private const int _maxMessage = 100;                                            //максимальное количество сообщений в чате
        private static List<message> Chat = new List<message>();                        //Хранит Весь чат   

        public struct message                                                           //Структура Сообщение
        {
            public string userName;                                                     //хранит имя пользователя
            public string data;                                                         //и его сообщение

            public message(string name, string msg)                                     //метод для задания и инициализации сообщения
            {
                userName = name;
                data = msg;
            }
        }

        public static void AddMessage(string userName, string msg)                      //Метод для добавления в список нового сообщения
        {
            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(msg)) return;    //Если имя пользователя пустое ИЛИ сообщение пустое то возврат в место вызова метода
                int countMessages = Chat.Count;                                             //Запись в countMessages общего количества сообщений в чате
                if (countMessages > _maxMessage)                                            //Если сообщений в чате больше _maxMessage=100 то список сообщений очищается
                    ClearChat();                                                            //Вызов метода очистки чата
                message newMessage = new message(userName, msg);                            //объявление и инициализация нового сообщения, для добавления
                Chat.Add(newMessage);                                                       //Добавление в список Сообщений нового сообщения
                Console.WriteLine("Новое сообщение от {0}:msg", userName, msg);             //Вывод в консоли сервера сообщения о добавлении нового сообщения
                ChatServer.UpdateAllChats();                                                //Вызов метода рассылающего всем клиентам команды об обновлении чатов
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении сообщения: {0}", ex.Message);
            }
        }

        public static void ClearChat()                                                      //Метод очистки чата
        {
            Chat.Clear();                                                               //Очистка списка сообщений
        }

        public static string GetChat()                                                      //Метод, который формирует команду обновления чата клиентов и возвращает ее в место его вызова
        {
            try
            {
                string data = "#updatechat&";                                               //Сама команда одновления
                int countMessages = Chat.Count;                                             //передача в countMessages количества всех сообщений
                if (countMessages <= 0) return string.Empty;                                //Если в чате сообщений не было, то обновлять чат не нужно и команда управления будет нулевой, программа перейдет в место вызова с нулевой командой. 
                for (int i = 0; i < countMessages; i++)                                     //В цикле после команды управления в строку добавляются все сообщения чата, формируя одну длинную строку
                {
                    data += String.Format("{0}~{1}|", Chat[i].userName, Chat[i].data);      //имя пользователя ~ сообщение |
                }
                return data;                                                                //Возврат команды управления чатом + все сообщения чата
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при доступе к чату: {0}", ex.Message);
                return string.Empty;
            }
        }
    }
}
