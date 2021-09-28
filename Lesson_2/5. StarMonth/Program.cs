using System;

namespace _5._StarMonth
{
    class Program
    {
        static void Main(string[] args)
        {
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
            
            // Month number
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
                        // Temp
                        Console.Write("Введи минимальную и максимальную температуру за сутки в формате 'X,Y': ");
                        string userInput = Console.ReadLine();
                        int minTemp = Convert.ToInt32(userInput.Split(",")[0]);
                        int maxTemp = Convert.ToInt32(userInput.Split(",")[1]);
                        float mediumTemp = (minTemp + maxTemp) / 2;
                        Console.WriteLine($"Среднесуточная температура составляет: {mediumTemp}");
                        switch (numb)
                        {
                            case 1:
                            case 2:
                            case 12:
                                if (mediumTemp > 0)
                                {
                                    Console.WriteLine("Дождливая зима");
                                }
                                break;

                        }
                        break;
                }
            } while (falseInput);
        }
    }
}
