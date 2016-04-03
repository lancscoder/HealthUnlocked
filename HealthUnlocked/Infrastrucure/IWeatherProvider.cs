using System.Collections.Generic;
using System.Threading.Tasks;
using HealthUnlocked.Models;

namespace HealthUnlocked.Infrastrucure
{
    public interface IWeatherProvider
    {
        Task<List<Weather>> GetWeather(string location, int numberOfDays);
        Task<double> GetLast28DaysAverageHigh(string location);
        Task<double> GetLast28DaysAverageLow(string location);
    }
}
