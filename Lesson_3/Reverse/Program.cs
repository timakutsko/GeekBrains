using System;

namespace Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введи слово для переворота: ");
            string usInput = Console.ReadLine();
            for(int i = usInput.Length - 1; i>-1; i--)
            {
                Console.Write($"{usInput[i]}");
            }
        }
    }
}
