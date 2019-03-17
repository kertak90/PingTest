using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace ExcelFileRead
{
    class ChatServer
    {
        public static List<ChatClient> Clients = new List<ChatClient>();                    //Хранится список всех Клиентов

        public static void NewClient(Socket handle)                                         //Метод добавляющий нового клиента в список клиентов 
        {
            try
            {
                ChatClient newClient = new ChatClient(handle);                              //handle сокет клиента
                Clients.Add(newClient);                                                     //Добавление в список нового клиента
                Console.WriteLine("Новый клиент соединился: {0}", handle.RemoteEndPoint);   //Вывод сообщения в консоли с адресом конечной точки клиента
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка с добавлением клиента: ");
            }
        }

        public static void EndClient(ChatClient client)                                     //Метод удаляющий клиента из списка клиентов
        {
            try
            {
                Clients.Remove(client);                                                     //Удаление клиента client из списка клиентов
                Console.WriteLine("Поьзователь {0} отключился.", client.UserName);          //Вывод сообщения в консоль об отключении клиента
            }
            catch(Exception exp)
            {
                Console.WriteLine("Ошибка выхода клиента: {0}", client.UserName);
            }            
        }

        public static void UpdateAllChats()                                                 //Метод который вызывает у всех пользователей метод обновления чата
        {
            try
            {
                int countUsers = Clients.Count;                                             //Запись в countUsers количества всех клиентов
                for (int i = 0; i < countUsers; i++)                                        //перебор всех клиентов
                {
                    Clients[i].UpdateChat();                                                //Каждому клиенту отправляется команда обновления чата со всем чатом
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка при обновлении всего чата: {0}", ex.Message);
            }
        }
    }
}
