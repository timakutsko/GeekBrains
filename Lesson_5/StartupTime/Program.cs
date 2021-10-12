using System;
using System.IO;

namespace StartupTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "startup.txt";
            if (File.ReadAllText(fileName).Length > 0)
            {
                File.AppendAllText(fileName, Environment.NewLine);
                AppData(fileName);
            }
            else
            {
                AppData(fileName);
            }

            static void AppData(string name)
            {
                File.AppendAllText(name, DateTime.Now.ToString());
            }
        }
    }
}
