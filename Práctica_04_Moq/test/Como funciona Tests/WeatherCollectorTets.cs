using Como_funciona;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Como_funciona_Tets
{
    public class WeatherCollectorTets
    {
        private readonly WeatherCollector _weatherCollector;
        public WeatherCollectorTets()
        {
            var databaseMock = new Mock<IDatabase>(MockBehavior.Strict);
            databaseMock.Setup(db => db.RainAverageFor("Madrid")).Returns(11);
            databaseMock.Setup(db => db.RainAverageFor("Paris")).Returns(50);
            databaseMock.Setup(db => db.RainAverageFor("Noruega")).Returns(125);
            databaseMock.Setup(db => db.RainAverageFor("Unknow")).Returns(0);
            databaseMock.Setup(db => db.RainAverageFor(null)).Throws<NullReferenceException>();

            _weatherCollector = new WeatherCollector(databaseMock.Object);
            
            //O

            var database = Mock.Of<IDatabase>(MockBehavior.Loose);
            Mock.Get(database).Setup(db => db.RainAverageFor("Madrid")).Returns(11);
            Mock.Get(database).Setup(db => db.RainAverageFor("Paris")).Returns(50);
            Mock.Get(database).Setup(db => db.RainAverageFor("Noruega")).Returns(125);            
            Mock.Get(database).Setup(db => db.RainAverageFor(null)).Throws<NullReferenceException>();

            _weatherCollector = new WeatherCollector(database);
        }


        [Theory]
        [InlineData(11, "Madrid")]
        [InlineData(50, "Paris")]
        [InlineData(125, "Noruega")]
        [InlineData(0, "Unknown")]
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
