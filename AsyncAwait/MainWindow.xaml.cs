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

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //int value = GenerateValue();
            //Task<int> task = Task.Run(GenerateValue);

            //list.Items.Add(task.Result);

            //async - alow method to use await keywords
            //await - wait task without freezing

            //await task;//without freezing
            //MessageBox.Show("Completed!!!");
            //int value = await Task.Run(GenerateValue); 
            //list.Items.Add(await Task.Run(GenerateValue));
            list.Items.Add(await GenerateValueAsync());

            //FileStream fileStream = new FileStream());
            //await fileStream.CopyToAsync();
        }
        int GenerateValue() 
        {
            Thread.Sleep(rnd.Next(10000));
            //MessageBox.Show("Generated");
            return rnd.Next(1000); 
        }
        Task<int> GenerateValueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(rnd.Next(10000));
                //MessageBox.Show("Generated");
                return rnd.Next(1000);
            });
            
        }
    }
}