using System;
using System.IO;



namespace ExcelConsole
{
    class Program
    {
        static Microsoft.Office
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");           
            
            string[] str1 = File.ReadAllLines(@"G:\C# projects\PingTest2\PingTest\123.xlsx");
            foreach(string a in str1)
            {
                Console.WriteLine(a);
            }
            Console.ReadLine();
        }
    }
}
