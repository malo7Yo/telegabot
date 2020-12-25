using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Net;

namespace bottelega.classes
{
    class weather
    {
        private const string key = "918463c58d81579f27743f12c53e7a36";
        public static string Show_Api(string city)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={key}";

            var request = (HttpWebRequest)WebRequest.Create(url);

            var httpresponse = (HttpWebResponse)request.GetResponse();
            string response;
            using (var reader = new StreamReader(httpresponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            var weathermore = JsonConvert.DeserializeObject<weathermore>(response);

            var weatherText = $"В {weathermore.Name} {weathermore.Main.Temp}°C\n" +
                $"Ощущается {weathermore.Main.FeelsLike}°C\n";
            return weatherText;
        }
    }
}
