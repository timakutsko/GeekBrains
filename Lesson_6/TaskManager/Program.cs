using System;
using System.Diagnostics;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            int sumPrs = processes.Length;
            Console.WriteLine($"Всего процессов {sumPrs}. Вот их список в формате 'Имя ---> Id процесса ---> Память процесса': ");
            foreach(Process curPrs in processes)
            {
                Console.Write($"{curPrs.ProcessName} ---> {curPrs.Id} ---> {curPrs.WorkingSet64/1024}");
                Console.WriteLine();
            }
            Console.WriteLine("______________________________________________");
            Console.Write("Введи имя процесса/-ов, или id 1-го процесса для завершения: ");
            int prsID = Convert.ToInt32(Console.ReadLine());
            Process curPrsToKill = Process.GetProcessById(prsID);
            curPrsToKill.Kill();
        }
    }
}
