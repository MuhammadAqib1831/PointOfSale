using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace PointofSaleApplication.Sale
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

        private void Sales_Click(object sender, RoutedEventArgs e)
        {
            AddUserControl(new UCSaleOrder(this));
        }
        private void AddUserControl(UserControl uc)
        {
            uc.HorizontalAlignment = HorizontalAlignment.Stretch;
            uc.VerticalAlignment = VerticalAlignment.Stretch;
            MainContentGrid.Children.Add(uc);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ClockTime));
            thread.Start();
        }
        public void ClockTime()
        {
            while (true)
            {
                try
                {

                Thread.Sleep(1000);
                Application.Current.Dispatcher.Invoke( new Action(
                        () =>
                      {
                          lblClock.Content = DateTime.Now.ToString();
                      }));

                }
                catch (Exception)
                {

                    Console.WriteLine();
                }
            }
        }
    }
}
