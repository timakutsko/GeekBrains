using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class TODO
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public string UserView(bool isTrue)
        {
            if (isTrue)
            {
                return "X";
            }
            else 
            {
                return " "; 
            }
        }
    }
}
