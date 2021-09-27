using System;

namespace _3._IsEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введи любое число в диапозоне от -32768 до 32767: ");
            short userInput = Convert.ToInt16(Console.ReadLine());
            if (userInput %2 == 0)
            {
                Console.Write($"Число {userInput} - четное");
            }
            else
            {
                Console.Write($"Число {userInput} - не четное");
            }    
        }
    }
}
