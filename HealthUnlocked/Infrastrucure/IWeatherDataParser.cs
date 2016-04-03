using System.Collections.Generic;
using HealthUnlocked.Models;

namespace HealthUnlocked.Infrastrucure
{
    public interface IWeatherDataParser
    {
        List<Weather> ParseRawData(string data);
    }
}