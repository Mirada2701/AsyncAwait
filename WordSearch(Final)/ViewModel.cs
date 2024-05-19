using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch_Final_
{
    public class ViewModel
    {
        public string Source { get; set; }
        public string FindWord { get; set; }
        public int Percentage { get; set; }
        private ObservableCollection<InfoFile> files;
        public ViewModel()
        {
            files = new ObservableCollection<InfoFile>();
        }
        public IEnumerable<InfoFile> Files => files;
        public void AddFile(InfoFile f)
        {
            files.Add(f);
        }

    }
}
