using System;
using System.IO;

namespace Dirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string fn_s = "dirPathes_simple.txt";
            string fn_r = "dirPathes_rec.txt";
            File.WriteAllText(fn_s, string.Empty);
            File.WriteAllText(fn_r, string.Empty);
            string path = Directory.GetCurrentDirectory();
            var dis = Directory.GetFileSystemEntries(path);
            Writer(fn_s, dis);
            RecDirs(path);
            

            string[] RecDirs(string currentDir)
            {
                if(currentDir == @"E:\GeekBrains\Lesson_5\Dirs")
                {
                    var DIR = Directory.GetDirectories(currentDir);
                    Writer(fn_r, DIR);
                    var filesDIR = Directory.GetFiles(currentDir);
                    Writer(fn_r, filesDIR);
                    var dirsDIR = Directory.GetDirectories(currentDir, string.Empty, SearchOption.AllDirectories);
                    foreach (string dir in dirsDIR)
                    {
                        var allDirs = Directory.GetDirectories(dir);
                        Writer(fn_r, allDirs);
                        var filesDir = Directory.GetFiles(dir);
                        Writer(fn_r, filesDir);
                    }
                    return Directory.GetDirectories(currentDir);
                }
                else
                {
                    return RecDirs(Directory.GetParent(currentDir).ToString());
                }

            }


            void Writer(string path, string[] data)
            {
               foreach (string curStr in data)
                {
                    File.AppendAllText(path, curStr);
                    File.AppendAllText(path, Environment.NewLine);
                }
            }
        }
    }
}
