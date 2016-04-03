using System.Net.Http;
using System.Threading.Tasks;

namespace HealthUnlocked.Infrastrucure
{
    public class WeatherApiClient : IWeatherApiClient
    {
        public async Task<string> GetRawWeatherData(string location, int numberOfDays)
        {
            using (var client = new HttpClient())
            {
                var url = $@"http://wxdata.weather.com/wxdata/weather/local/{location}?cc=*&unit=m&dayf={numberOfDays}";

                return await client.GetStringAsync(url);
            }
        }
    }
}