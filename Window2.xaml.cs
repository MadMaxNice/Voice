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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
     

        public Window2()
     {
           
            InitializeComponent();
           
            Class_Music_Player.Music.MediaEnded += Music_MediaEnded;
            for (int i = 0; i < Class_Function.Music_Directory.Length; i++)
                ShowText.Items.Add(Class_Function.Music_Directory[i]);

    
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
   void Music_MediaEnded(object sender, EventArgs e)
     {
         Class_Music_Player.music_next();
         ShowText.Items.Add("Включился следующий трек");
     }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
   private void Button_Play_Click(object sender, RoutedEventArgs e)
   {
       Class_Music_Player.music_play();
   }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
   private void Button_previous_Click(object sender, RoutedEventArgs e)
   {
       Class_Music_Player.music_previous();
   }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
   private void Button_Next_Click(object sender, RoutedEventArgs e)
   {
       Class_Music_Player.music_next();
   }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
   private void ShowText_SelectionChanged(object sender, SelectionChangedEventArgs e)
   {
       //for (int i = 0; i < Class_Function.Music_Directory.Length; i++)
       //{
           Class_Function.f_draw_text("Включился следующий трек");
           //ShowText.Items.Add(Class_Function.Music_Directory[i]);
    //   }
   }
    }
}

