using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthUnlocked.Models
{
    public class Weather
    {
        public string Day { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
        public string Description { get; set; }
    }
}