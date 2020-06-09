using MvcCoreGiris.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Services
{
    public class WeatherComService : IWeatherService
    {
        public decimal Temperature(string cityName)
        {
            switch (cityName.ToLower())
            {
                case "ankara":
                    return 30;
                case "istanbul":
                    return 32;
                default:
                    return 25;
            }
        }
    }
}
