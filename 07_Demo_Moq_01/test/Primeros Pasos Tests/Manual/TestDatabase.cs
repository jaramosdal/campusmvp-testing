using Primeros_Pasos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primeros_Pasos_Tests.Manual
{
    public class TestDatabase : IDatabase
    {
        public int RainAverageFor(string city)
        {
            switch (city.ToLower())
            {
                case "madrid":
                    return 11;
                case "paris":
                    return 50;
                case "noruega":
                    return 125;
                default:
                    return -1;
            }
        }
    }
}
