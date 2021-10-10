using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int Fib(int index)
            {
                if (index == 0)
                {
                    return 0;
                }
                else if (index == 1)
                {
                    return 1;
                }
                else
                {
                    return Fib(index - 1) + Fib(index - 2);
                }
            }
            Console.Write("Введи порядковый номер числа Фибоначчи: ");
            int usInput = int.Parse(Console.ReadLine());
            Console.Write($"Ему соответствует значение: {Fib(usInput)}");
        }
    }
}
