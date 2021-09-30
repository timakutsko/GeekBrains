using System;

namespace _7._Rome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введи римскую цифру: ");
            var romeNumb = Console.ReadLine().ToLower();
            Console.Write("Арабская цифра: ");
            int arabNumb = 0;
            foreach (char c in romeNumb)
            {
                if (romeNumb.EndsWith("i") && c == 'i')
                {
                    arabNumb += 1;
                }
                else if (c == 'i')
                {
                    arabNumb -= 1;
                }
                if (c == 'v')
                {
                    arabNumb += 5;
                }
                if (c == 'x')
                {
                    arabNumb += 10;
                }
                if (c == 'l')
                {
                    arabNumb += 50;
                }
                if (c == 'c')
                {
                    arabNumb += 100;
                }
                if (c == 'd')
                {
                    arabNumb += 100;
                }
                if (c == 'm')
                {
                    arabNumb += 1000;
                }
            }
        Console.WriteLine(arabNumb);
        }
    }
}

                