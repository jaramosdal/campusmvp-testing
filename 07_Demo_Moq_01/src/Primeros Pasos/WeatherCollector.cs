using System;
using System.Collections.Generic;
using System.Text;

namespace Primeros_Pasos
{
    public class WeatherCollector
    {
        private readonly IDatabase _database;

        public WeatherCollector(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<int> GetRainForCities(string[] cities)
        {
            foreach(var city in cities)
            {
                yield return _database.RainAverageFor(city);                
            }
        }
    }
}
