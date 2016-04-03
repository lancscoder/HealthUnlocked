using System;
using System.Collections.Generic;
using System.Xml;
using HealthUnlocked.Models;

namespace HealthUnlocked.Infrastrucure
{
    public class WeatherDataParser : IWeatherDataParser
    {
        public List<Weather> ParseRawData(string data)
        {
            var weathers = new List<Weather>();
            var xml = new XmlDocument();
            xml.LoadXml(data);

            var nodes = xml.SelectNodes("weather/dayf/day");

            if (nodes == null) return weathers;

            foreach (XmlNode node in nodes)
            {
                var day = node.Attributes?["t"]?.Value;
                var high = Convert.ToInt32(node.SelectNodes("hi")?[0]?.InnerText);
                var low = Convert.ToInt32(node.SelectNodes("low")?[0]?.InnerText);
                var description = node.SelectNodes("part/t")?[0]?.InnerText;

                weathers.Add(new Weather
                {
                    Day = day == DateTime.UtcNow.DayOfWeek.ToString() ? "Today" : day,
                    High = high,
                    Low = low,
                    Description = description
                });
            }

            return weathers;
        }
    }
}