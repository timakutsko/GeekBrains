using System;

namespace _6._Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            //Matrix
            /*
             График офиса   П В С Ч П С В
            Офис 1          1 1 1 1 1 0 0
            Офис 2          0 1 1 1 1 0 1
            Офис 3          0 0 1 1 1 1 1
            Офис 4          0 0 0 0 0 1 1
            Офис 5          0 0 0 1 0 0 1
             */

            // Day number:
            int day = 0b0000010;
            
            // Office masks:
            int office_1 = 0b1111100;
            int office_2 = 0b0111101;
            int office_3 = 0b0011111;
            int office_4 = 0b0000011;
            int office_5 = 0b0001001;

            // Days in a week:
            bool isWork_1 = (day & office_1) == day;
            bool isWork_2 = (day & office_2) == day;
            bool isWork_3 = (day & office_3) == day;
            bool isWork_4 = (day & office_4) == day;
            bool isWork_5 = (day & office_5) == day;

            switch (isWork_1)
            {
                case true:
                    Console.WriteLine("Офис 1 в этот день работает!");
                    break;
            }
            switch (isWork_2)
            {
                case true:
                    Console.WriteLine("Офис 2 в этот день работает!");
                    break;
            }
            switch (isWork_3)
            {
                case true:
                    Console.WriteLine("Офис 3 в этот день работает!");
                    break;
            }
            switch (isWork_4)
            {
                case true:
                    Console.WriteLine("Офис 4 в этот день работает!");
                    break;
            }
            switch (isWork_5)
            {
                case true:
                    Console.WriteLine("Офис 5 в этот день работает!");
                    break;
            }
        }
    }
}
