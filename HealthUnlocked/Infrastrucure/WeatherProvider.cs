using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthUnlocked.Models;

namespace HealthUnlocked.Infrastrucure
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly IWeatherApiClient _client;
        private readonly IWeatherDataParser _weatherDataParser;
        private readonly IHistoricWeatherRepository _historicWeatherRepository;

        public WeatherProvider(
            IWeatherApiClient client, 
            IWeatherDataParser weatherDataParser,
            IHistoricWeatherRepository historicWeatherRepository)
        {
            _client = client;
            _weatherDataParser = weatherDataParser;
            _historicWeatherRepository = historicWeatherRepository;
        }

        public async Task<List<Weather>> GetWeather(string location, int numberOfDays)
        {
            var rawData = await _client.GetRawWeatherData(location, numberOfDays);

            var weatherData = _weatherDataParser.ParseRawData(rawData);

            return weatherData;
        }

        public async Task<double> GetLast28DaysAverageHigh(string location)
        {
            var data = await GetLast28Days(location);

            return Math.Round(data.Average(d => d.High), 0);
        }

        public async Task<double> GetLast28DaysAverageLow(string location)
        {
            var data = await GetLast28Days(location);

            return Math.Round(data.Average(d => d.Low), 0);
        }

        private async Task<List<HistoricWeather>> GetLast28Days(string location)
        {

            var fromDate = DateTime.Today.Subtract(new TimeSpan(28, 0, 0, 0));
            var toDate = DateTime.Today;

            var data = await _historicWeatherRepository.GetHistoricWeatherForDateRangeAndLcoation(fromDate, toDate, location);

            return data;
        }
    }
}