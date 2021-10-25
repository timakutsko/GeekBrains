using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class UserExceptions : Exception
    {
        public UserExceptions(string discr, string userInput) : base(String.Format("{0}{1}", discr, userInput)) 
        { 
            // Логирование ошибок в файл .txt
            File.AppendAllText("errors_exception.txt", $"{discr} {userInput}"); 
            File.AppendAllText("errors_exception.txt", $"\n"); 
        } 
    }
}
