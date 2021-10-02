using System;

namespace phBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            var array = new string[5, 2];
            do
            {
                Console.WriteLine("Введи имя: ");
                var name = Console.ReadLine();
                Console.WriteLine("Введи номер/email: ");
                var adress = Console.ReadLine();
                array[counter, 0] = name;
                array[counter, 1] = adress;
                counter++;
            } while (counter < 5);
            
            Console.WriteLine("Справочник ниже:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{array[i, 0]}: ");
                Console.WriteLine(array[i, 1]);
                Console.WriteLine();
            }
        }
    }
}
