using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OwinDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private RApp app;
        public ObservableCollection<string> Records { get; set; } = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            this.app = new RApp(this);
            this.app.Run();
            this.DataContext = this;
        }
        public void Dispaly(bool display)
        {
            Action action = () => {
                if (display)
                {
                    this.Visibility = Visibility.Visible;
                }
                else
                {
                    this.Visibility = Visibility.Hidden;
                }
            };
            this.Dispatcher.BeginInvoke(action);
        }
        public void AddRecord(string record)
        {
            Action action = () => {
                this.Records.Add(record);
            };
            this.Dispatcher.BeginInvoke(action);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
