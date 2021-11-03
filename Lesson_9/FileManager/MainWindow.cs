using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    
    class MainWindow
    {
        public int width { get; }
        public int outputLines { get; }
        public string usComm;
        private int[] usCommPos = new int[2];
        /// <summary>
        /// Создание окна ввода-вывода
        /// </summary>
        /// <returns>Созданное окно консоли</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public MainWindow(int width, int outputLines)
        {
            this.width = width;
            this.outputLines = outputLines;
            var height = outputLines + 15;
            Console.SetWindowSize(width, height);
            Console.SetCursorPosition(0, height-10);
            Console.WriteLine(new string ('\u2550', width));
            ColorWrite("Список доступных функций:");
            ColorWrite("Ввести новый путь", "Dir");
            ColorWrite("Открыть предыдущий ввод директории", "LDir");
            ColorWrite("Копировать папку/файл", "CpI");
            ColorWrite("Удалить папку/файл", "DltI");
            ColorWrite("Узнать информацию о папке/файле", "GII");
            ColorWrite("Выход", "Ext");
            Console.WriteLine();
            Console.WriteLine(new string('\u2550', width));
            ColorWrite("Командная срока: ");
            usComm = CmdWrite(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top);
            usCommPos[0] = Console.GetCursorPosition().Left;
            usCommPos[1] = Console.GetCursorPosition().Top;
        }
        /// <summary>
        /// Окраска выводимой строки
        /// </summary>
        private void ColorWrite(string discr)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(discr);
            Console.ResetColor();
        }
        /// <summary>
        /// Окраска обозначения команды
        /// </summary>
        private void ColorWrite(string discr, string comm)
        {
            Console.ResetColor();
            Console.Write($"{discr}: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{comm}");
            Console.ResetColor();
            Console.Write("; ");
        }
        /// <summary>
        /// Пользовательский ввод. Командная строка
        /// </summary> 
        private string CmdWrite(int left, int top)
        {
            return UserInputLine("Введи команду: ", left, top, true);
        }
        /// <summary>
        /// Пользовательский ввод. Чистка предыдущего ввода (строки)
        /// </summary>        
        private void LineClear(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }
        /// <summary>
        /// Пользовательский ввод. Чистка предыдущего ввода ( спец. диапозон)
        /// </summary> 
        private void AreaClear(int left, int top)
        {
            for (int j = left; j <= top; j++)
            {
                LineClear(left, j);
            }
        }
        /// <summary>
        /// Пользовательский ввод. Ввод данных в указанную строку
        /// </summary> 
        private string UserInputLine(string discr, int posLeft, int posTop, bool isClean)
        {
            Console.SetCursorPosition(posLeft, posTop);
            if (isClean) 
            { 
                LineClear(posLeft, posTop); 
            }
            Console.Write(discr);
            return Console.ReadLine();
        }
        /// <summary>
        /// Пользовательский вывод. Вывод данных в указанной строке
        /// </summary> 
        private void UserOutput(string discr, int posLeft, int posTop)
        {
            Console.SetCursorPosition(posLeft, posTop);
            Console.WriteLine(discr);
        }
        /// <summary>
        /// Команда вывода списка файлов/папок на экран
        /// </summary>
        public List<string> CommDir(string usPath = null)
        {
            List<string> disList = new List<string>();
            AreaClear(0, this.outputLines + 4);
            Console.SetCursorPosition(0, 0);
            string usNumbList;
            string isRepeat;
            if (usPath == null)
            {
                Console.Write("Введи путь: ");
                usPath = Console.ReadLine();
            }
            try
            {
                var dis = Directory.GetFileSystemEntries(usPath);
                var firstNumb = dis.Length / (this.outputLines);
                var secondNumb = dis.Length % (this.outputLines);
                var listParts = secondNumb == 0 ? firstNumb : ++firstNumb;
                do
                {
                    disList.Clear();
                    AreaClear(2, this.outputLines + 4);                
                    usNumbList = UserInputLine($"Список состоит из {listParts} листов. Введи № листа для отображения: ", 
                                               0, 
                                               1, 
                                               true);
                    int usNumb = Convert.ToInt32(usNumbList);
                    if (usNumb > listParts || usNumb < 0)
                    {
                        throw new UserExceptions($"Введено число вне диапозона страниц: 1 - {listParts} ", String.Empty);
                    }
                    for (int i = (usNumb - 1) * this.outputLines; i< usNumb * this.outputLines; i++)
                    {
                        if(i< dis.Length)
                        {
                            UserOutput($"{i}. {dis[i]}", Console.GetCursorPosition().Left, Console.GetCursorPosition().Top);
                            disList.Add(dis[i]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine(new string('\uFF3F', this.width));
                    Console.WriteLine($"Это - лист №{usNumbList}");
                    Console.Write("Введи команду выхода 'Ext' для перехода в командную строку, или любой другой символ для изменения листа: ");
                    isRepeat = Console.ReadLine();
                }
                while (isRepeat.ToUpper() != "EXT");
                LineClear(0, Console.GetCursorPosition().Top-1);
                // Запись в файл
                string json = JsonSerializer.Serialize(disList);
                File.WriteAllText("LDir.json", json);
            }
            catch (DirectoryNotFoundException)
            {
                var exc = new UserExceptions("Это не путь директории. Повтори ввод с самого начала", String.Empty);
                Console.WriteLine(exc.Message);
            }
            return disList;
        }
        /// <summary>
        /// Команда вывода списка файлов/папок на экран с последнего ввода
        /// </summary>
        public List<string> LastDir(string usPath = null)
        {
            try
            {
                string dataJson = File.ReadAllText("LDir.json");
                AreaClear(0, this.outputLines + 4);
                Console.SetCursorPosition(0, 0);
                List<string> disList = new List<string>();
                List<string> inJsonFile = JsonSerializer.Deserialize<List<string>>(dataJson);
                Console.WriteLine("Предыдущий вывод директории: ");
                for (int i = 0; i < inJsonFile.Count; i++)
                {
                    UserOutput($"{i}. {inJsonFile[i]}", Console.GetCursorPosition().Left, Console.GetCursorPosition().Top);
                    disList.Add(inJsonFile[i]);
                }
                return disList;
            }
            catch (FileNotFoundException)
            {
                throw new UserExceptions($"Ввода еще не осуществлялось! ", String.Empty);
            }
        }
        /// <summary>
        /// Копировать директорию
        /// </summary>public void UpDir()
        public void CopyItem(List<string> usDir)
        {
            var checkedItem = GetTrueItem(usDir, "Введи номер папки/файла для копирования: ");
            var newdItem = checkedItem + "_копия";
            try
            {
                var fileType = Path.GetExtension(checkedItem);
                var newFileName = checkedItem.Split(fileType)[0] + "_копия" + fileType;
                File.Copy(checkedItem, @newFileName);
            }
            catch
            {
                Directory.CreateDirectory(@newdItem);
                CopyFilesRecursively(new DirectoryInfo(@checkedItem), new DirectoryInfo(@newdItem));
            }
            AreaClear(0, this.outputLines + 4);
            UserOutput($"Успешно скопировал папку/файл: {checkedItem}", 0, 0);
        }
        /// <summary>
        /// Копирование ВСЕХ поддиректорий и файлов
        /// </summary>
        private static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }
        /// <summary>
        /// Размер папки
        /// </summary>
        private static long DirSizeInfo(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSizeInfo(di);
            }
            return size;
        }
        /// <summary>
        /// Удалить директорию
        /// </summary>
        public void DeleteItem(List<string> usDir)
        {
            var checkedItem = GetTrueItem(usDir, "Введи номер папки/файла для удаления: ");
            try
            {
                Directory.Delete(@checkedItem, true);
            }
            catch
            {
                File.Delete(@checkedItem);
            }
            AreaClear(0, this.outputLines + 4);
            UserOutput($"Успешно папку/файл папку: {checkedItem}", 0, 0);
        }
        /// <summary>
        /// Получение информации о папке/файле
        /// </summary>
        public void GetItemInfo(List<string> usDir)
        {
            int cnt = -1;
            var checkedItem = GetTrueItem(usDir, "Введи номер папки/файла для получения данных: ");
            AreaClear(0, this.outputLines + 4);
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@checkedItem);
                UserOutput($"Время создания: {dirInfo.CreationTime}", 0, ++cnt);
                UserOutput($"Размер папки, байт: {DirSizeInfo(dirInfo)}", 0, ++cnt);
            }
            catch
            {
                FileInfo fileInfo = new FileInfo(@checkedItem);
                UserOutput($"Время создания: {fileInfo.CreationTime}", 0, ++cnt);
                UserOutput($"Размер файла, байт: {fileInfo.Length}", 0, ++cnt);
            }
        }
        /// <summary>
        /// Поиск нужной позиции для удаления/копирования
        /// </summary>
        private string GetTrueItem(List<string> usDir, string outMessage)
        {
            if (usDir.Count == 0) { throw new UserExceptions("Сначала выбери директорию", String.Empty); }
            Console.SetCursorPosition(usCommPos[0], usCommPos[1]);
            LineClear(usCommPos[0], usCommPos[1] - 1);
            Console.Write(outMessage);
            var usNumb = Console.ReadLine();
            string checkedDir;
            try
            {
                if (Convert.ToInt32(usNumb) > this.outputLines)
                {
                    checkedDir = usDir[Convert.ToInt32(usNumb) % this.outputLines];
                }
                else
                {
                    checkedDir = usDir[Convert.ToInt32(usNumb)];
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new UserExceptions($"Папки с номером {usNumb} - нет на выбранном листе", String.Empty);
            }
            return checkedDir;
        }
    }
}
