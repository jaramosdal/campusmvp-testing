using Primeros_Pasos;
using System;
using System.Linq;
using Xunit;

namespace Primeros_Pasos_Tests.MicrosoftFakes
{
    public class WeatherCollectorTets
    {
        private readonly WeatherCollector _weatherCollector;
        public WeatherCollectorTets()
        {
            var database = new Primeros_Pasos.Fakes.StubIDatabase()
            {
                RainAverageForString = (city) =>
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
            };
            _weatherCollector = new WeatherCollector(database);
        }

        [Theory]
        [InlineData(11, "Madrid")]
        [InlineData(50, "Paris")]
        [InlineData(125, "Noruega")]
        [InlineData(-1, "Unknown")]
        public void GetRainForCities_ShouldBeExpectedValue(int expected, string city)
        {
            //Arrange
            var cities = new string[] { city };

            //Act
            var result = _weatherCollector.GetRainForCities(cities).ToArray();

            //Assert
            Assert.Equal(expected, result[0]);
        }

        [Fact]
        public void GetRainForCities_ShouldThrowNullReferenceException_IfAnyCityIsNull()
        {
            //Arrange
            var cities = new string[] { "Madrid", null };

            //Act
            Action act = () =>
            {
                _ = _weatherCollector.GetRainForCities(cities).ToArray();
            };

            //Assert
            Assert.Throws<NullReferenceException>(act);
        }

        [Fact]
        public void GetRainForCities_ShouldBe11And50_IfCitiesAreMadridAndParis()
        {
            //Arrange
            var cities = new string[] { "Madrid", "Paris" };

            //Act
            var result = _weatherCollector.GetRainForCities(cities).ToArray();

            //Assert
            Assert.Equal(11, result[0]);
            Assert.Equal(50, result[1]);
        }
    }
}
