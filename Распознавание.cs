using System;
using Microsoft.Speech.Recognition;
using System.Collections.Generic;
using System.IO;
public class MyClass
{
    private GrammarBuilder gb = new GrammarBuilder();
    public MyClass()
    {
        var rr = SpeechRecognitionEngine.InstalledRecognizers();
        var input = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("ru-RU"));
        input.SetInputToDefaultAudioDevice();
        gb.Append(new Choices(new string[] { "включи", "выключи", "открой", "закрой", "который", "следующий", "предыдущий", "не", "кто", "погода","тестовая","оригинальная","конечная" }));
        gb.Append(new Choices(new string[] { "свет", "окно", "дверь", "экран", "час", "вконтакте", "ютуб", "гугл", "презентацию", "слайд", "ври", "молодец", "сейчас","первая","вторая","третья" }));
        Grammar g = new Grammar(gb);
        input.LoadGrammar(g);
        //input.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(Sre_SpeechDetected);
        input.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(Sre_RecognizeCompleted);
        input.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(sr_SpeechHypothesized);
        input.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(sr_SpeechRecognitionRejected);
        input.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Sre_SpeechRecognized);
        input.RecognizeAsync(RecognizeMode.Multiple);
    }
    private void sr_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
    {
        Console.WriteLine("Произнесено слово или фраза, не имеющееся в базе");
    }
    private void sr_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
    {
        Console.WriteLine("Подождите...");
    }
    private void Sre_SpeechDetected(object sender, SpeechDetectedEventArgs e)
    {
        Console.WriteLine("Была произнесена команда");
    }
    private void Sre_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
    {
        Console.WriteLine("Микрофон был потерян");
        float confidence = e.Result.Confidence;
        Console.WriteLine("Упс.. Что-то с микрофоном: ");
        if (confidence < 0.60) return;
    }
    public void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        Console.Clear(); 
        string i = e.Result.Text;
        string ii = e.Result.Text;
        Dictionary<string, FunctionHandler> dic = Class_Dictionary.MyDic(e.Result.Text);
        if (dic.ContainsKey(i))
            dic[i]();

        for (int num = 0; num < Class_Function.files1.Length; num++)
        {
            if (e.Result.Text == Class_Function.files1[num])
            {
                Class_Function.idmyfile = Class_Function.files1[num];
                Class_Function.open_presentation();
            }
        }


    }
}