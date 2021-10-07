using System;

namespace daigMatr
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             1,2,3
             4,5,6
             7,8,9
             1,2,3

             1,2,3,4,5,6
             9,9,9,9,9,9
            */
            static void mainDiag(int[,] array)
            {
                int rows = array.GetUpperBound(0) + 1;
                int colums = array.Length / rows;
                for(int i=0; i<colums; i++)
                {
                    for (int j=0; j<rows; j++)
                    {
                        if (i == j)
                        {
                            Console.WriteLine(array[i,j]);
                        }
                    }
                }
            }
            
            
            var array_1 = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, {7, 8, 9 }, {1, 2, 3 } };
            var array_2 = new[,] { { 1, 2, 3, 4, 5 }, { 9, 9, 9, 9, 9 } };
            Console.WriteLine("Диагональ матрицы 1: ");
            mainDiag(array_1);
            Console.WriteLine("Диагональ матрицы 2: ");
            mainDiag(array_2);
        }
    }
}
