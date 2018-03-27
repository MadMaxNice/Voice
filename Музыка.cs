using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media;


public class Class_Music_Player
{
    static private int number_track = 0;
    private float level_volume = 0.1f;
    static public MediaPlayer Music = new MediaPlayer();

    static public void music_volume_up()
    {
        Music.Volume += 0.1;
        Class_Function.f_draw_text("Громкость увеличена на 10%");
    }
    static public void music_volume_down()
    {
        Music.Volume -= 0.4;
        Class_Function.f_draw_text("Громкость уменьшена на 40%");
    }
    static public void music_play()
    {
        if (Class_Function.music_play == false)
        {
            Music.Open(new Uri(Class_Function.Music_Directory[number_track], UriKind.Relative));
            Music.Play();
            Class_Function.music_play = true;
            Class_Function.f_draw_text("Музыка включена");
        }
        else
            Class_Function.f_draw_text("Музыка уже включена");
    }

    static public void music_stop()
    {
        if (Class_Function.music_play == true)
        {

            Music.Stop();
            Class_Function.music_play = false;
            Class_Function.f_draw_text("Музыка выключена");
        }
        else
            Class_Function.command("Музыка уже выключена");
    }

    static public void music_next()
    {
        if (Class_Function.music_play == true)
        {
            number_track += 1;
            if (number_track > Class_Function.Music_Directory.Length - 1) number_track = 0;
            Music.Open(new Uri(Class_Function.Music_Directory[number_track], UriKind.Relative));
            Music.Play();
            Class_Function.f_draw_text("Следующий трек");
        }
        else
            Class_Function.command("Музыка не была включена");
    }
    static public void music_previous()
    {
        if (Class_Function.music_play == true)
        {
            if (number_track == 0)
                number_track = Class_Function.Music_Directory.Length;
            if (number_track > 0)
                number_track -= 1;
            Music.Open(new Uri(Class_Function.Music_Directory[number_track], UriKind.Relative));
            Music.Play();
            Class_Function.f_draw_text("Предыдущий трек");
        }
        else
            Class_Function.command("Музыка не была включена");
    }
}

