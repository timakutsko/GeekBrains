using System;

namespace MyMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            void GetFullName(string firstName, string lastName, string patronymic)
            {
                Console.WriteLine($"ФИО: {firstName} {lastName} {patronymic}");
            }
            void UserInput(string var)
            {
                Console.Write($"Введи {var}: ");
            }
            
            for(int i=0; i<3; i++)
            {
                UserInput("фамилию");
                var firstName = Console.ReadLine();
                UserInput("имя");
                var lastName = Console.ReadLine();
                UserInput("отчество");
                var patronymic = Console.ReadLine();
                GetFullName(firstName, lastName, patronymic);
            }
        }
    }
}
