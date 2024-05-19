using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordSearch_Final_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = new ViewModel()
            {
                Source = "E:\\ШАГ\\3 семестр\\WF\\Text",
                FindWord = "friend",
                Percentage = 0
            };
            this.DataContext = model;
        }

        private void Open_Source_Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                model.Source = dialog.FileName;
            }
        }

        private async void Find_Button_Click(object sender, RoutedEventArgs e)
        {
            string[] files = Directory.GetFiles(model.Source,"*.txt",SearchOption.AllDirectories);
            
            foreach (string file in files)
            {                
                InfoFile info = new InfoFile(file);
                model.AddFile(info);
                await GetInfoFileAsync(file, model.FindWord, info);
            }
        }
        private Task GetInfoFileAsync(string path,string find_word,InfoFile info)
        {
            return Task.Run(
                () =>
                {
                    info.FileName = System.IO.Path.GetFileName(path);
                    int amount = 0;
                    string text = File.ReadAllText(info.PathToFile);
                    string[] words = text.Split(new char[] { ' ', '.', '!', '?' });
                    foreach (string word in words)
                    {
                        if(word == find_word)
                            amount++;
                    }
                    info.Amount_Find_Word = amount;
                });
        }
    }
}