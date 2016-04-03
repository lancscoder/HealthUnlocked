using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthUnlocked.Models;

namespace HealthUnlocked.Infrastrucure
{
    public interface IHistoricWeatherRepository
    {
        Task<List<HistoricWeather>> GetHistoricWeatherForDateRangeAndLcoation(DateTime fromDate, DateTime toDate,
            string location);
    }
}