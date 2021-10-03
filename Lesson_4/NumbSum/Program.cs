using System;

namespace NumbSum
{
    class Program
    {
        static void Main(string[] args)
        {
            void MySum(string usStr)
            {
                int sum = 0;
                var chArr = usStr.Split(" ");
                foreach(string curChar in chArr)
                {
                    if (int.TryParse(curChar, out int numb))
                    {
                        sum += numb;
                    }
                    else
                    {
                        Console.WriteLine("Только числа!");
                        Environment.Exit(0);
                    }
                }
                Console.WriteLine($"Сумма: {sum}");
            }
            Console.Write("Введи числа разделенные пробелом: ");
            var usInput = Console.ReadLine();
            MySum(usInput);
        }
    }
}
