using IIS.Models;
using System.Net;
using System.Xml.Serialization;

namespace IIS.Services
{
    public static class DhmzService
    {

        private static string url = "https://vrijeme.hr/hrvatska_n.xml";

        public static IList<Grad> GetWeatherData()
        {
            string apiUrl = url;
            WebClient client = new WebClient();
            string xmlResponse = client.DownloadString(apiUrl);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeatherData));
            WeatherData data = new WeatherData();
            using (StringReader reader = new StringReader(xmlResponse))
            {
                data = (WeatherData)xmlSerializer.Deserialize(reader);

            }
            return data.Gradovi.ToList();
        }
    }
}
