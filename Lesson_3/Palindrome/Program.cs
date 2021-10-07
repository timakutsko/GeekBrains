using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            baccawrserttreystyaq => erttre
            bacca => acca
            bacxe => e
             */
            Console.Write("Введи символы: ");
            var str = Console.ReadLine();
            var palindr = new char[str.Length+1];
            int maxJ = 0;
            for (int i=0; i<str.Length; i++)
            {
                for (int j=str.Length-1; j>=i; j--)
                {
                    if (str[i] == str[j])
                    {
                        if ((i < str.Length - 1) && (j > 0) && (str[i + 1] == str[j - 1]))
                        {
                            palindr[i] = str[i];
                            palindr[j] = str[j];
                            if (j >= maxJ)
                            {
                                maxJ = j;
                                palindr[j + 1] = '|';
                            }
                            break;
                        }
                    }
                }
            }
            string[] strPalindr = new string(palindr).Split('|');
            int maxLenght = 0;
            int trueInd = 0;
            for (int i=0; i< strPalindr.Length; i++)
            {
                int strLenght = strPalindr[i].Length;
                if(strLenght > maxLenght)
                {
                    maxLenght = strLenght;
                    trueInd = i;
                }
            }
            Console.WriteLine(strPalindr[trueInd]);
        }
    }
}
