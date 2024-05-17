using Microsoft.Win32;
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

namespace FileCopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            srcTextBox.Text = Source = "E:\\ШАГ\\3 семестр\\WF\\Text\\Friend.txt";
            destTextBox.Text = Destination = "E:\\ШАГ\\3 семестр\\WF\\Text\\Directory\\Loshara";

        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            //copy file from source to destination
            string filename = System.IO.Path.GetFileName(srcTextBox.Text);
            
            string destFilePath = System.IO.Path.Combine(Destination, filename);
            File.Copy(Source, destFilePath, true);
            MessageBox.Show("Complete!");

        }

        private void Open_Source_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
               Source =  dialog.FileName;
               srcTextBox.Text = Source;
            }
        }

        private void Open_Dest_Button_Click_(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Destination = dialog.FileName;
                destTextBox.Text = Destination;
            }
            
        }
    }
}