using System.Data.Entity;
using HealthUnlocked.Models;

namespace HealthUnlocked.Infrastrucure
{
    public class HistoricWeatherContext : DbContext
    {
        public DbSet<HistoricWeather> HistoricWeather { get; set; } 
    }
}