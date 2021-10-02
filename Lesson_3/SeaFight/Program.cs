using System;

namespace SeaFight
{
    class Program
    {
        static void Main(string[] args)
        {
            var seaArea = new char[10, 10]
            {
                {'O', 'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'X' },
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' },
                {'O', 'O', 'X', 'X', 'X', 'O', 'O', 'O', 'O', 'O' },
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O' },
                {'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O' },
                {'O', 'O', 'O', 'X', 'X', 'O', 'O', 'O', 'X', 'O' },
                {'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O' },
                {'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O' },
                {'O', 'O', 'O', 'O', 'X', 'X', 'X', 'O', 'O', 'O' },
                {'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' },
            };
            int rows = seaArea.GetUpperBound(0) + 1;
            int colums = seaArea.Length / rows;
            for(int i=0; i<rows; i++)
            {
                for(int j=0; j<colums; j++)
                {
                    Console.Write($"{seaArea[i,j]} ");
                }
                Console.WriteLine();   
            }
        }
    }
}
