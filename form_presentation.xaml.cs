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
using System.IO;


namespace WpfApplication42
{
    /// <summary>
    /// Логика взаимодействия для form_presentation.xaml
    /// </summary>
    /// 
    
    public partial class form_presentation : Window
    {
        public bool test = false;
        //WpfApplication42.my_interface t = new WpfApplication42.my_interface();
        static public double screenHeight = SystemParameters.FullPrimaryScreenHeight;
        static public double screenWidth = SystemParameters.FullPrimaryScreenWidth;
        public string[] files1;
      
        public form_presentation()
        {
          
            InitializeComponent();
           
            this.Top = (screenHeight - this.Height+22) / 0x00000002;
            this.Left = (screenWidth - this.Width+650) / 0x00000002;

            files1 = Directory.GetFiles(@"E:\", "*.pptx");
            for (int num = 0; num < files1.Length; num++)
            {
                {
                    {
                        files1[num] = files1[num].Remove(0, 3);
                        files1[num] = files1[num].Replace(".pptx", "");
                        listBox.Items.Add(files1[num]);
                    }
                }
                
            }
            if (test == true) Hide();
        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
         
    }
}
