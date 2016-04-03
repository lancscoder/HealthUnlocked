using System.Threading.Tasks;
using System.Web.Http;
using HealthUnlocked.Infrastrucure;

namespace HealthUnlocked.Controllers
{
    [RoutePrefix("api/weather")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherProvider _weatherProvider;

        public WeatherController(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
        }
        
        [Route("forecast/london")]
        public async Task<IHttpActionResult> GetLondonForecast()
        {
            var forecast = _weatherProvider.GetWeather("UKXX0085", 4);
            var highAverage = _weatherProvider.GetLast28DaysAverageHigh("UKXX0085");
            var lowAverage = _weatherProvider.GetLast28DaysAverageLow("UKXX0085");

            await Task.WhenAll(forecast, highAverage, lowAverage);

            return Ok(new 
            {
                forecast = forecast.Result,
                highAverage = highAverage.Result,
                lowAverage = lowAverage.Result
            });
        }
    }
}
