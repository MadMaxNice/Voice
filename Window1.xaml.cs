using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApplication42
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class_Function.open_door();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Class_Function.close_door();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Class_Function.clock();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Class_Function.light_on();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Class_Function.light_off();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Class_Function.weather();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Class_Function.open_window();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Class_Function.close_window();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            //Window1 sw = new Window1();
            //sw.Close();
            Close();
        }
    }
}
