using System;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Threading.Tasks;
class Class_Weather
{
    public string town, temp, humidity, precipitation, temp_result, temp_town;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="city"></param>
    public void parser_weather(string city)
    {
        try
        {
            WebRequest request;
            request = WebRequest.Create(@"http://www.meteoservice.ru/weather/now/" + city + ".html");
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string data = reader.ReadToEnd();
                    town = new Regex(@"<h1>(?<town>.*)</h1>").Match(data).Groups["town"].Value;
                    temp = new Regex(@"<span class=""temperature"">(?<temp>[^<]+)</span>").Match(data).Groups["temp"].Value;
                    humidity = new Regex(@"<td class=""title"">Относительная влажность:</td>[^<]*?<td>(?<humidity>[^<]+)</td>").Match(data).Groups["humidity"].Value;
                    precipitation = new Regex(@"<td class=""title"">Облачность:</td>[^<]*?<td>(?<osadki>[^<]+)</td>").Match(data).Groups["osadki"].Value;

                }
            }
            temp_result = temp.Replace("&deg;C", "");
            temp_town = town.Replace("Текущая погода (сейчас) в", "");
            Class_Function.command("В" + temp_town + " " + precipitation + ", температура воздуха " + temp_result + " градусов, относительная влажность воздуха " + humidity);
        }
        catch (System.Net.WebException)
        {
            Class_Function.command("Отсутствует интернет соединение");
            return;
        }
    }

}