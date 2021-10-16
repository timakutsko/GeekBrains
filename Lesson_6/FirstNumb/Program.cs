using System;
using System.Linq;

namespace FirstNumb
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var intArr = new int[] { -9, 6, 4, 9, 59, 2, 3, 1, 6, 7 };
            intArr = intArr.Where(val => val > 0).ToArray();
            int minInt = 1;
            int trueMinInt = 1;
            foreach(int i in intArr)
            {
                minInt = i < minInt ? i : minInt;
            }
            if (minInt == 1 && !intArr.Contains(minInt))
            {
                Console.WriteLine(trueMinInt);
            }
            else
            {
                minInt++;
                foreach(int j in intArr)
                {
                    if (!intArr.Contains(minInt))
                    {
                        trueMinInt = minInt;
                    }
                    else
                    {
                        minInt++;
                    }
                }
                Console.WriteLine(trueMinInt);
            }
        }
    }
}
