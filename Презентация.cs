using System;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.Diagnostics;
using System.IO;

public class Class_Presentation
{
     Class_Function obj_Function = new Class_Function();
    Process MyProc = new Process();
    static public string presExisting = @"E:\SlidesCollection.pptx";
    static public PowerPoint._Application pApp;
    public static PowerPoint.Presentation pPre;

    public static void init()
    {
        try
        {
            if (Class_Function.presentation == false)
            {
                pApp = new PowerPoint.Application();
                pPre = pApp.Presentations.Open(@"E:\" + Class_Function.idmyfile + ".pptx", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);
                pPre.SlideShowSettings.Run();
            }
        }
        catch (System.IO.FileNotFoundException)
        {
        Class_Function.command("Не был найден файл для открытия. Проверьте путь к файлу");
         return;
        }
    }
    public void next()
    {
       // Class_Function.max_slide = pPre.Slides.Count;//
        pPre.SlideShowWindow.View.Next(); 

    }
    public void previous()
    {
     pPre.SlideShowWindow.View.Previous();
    }
    public void exit()
    {
        try
        {
            pPre.SlideShowWindow.View.Exit();
            pPre.Close();
            var processes = Process.GetProcessesByName("POWERPNT");
            foreach (var p in processes)
            {
                p.Kill();
            }
        }
        catch (System.Runtime.InteropServices.COMException)
        {
            Class_Function.command("Была закрыта презентация вручную");
            return;
        }
    }
}
