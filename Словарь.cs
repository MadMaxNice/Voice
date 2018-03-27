using System;
using System.Collections.Generic;
using System.IO;
public delegate void FunctionHandler();
public class Class_Dictionary
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    static public Dictionary<string, FunctionHandler> MyDic(string i)
    {
        
        Dictionary<string, FunctionHandler> phrases = new Dictionary<string, FunctionHandler>();//Словарь
        phrases.Add("включи свет", Class_Function.light_on);
        phrases.Add("выключи свет", Class_Function.light_off);
        phrases.Add("открой дверь", Class_Function.open_door);
        phrases.Add("закрой дверь", Class_Function.close_door);
        phrases.Add("открой окно", Class_Function.open_window);
        phrases.Add("закрой окно", Class_Function.close_window);
        phrases.Add("включи экран", Class_Function.on_TV);
        phrases.Add("выключи экран", Class_Function.off_TV);
        phrases.Add("открой презентацию", Class_Function.name_presentation);
        phrases.Add("закрой презентацию", Class_Function.close_presentation);
        phrases.Add("следующий слайд", Class_Function.slide_next);
        phrases.Add("предыдущий слайд", Class_Function.slide_previous);
        phrases.Add("погода сейчас", Class_Function.weather);
        phrases.Add("который час", Class_Function.clock);
        phrases.Add("включи музыку", Class_Music_Player.music_play);
        phrases.Add("выключи музыку", Class_Music_Player.music_stop);
        phrases.Add("следующий трек", Class_Music_Player.music_next);
        phrases.Add("предыдущий трек", Class_Music_Player.music_previous);
        phrases.Add("прибавь громкость", Class_Music_Player.music_volume_up);
        phrases.Add("убавь громкость", Class_Music_Player.music_volume_down);
        phrases.Add("подогрей воду", Class_Function.chaynik_on);
        phrases.Add("отмени подогрев", Class_Function.chaynik_off);
        return phrases;
    }
}






/*
"не ври": 
"открой вконтакте":
social("Открываю вконтакте", "chrome.exe", "www.vk.com");
"открой ютуб":
social("Открываю youtube", "chrome.exe", "www.youtube.com");
"открой гугл":
*/
