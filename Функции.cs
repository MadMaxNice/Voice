using System;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Net;
using System.IO.Ports;
public class Class_Function
{
    static Class_Screen obj_screen = new Class_Screen();
    static Class_Presentation obj_presentation = new Class_Presentation();
    static Class_Weather obj_weather = new Class_Weather();
   public static WpfApplication42.form_presentation obj_list_presentation = new WpfApplication42.form_presentation();
   
    public static bool TV = true;
    private static bool start = false;
    public static bool light = false;
    public static bool door = false;
    public static bool window = false;
    public static bool presentation = false;
    static public bool music_play = false;
    public static int count = 1, max_slide = 99;
   
    public static string[] files1 = Directory.GetFiles(@"E:\", "*.pptx");
    static public string[] Music_Directory = Directory.GetFiles(@"E:\HouseCommander\Music\", "*.mp3");
    public string directory_path =  @"E:\" ; //E:\\HouseCommander\\Presentation\\
    public static string[] fileTemp;
    public static string idmyfile = "пусто";
    private static SpeechSynthesizer sound = new SpeechSynthesizer();
    public static string txt = "";
    
 
    static public void f_draw_text(object text)
    {
       txt = (string)text;
       // txt = text;
    }
    public static void f_sound_play(object text)
    {
        sound.Speak((string)text);
    }
    public static void command(string text)
    {
        Thread thread_sound = new Thread(new ParameterizedThreadStart(f_sound_play));
        Thread thread_text = new Thread(new ParameterizedThreadStart(f_draw_text));
        txt = text;
        
        thread_sound.Start(text);
        thread_text.Start(text);
    }

    public static void connect()
    {
        try
        {
            Connect_to_gadget.SendMessageFromSocket(11000);
        }
        catch (Exception ex)
        {
            obj_list_presentation.listBox.Items.Add(ex.ToString());
            Console.WriteLine(ex.ToString());
        }
        finally
        {
           obj_list_presentation.listBox.Items.Add("");
            Console.ReadLine();
        }
    }


    public static void light_on()
        {
            if (light == false)
            {
                light = true;

           
            command("Свет включен");
            }
            else
            command("Свет уже включен");
        }
    public static void light_off()
        {
            if (light == true)
            {
                light = false;
           connect();//Подключаемся к свету;
            //Connect_to_gadget.message = "access_is_allowed_to_turn_off_the_light";//Console.ReadLine();
         //   command("Свет выключен");
           // Connect_to_gadget.
            }
            else
            command("Свет уже выключен!");
        }

    public static void open_door()
    {
        if (door == false)
        {
            door = true;
            command("Дверь открыта");
        }
        else
            command("Дверь уже открыта!");
    }

    public static void close_door()
    {
        if (door == true)
        {
            door = false;
            command("Дверь закрыта");
            //DetectorMovimento.Main.check = false;
        }
        else
            command("Дверь уже закрыта!");
    }
    public static void open_window()
    {
        if (window == false)
        {
            window = true; command("Окно открыто");
        }
        else
            command("Окно уже открыто!");
    }
    public static void close_window()
    {
        if (window == true)
        {
            window = false;
            command("Окно закрыто");
        }
        else
            command("Окно уже закрыто!");
    }
    public static void on_TV()
    {
        if (TV == false)
        { obj_screen.MonitorOn();
            TV = true;
            command("Экран включен"); }
        else
            command("Экран уже включен!");
    }
    public static void off_TV()
    {
        if (presentation == false)
        {
        if (TV == true)
            {
                TV = false;
                obj_screen.MonitorOff();
                command("Экран выключен"); }
        else
                command("Экран уже выключен!");
        }
        else
            command("Невозможно т.к. включена презентация");

    }
    public static void open_presentation()
    {
        if (TV == true)
        {
            if (start == true)
                if (presentation == false)
                {
                    command("Открываю");
                    Class_Presentation.init();
                    obj_list_presentation.Hide();///////////////////////////////////////Здесь был баг

                    presentation = true; 
                }
        }
        else
            command("Невозможно т.к. не включен экран");
    }
    public static void name_presentation()
    {
        if (presentation == false)
        {
            start = true;
            command("Выберите презентацию для открытия");
            Class_Function.search_presentation();
            obj_list_presentation.Show();
        }
        else
            command("Презентация уже открыта");
    }
    public static void search_presentation()
    {
        files1 = Directory.GetFiles(@"E:\", "*.pptx");
        for (int num = 0; num < files1.Length; num++)
        {
            {
                {
                    files1[num] = files1[num].Remove(0, 3);
                    files1[num] = files1[num].Replace(".pptx", "");
                }
            }
           // f_draw_text(files1[num]);
        }
   
    }
    public static void close_presentation()
    {
        if (presentation == true)
        {
            presentation = false;
            start = false;
            obj_presentation.exit();
            command("Закрываю");
        }
        else
        {
            command("Презентация уже закрыта");
        }

    }
    public static void slide_next()
    {
        if (presentation == true)
        {
            //Class_Function.max_slide = Class_Presentation.pPre.Slides.Count;
            if (count != max_slide)
            {
                obj_presentation.next();
                count++;
            }
            else
            {
                command("Это конец презентации");
            }
    }
            else
                {
                    command("Презентация не открыта");
                }
    }
    public static void slide_previous()
    {
        if (presentation == true)
            if (count != 1)
                {
                obj_presentation.previous();
                count--;
                }
                    else
                    {
                command("Это начало презентации");
                    }
                else
                    {
                    command("Презентация не открыта");
                    }
    }
    public static void weather()
    {
        command("Загружаю погоду");
        obj_weather.parser_weather("minsk");
    }
    public static void clock()
    {
        command("Текущее время " + DateTime.Now.Hour + " " + DateTime.Now.Minute);
    }
    public static string social(string text, string site, string address)
    {
        Process.Start(site, address);
        command(text);
        return site;
    }
    public static void chaynik_on()
    {

        command("Чайник включен");
      //  WebRequest req = HttpWebRequest.Create("http://relaxcs.by/andrewkharkov/ss/index.php?st=tr");

        //Stream s = req.GetResponse().GetResponseStream();

        //StreamReader sr = new StreamReader(s);

//        string state = sr.ReadToEnd();

        //sr.Close();

        SerialPort port = new SerialPort("COM5", 9600);
        port.Open();
            String s = Console.ReadLine();
            s = "Q";
            port.Write(s + '\n');
            port.Close();


    }
    public static void chaynik_off()
    {
        command("Чайник выключен");
     /*   WebRequest req = HttpWebRequest.Create("http://relaxcs.by/andrewkharkov/ss/index.php?st=fa");

        Stream s = req.GetResponse().GetResponseStream();

        StreamReader sr = new StreamReader(s);

        string state = sr.ReadToEnd();

        sr.Close();
      * */
        SerialPort port = new SerialPort("COM5", 9600);
        port.Open();
        String s = Console.ReadLine();
        s = "q";
        port.Write(s + '\n');
        port.Close();
    
    }


}




