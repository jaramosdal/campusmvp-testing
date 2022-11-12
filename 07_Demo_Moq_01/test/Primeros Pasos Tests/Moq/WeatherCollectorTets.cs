using Moq;
using Primeros_Pasos;
using System;
using System.Linq;
using Xunit;

namespace Primeros_Pasos_Tests.Moq
{
    public class WeatherCollectorTets
    {
        private readonly WeatherCollector _weatherCollector;
        public WeatherCollectorTets()
        {
            var database = new Mock<IDatabase>();
            database.Setup(db => db.RainAverageFor(It.IsAny<string>())).Returns(-1);
            database.Setup(db => db.RainAverageFor("Madrid")).Returns(11);
            database.Setup(db => db.RainAverageFor("Paris")).Returns(50);
            database.Setup(db => db.RainAverageFor("Noruega")).Returns(125);
            database.Setup(db => db.RainAverageFor(null)).Throws<NullReferenceException>();
            _weatherCollector = new WeatherCollector(database.Object);
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
