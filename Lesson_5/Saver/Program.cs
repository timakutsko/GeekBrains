using System;
using System.IO;

namespace Saver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите данные для записи: ");
            File.WriteAllText("saver.txt", Console.ReadLine());
        }
    }
}
