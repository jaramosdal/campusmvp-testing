using Configurando_Llamadas;
using Moq;
using System;
using Xunit;

namespace Configurando_Llamadas_Tests
{
    public class CarTests
    {
        private readonly Car _car;
        private Mock<IControl> _control;
        private int correctKey;

        public CarTests()
        {
            _control = new Mock<IControl>();
            _control.Setup(c => c.OpenDoors(It.IsAny<string>())).Returns(false);
            _control.Setup(c => c.OpenDoors(It.Is<string>(s=>s.Contains("Correct"))))
                .Callback(() => 
                { 
                    correctKey++;
                })
                .Returns(true);

            _control.SetupSequence(c => c.Start())
                    .Throws<ConnectionLostException>()
                    .Returns(false)
                    .Returns(false)
                    .Returns(true);

            _car = new Car(_control.Object);
        }

        [Theory]
        [InlineData(true, "CorrectKey")]
        [InlineData(true, "CorrectKey2")]
        [InlineData(true, "CorrectKey3")]
        [InlineData(false, "BadKey")]
        public void OpenDoors_ShouldBeExpected(bool expected, string key)
        {
            //Arrange

            //Act
            var result = _car.OpenDoors(key);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OpenDoors_ShouldThrowConnectionLostException_IfConnectionIsLost()
        {
            //Arrange
            _control.Setup(c => c.OpenDoors(It.IsAny<string>())).Throws<ConnectionLostException>();

            //Act
            Action act = () =>
            {
                _ = _car.OpenDoors("");
            };

            //Assert
            Assert.Throws<ConnectionLostException>(act);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(11)]
        [InlineData(12)]
        public void Start_ShouldThrowOutOfRangeException_IfRetriesOutOfRange(int retries)
        {
            //Arrange

            //Act
            Action act = () =>
            {
                _ = _car.Start(retries);
            };

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData(false, 2)]
        [InlineData(true, 5)]
        [InlineData(true, 7)]

        public void Start_ShouldBeExpectedResult_IfStartedInAllowedRetries(bool expected, int retries)
        {
            //Arrange

            //Act
            var result = _car.Start(retries);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}