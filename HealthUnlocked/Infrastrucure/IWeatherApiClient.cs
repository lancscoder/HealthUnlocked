using System.Threading.Tasks;

namespace HealthUnlocked.Infrastrucure
{
    public interface IWeatherApiClient
    {
        Task<string> GetRawWeatherData(string location, int numberOfDays);
    }
}