using System;

namespace _1._Temperature
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введи минимальную и максимальную температуру за сутки в формате 'X,Y': ");
            string userInput = Console.ReadLine();
            int minTemp = Convert.ToInt32(userInput.Split(",")[0]);
            int maxTemp = Convert.ToInt32(userInput.Split(",")[1]);
            Console.Write($"Среднесуточная температура составляет: {(float)(minTemp + maxTemp) / 2}");
        }
    }
}
