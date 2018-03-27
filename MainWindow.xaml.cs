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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Speech.Recognition;
using System.Globalization;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NUnit.Framework;
namespace WpfApplication42
{
    [TestFixture]
    class test_class
    {
        [Test]
        private void test_1()
        {
            //string result="";
            Class_Weather obj = new Class_Weather();
            obj.parser_weather("minsk");
            obj.town = "";
            Assert.AreEqual("Минск", obj.town);
        }



    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
   partial class my_interface
    {
        string i;
        static CultureInfo ci = new CultureInfo("ru-RU");
        static SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
        public static string[] files1 = Directory.GetFiles(@"E:\", "*.pptx");
     
        public my_interface()
        {
            InitializeComponent();
            
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += sre_SpeechRecognized;
            Grammar g_HelloGoodbye = GetHelloGoodbyeGrammar();
            sre.LoadGrammarAsync(g_HelloGoodbye);
            sre.RecognizeAsync(RecognizeMode.Multiple);
            sre.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(sr_SpeechRecognitionRejected);

            Class_Music_Player.Music.MediaEnded += Music_MediaEnded;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void sr_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Class_Function.f_draw_text("Произнесено слово или фраза, не имеющееся в базе");
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        void Music_MediaEnded(object sender, EventArgs e)
        {
            Class_Music_Player.music_next();
            listBox.Items.Add(DateTime.Now.Hour + " " + DateTime.Now.Minute+" "+"Включился следующий трек");
        }
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        static Grammar GetHelloGoodbyeGrammar()
            {
                Choices base_data = new Choices();
                base_data.Add("включи свет");
                base_data.Add("выключи свет");
                base_data.Add("включи экран");
                base_data.Add("выключи экран");
                base_data.Add("открой дверь");
                base_data.Add("закрой дверь");
                base_data.Add("закрой дверь");
                base_data.Add("открой окно");
                base_data.Add("закрой окно");
                base_data.Add("который час");
                base_data.Add("погода сейчас");
                base_data.Add("открой презентацию");
                base_data.Add("закрой презентацию");
                base_data.Add("следующий слайд");
                base_data.Add("предыдущий слайд");
                base_data.Add("включи музыку");
                base_data.Add("выключи музыку");
                base_data.Add("следующий трек");
                base_data.Add("предыдущий трек");
                base_data.Add("прибавь громкость");
                base_data.Add("убавь громкость");

                base_data.Add("подогрей воду");
                base_data.Add("отмени подогрев");
            files1 = Directory.GetFiles(@"E:\", "*.pptx");
                for (int num = 0; num < files1.Length; num++)
                {
                    {
                        {

                            files1[num] = files1[num].Remove(0, 3);
                            files1[num] = files1[num].Replace(".pptx", "");
                        }
                    }
                    base_data.Add(files1[num]);
                }
         
                GrammarBuilder gb_result = new GrammarBuilder(base_data);
                Grammar g_result = new Grammar(gb_result);
                return g_result;
            }

        
     
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            i = e.Result.Text;
            //DetectorMovimento.Main.check = false;
            Dictionary<string, FunctionHandler> dic = Class_Dictionary.MyDic(e.Result.Text);

            if (dic.ContainsKey(i))
            {
                dic[i]();
                listBox.Items.Add(DateTime.Now.Hour + ":" + DateTime.Now.Minute+" "+Class_Function.txt);
            }

            for (int num = 0; num < Class_Function.files1.Length; num++)
            {
                if (e.Result.Text == Class_Function.files1[num])
                {
                    Class_Function.idmyfile = Class_Function.files1[num];
                    Class_Function.open_presentation();
                }
            }
            float conf = e.Result.Confidence;
            if (conf < 0.65) return;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void ListBox_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange > 0.0)
                ((ScrollViewer)e.OriginalSource).ScrollToEnd();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void checkBox_Checked(object sender, RoutedEventArgs e)
            {

            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           // textBox.Text = Class_Function.txt;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
      private void button_Click(object sender, RoutedEventArgs e)
        {
            Class_Function.obj_list_presentation.Close();
            Close();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
           // form_presentation obj_list_presentation = new form_presentation();
           // obj_list_presentation.Show();
           // DetectorMovimento.Main wss = new DetectorMovimento.Main();
           //wss.Show();
            
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 ws = new Window1();
            ws.Show();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window2 object_musicform = new Window2();
            object_musicform.Show();
        }
    }
 
}


