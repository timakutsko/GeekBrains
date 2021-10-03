using System;

namespace Seasons
{
    class Program
    {
        enum Seasons
        {
        Winter,
        Spring,
        Summer,
        Fall,
        }
        static void Main(string[] args)
        {
            void RusSeason(Seasons season)
            {
                switch (season)
                {
                    case Seasons.Winter:
                        Console.WriteLine("Зима");
                        break;
                    case Seasons.Spring:
                        Console.WriteLine("Весна");
                        break;
                    case Seasons.Summer:
                        Console.WriteLine("Лето");
                        break;
                    case Seasons.Fall:
                        Console.WriteLine("Осень");
                        break;
                }
            }
            
            void GetSeason(string usInput)
            {
                int numb = int.Parse(usInput);
                if(numb < 0 || numb > 12)
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
                }
                else
                {
                    switch (numb)
                    {
                        case 12:
                        case 1:
                        case 2:
                            RusSeason(Seasons.Winter);
                            break;
                        case 3:
                        case 4:
                        case 5:
                            RusSeason(Seasons.Spring);
                            break;
                        case 6:
                        case 7:
                        case 8:
                            RusSeason(Seasons.Summer);
                            break;
                        case 9:
                        case 10:
                        case 11:
                            RusSeason(Seasons.Spring);
                            break;
                    }
                }
            }
            
            Console.Write("Введи номер месяца: ");
            var usInput = Console.ReadLine();
            GetSeason(usInput);
        }
    }
}
