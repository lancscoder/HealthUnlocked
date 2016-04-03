using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HealthUnlocked.Models;

namespace HealthUnlocked.Infrastrucure
{
    public class HistoricWeatherRepository : IHistoricWeatherRepository
    {
        public async Task<List<HistoricWeather>> GetHistoricWeatherForDateRangeAndLcoation(DateTime fromDate, DateTime toDate, string location)
        {
            using (var context = new HistoricWeatherContext())
            {
                return await
                    context.HistoricWeather.Where(
                        h =>
                            h.Date >= fromDate && h.Date < toDate &&
                            h.Location.Equals(location, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
            }
        }
    }
}