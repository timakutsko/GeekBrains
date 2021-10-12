using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isInput = true;
            string dataJson = File.ReadAllText("todo.json");
            TODOList data = JsonSerializer.Deserialize<TODOList>(dataJson);
            if (dataJson.Length > 0)
            {
                UserOutput(data);
            }


            List<TODO> LTD = new List<TODO> { };
            int numb = 1;
            if (dataJson.Length > 0)
            {
                TODOList inJsonFile = JsonSerializer.Deserialize<TODOList>(dataJson);
                foreach(TODO inJF in inJsonFile.Items)
                {
                    LTD.Add(inJF);
                    numb = inJF.Number;
                }
            }
            while (isInput)
            {
                Console.Write("Do you need to input (y/n): ");
                isInput = Console.ReadLine() == "y" ? true : false;
                if (!isInput) 
                { 
                    break; 
                }
                Console.Write("Task name: ");
                var taskName = Console.ReadLine();
                Console.Write("Is done (y/n): ");
                bool isDone = Console.ReadLine() == "y" ? true : false;
                TODO inpToDo = new TODO() { Number = ++numb, Title = taskName, IsDone = isDone };
                LTD.Add(inpToDo);
                
                TODOList workList = new TODOList() { Items = LTD };
                string json = JsonSerializer.Serialize(workList);
                File.WriteAllText("todo.json", json);

                string desJson = File.ReadAllText("todo.json");
                TODOList newJs = JsonSerializer.Deserialize<TODOList>(desJson);
                Console.WriteLine();
                UserOutput(newJs);
            }

            Console.Write("Write a number of task if it done, or press 'Enter', if nothing to change: ");
            string userInputLast = Console.ReadLine();
            if (userInputLast.Length > 0)
            {
                int numbToChange = Convert.ToInt32(userInputLast);
                string desdesJson = File.ReadAllText("todo.json");
                TODOList lastJs = JsonSerializer.Deserialize<TODOList>(desdesJson);
                foreach (TODO it in lastJs.Items)
                {
                    if (it.Number == numbToChange)
                    {
                        it.IsDone = true;
                    }
                }
                string json = JsonSerializer.Serialize(lastJs);
                File.WriteAllText("todo.json", json);
                UserOutput(JsonSerializer.Deserialize<TODOList>(File.ReadAllText("todo.json")));
            }
        }


        static void UserOutput(TODOList todoData)
        {
            Console.WriteLine("In list: ");
            foreach (TODO it in todoData.Items)
            {
                Console.Write(it.Number + ". " + it.Title + ": " + it.UserView(it.IsDone));
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
