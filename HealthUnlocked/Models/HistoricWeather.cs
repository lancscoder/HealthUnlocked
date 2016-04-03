using System;
using System.ComponentModel.DataAnnotations;

namespace HealthUnlocked.Models
{
    public class HistoricWeather
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
    }
}