using System;

namespace FirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // по условиям вывести имя пользователя без начального ввода. Это будет так
            Console.WriteLine($"Привет, {Environment.UserName}, сегодня {DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}");
            // а вот сохранить имя пользователя из консоли - я понял так
            var inputUser = Console.ReadLine();
            Console.WriteLine($"Привет, {inputUser}, сегодня {DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}");
        }
    }
}