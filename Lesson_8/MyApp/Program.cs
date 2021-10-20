using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var greatingUser = "SayHello";
            var nameUser = "Name";
            var ageUser = "Age";
            var emplUser = "Employment";
            var editUser = "Last edit";
            string[] varStrings = new string[] {nameUser, ageUser, emplUser, editUser};

            // Create and read config greating
            if (ConfigurationManager.AppSettings.Count == 0)
            {
                ConfigUpdate(greatingUser, "Hello, peace of meat!!!");
            }
            Console.WriteLine(ConfigurationManager.AppSettings[greatingUser]);

            //Check, if config include user data
            if (ConfigurationManager.AppSettings.Count > 1)
            {
                Console.WriteLine($"Last input name: {ConfigurationManager.AppSettings[nameUser]}");
                Console.WriteLine($"Last input age: {ConfigurationManager.AppSettings[ageUser]}");
                Console.WriteLine($"Last input employment: {ConfigurationManager.AppSettings[emplUser]}");
                Console.WriteLine($"Last edit file: {ConfigurationManager.AppSettings[editUser]}");
            }
            Console.Write("Do you want to reinput (y/n): ");
            bool isReinput = Console.ReadLine() == "y"? true: false;


            // User data input
            if (isReinput)
            {
                // Clearing file
                foreach(string i in varStrings)
                {
                    ConfigClear(i);
                }
                // Reinput
                Console.Write("Enter your name: ");
                var usName = Console.ReadLine();
                Console.Write("Enter your age: ");
                var usAge = Console.ReadLine();
                Console.Write("Enter your employment: ");
                var usEmpl = Console.ReadLine();
                var runDateTime = DateTime.Now.ToShortDateString();
                ConfigUpdate(nameUser, usName);
                ConfigUpdate(ageUser, usAge);
                ConfigUpdate(emplUser, usEmpl);
                ConfigUpdate(editUser, runDateTime);
            }
            
        }
        static void ConfigUpdate(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var configSet = config.AppSettings.Settings;
            configSet.Add(key, value);
            config.Save();
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }
        static void ConfigClear(string key)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var configSet = config.AppSettings.Settings;
            configSet.Remove(key);
            config.Save();
        }
    }
}
