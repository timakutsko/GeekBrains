using System;

namespace _2._MonthNumb
{
    class Program
    {
        static void Main(string[] args)
        {
            bool falseInput;
            do
            {
                int numb = UserInput();
                switch (numb)
                {
                    case < 0:
                        Console.WriteLine("Не может быть отрицательного месяца. Нажми Esc для выхода, или нажми любую кнопку для повторного ввода");
                        falseInput = CheckInput();
                        break;
                    case > 12:
                        Console.WriteLine("В году 12 месяцев. Нажми Esc для выхода, или нажми любую кнопку для повторного ввода");
                        falseInput = CheckInput();
                        break;
                    default:
                        DateTime moment = new DateTime(1999, numb, 1);
                        Console.WriteLine($"Это - {moment.ToString("MMMM")}");
                        falseInput = false;
                        break;
                }
            } while (falseInput);
        }
        static int UserInput()
        {
            Console.Write("Введи номер месяца: ");
            int numbInput = Convert.ToInt32(Console.ReadLine());
            return numbInput;
        }
        static bool CheckInput()
        {
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
