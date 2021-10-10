using System;
using System.IO;

namespace Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введи числа в диапозоне от 0 до 255: ");
            string[] strArr_1 = Console.ReadLine().Trim().Split(" ");
            byte[] byteArr = new byte [strArr_1.Length];
            for(int i = 0; i < strArr_1.Length; i++)
            {
                byteArr[i] = Convert.ToByte(strArr_1[i]);
            }
            File.WriteAllBytes("bytes.bin", byteArr);
        }
    }
}
