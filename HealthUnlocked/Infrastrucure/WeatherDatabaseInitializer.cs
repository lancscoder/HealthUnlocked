using System;
using System.Data.Entity;
using HealthUnlocked.Models;

namespace HealthUnlocked.Infrastrucure
{
    public class WeatherDatabaseInitializer : DropCreateDatabaseAlways<HistoricWeatherContext>
    {
        protected override void Seed(HistoricWeatherContext context)
        {
            var highRandom = new Random(DateTime.UtcNow.Millisecond);
            var lowRandom = new Random(DateTime.UtcNow.Millisecond);

            for (var i = 1; i <= 28; i++)
            {
                context.HistoricWeather.Add(new HistoricWeather
                {
                    Date = DateTime.UtcNow.AddDays(-i).Date,
                    High = highRandom.Next(15, 25),
                    Low = lowRandom.Next(5, 15),
                    Location = "UKXX0085"
                });

            }

            context.SaveChanges();
        }
    }
}