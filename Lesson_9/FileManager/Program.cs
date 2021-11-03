using System;
using System.Windows;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            int width;
            int height;
            try
            {
                string dataJson = File.ReadAllText("Info.json");
                WinInfo wi = JsonSerializer.Deserialize<WinInfo>(dataJson);
                width = wi.Width;
                height = wi.Height;
            }
            catch (FileNotFoundException)
            {
                WinInfo wi = new WinInfo();
                string json = JsonSerializer.Serialize<WinInfo>(wi);
                File.WriteAllText("Info.json", json);
                width = wi.Width;
                height = wi.Height;
            }
            var cnt = -1;
            List<string> userDir = new List<string>();
            do
            {
                var mW = new MainWindow(width, height);
                string userInput = mW.usComm;
                try
                {
                    switch (userInput.ToUpper())
                    {
                        case "DIR":
                            userDir = mW.CommDir();
                            break;
                        case "LDIR":
                            userDir = mW.LastDir();
                            break;
                        case "CPI":
                            mW.CopyItem(userDir);
                            break;
                        case "DLTI":
                            mW.DeleteItem(userDir);
                            break;
                        case "GII":
                            mW.GetItemInfo(userDir);
                            break;
                        case "EXT":
                            return;
                        default:
                            throw new UserExceptions("Некоррктная команда: ", userInput);
                    }
                }
                catch (UserExceptions uexc) when (!uexc.Message.ToUpper().Contains("EXT"))
                {
                    Console.SetCursorPosition(0, mW.outputLines + 10);
                    Console.WriteLine(new string('\uFF3F', Console.WindowWidth)); Console.WriteLine("Логирование ошибок: ");
                    Console.SetCursorPosition(0, Console.GetCursorPosition().Top + (++cnt));
                    Console.WriteLine(uexc.Message);
                }
                catch (Exception) 
                {
                    Console.Write("Обратись к разработчику!");
                    return;
                }
            }
            while (true);
        }
    }
}
