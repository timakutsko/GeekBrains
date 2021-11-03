using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class WinInfo
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public WinInfo(int width = 170, int height = 10)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
