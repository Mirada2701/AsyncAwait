using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch_Final_
{
    public class InfoFile
    {
        public string FileName { get; set; }
        public string PathToFile { get; set; }
        public int Amount_Find_Word { get; set; }
        public InfoFile(string path)
        {
            PathToFile = path;
        }
    }
}
