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
namespace WpfApplication42
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
 

    public partial class MainWindow
    {
        string[] number_array =
           {
                "первого ",
                "второго ",
                "третьего ",
                "четвертого ",
                "пятого ",
                "шестого ",
                "седьмого ",
                "восьмого ",
                "девятого ",
                "десятого ",
                "одиннадцатого ",
                "двенадцатого ",
                "тринадцатого ",
                "четырнадцатого ",
                "пятнадцатого",
                "шестнадцатого",
                "семнадцатого",
                "восемнадцатого",
                "девятнадцатого",
                "двадцатого",
                "двадцать первого",
                "двадцать второго",
                "двадцать третьего",
                "двадцать четвертого",
                "двадцать пятого",
                "двадцать шестого",
                "двадцать седьмого",
                "двадцать восьмого",
                "двадцать девятого",
                "тридцатого",
                "тридцать первого"
                };
        string[] month_array =
            {
                "января",
                "февраля",
                "марта",
                "апреля",
                "мая",
                "июня",
                "июля",
                "августа",
                "сентября",
                "октября",
                "ноября",
                "декабря"
                };
        string i;
        static CultureInfo ci = new CultureInfo("ru-RU");
        static SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
        public static string[] files1 = Directory.GetFiles(@"E:\", "*.pptx");
        public MainWindow()
        {
           
            InitializeComponent();
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += sre_SpeechRecognized;
            Grammar g_HelloGoodbye = GetHelloGoodbyeGrammar();
            sre.LoadGrammarAsync(g_HelloGoodbye);
            sre.RecognizeAsync(RecognizeMode.Multiple);

        }
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
            //Добавление списков презентаций в БД
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
            //
            //Добавление списка дней в словарь
            for (int i = 0; i < number_array.Length; i++)
            {
                for (int j = 0; j < month_array.Length; j++)
                {

                    base_data.Add("планы на " + number_array[i] + month_array[j]);

                }
            }

            GrammarBuilder gb_result = new GrammarBuilder(base_data);
            Grammar g_result = new Grammar(gb_result);
            return g_result;
        }
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            i = e.Result.Text;
            
            Dictionary<string, FunctionHandler> dic = Class_Dictionary.MyDic(e.Result.Text);

            if (dic.ContainsKey(i))
            {
                
                dic[i]();
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
        private void button_Click(object sender, RoutedEventArgs e)
        {
            label.Content = Class_Function.txt; 
            //  label.Content = Class_Function.txt;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        public void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox.Text = Class_Function.txt;
        }
    }
 
}


