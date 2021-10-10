using System;

namespace Median
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введи значения для массива №1 (через пробел): ");
            string[] strArr_1 = Console.ReadLine().Trim().Split(" ");
            Console.Write("Введи значения для массива №2 (через пробел): ");
            string[] strArr_2 = Console.ReadLine().Trim().Split(" ");
            int p1 = strArr_1.Length;
            int p2 = strArr_2.Length;
            var sum = p1 + p2;
            p1--;
            p2--;
            float median = 0;
            while (sum > 0)
            {
                if((p2 < 0) || (Convert.ToSingle(strArr_1[p1]) >= Convert.ToSingle(strArr_2[p2])))
                {
                    median = Convert.ToSingle(strArr_1[p1--]);
                }
                else if ((p1 < 0) || (Convert.ToSingle(strArr_1[p1]) <= Convert.ToSingle(strArr_2[p2])))
                {
                    median = Convert.ToSingle(strArr_2[p2--]);
                }
                sum -= 2;
            }
            if (sum == 0)
            {
                if ((p2 < 0) || (Convert.ToSingle(strArr_1[p1]) >= Convert.ToSingle(strArr_2[p2])))
                {
                    median = (Convert.ToSingle(strArr_1[p1--]) + median) / 2;
                }
                else if ((p1 < 0) || (Convert.ToSingle(strArr_1[p1]) <= Convert.ToSingle(strArr_2[p2])))
                {
                    median = (Convert.ToSingle(strArr_2[p2--]) + median) / 2;
                }
            }
            Console.WriteLine(median);
        }
    }
}
