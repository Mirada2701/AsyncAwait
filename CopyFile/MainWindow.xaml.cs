using Microsoft.Win32;
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

namespace CopyFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fromTb.Text = GetFilePath();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            toTb.Text = GetFolderPath();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string from = fromTb.Text;
            string to = toTb.Text;
            string copyPath = System.IO.Path.Combine(to,System.IO.Path.GetFileName(from));
            try
            {
                await CopyFileAsync(from, copyPath);
                MessageBox.Show("Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

                
        }
        string GetFilePath()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            return ofd.FileName;
        }
        string GetFolderPath()
        {
            OpenFolderDialog ofd = new OpenFolderDialog();
            ofd.ShowDialog();
            return ofd.FolderName;
        }
        async Task CopyFileAsync(string from,string to)
        {
            FileStream file = File.Open(from, FileMode.Open);
            FileStream file1 = File.Create(to);
            await file.CopyToAsync(file1);
            file.Close();
            file1.Close();
        }
    }
}