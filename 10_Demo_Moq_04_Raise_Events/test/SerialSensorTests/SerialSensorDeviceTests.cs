using Moq;
using SerialSensor.Services;
using System;
using Xunit;

namespace SerialSensorTests
{
    public class SerialSensorDeviceTests
    {
        private readonly SerialSensorDevice _serialSensor;
        private readonly ISerialPortWrapper _serial;
        private const string RECEIVED_RESPONSE = "Received Message";

        public SerialSensorDeviceTests()
        {
            _serial = Mock.Of<ISerialPortWrapper>();
            Mock.Get(_serial).Setup(s => s.WriteLine(It.IsAny<string>())).Raises(s => s.DataRecived += null, null, RECEIVED_RESPONSE);
            _serialSensor = new SerialSensorDevice(_serial);
        }

        [Fact]
        public void GetLastData_ShouldBeRECEIVED_RESPONSE_IfMessageSended()
        {
            //Arrange
            var message = "Test Message";
            //Act
            _serialSensor.SendMessage(message);
            var lastData = _serialSensor.GetLastData();

            //Assert
            Assert.Equal(RECEIVED_RESPONSE, lastData);
        }

        [Fact]
        public void DataRecived_ShouldBeRegisteredInConstuctor()
        {
            //Arrange
            var registeredEvent = false;
            Mock.Get(_serial).SetupAdd(s => s.DataRecived += It.IsAny<EventHandler<string>>()).Callback(() => registeredEvent = true);

            //Act
            var serialSensor = new SerialSensorDevice(_serial);

            //Assert
            Assert.True(registeredEvent);
        }

        [Fact]
        public void DataRecived_ShouldBeDeregisteredInDispose()
        {
            //Arrange
            var deregisteredEvent = false;
            Mock.Get(_serial).SetupRemove(s => s.DataRecived -= It.IsAny<EventHandler<string>>()).Callback(() => deregisteredEvent = true);
            var serialSensor = new SerialSensorDevice(_serial);

            //Act
            serialSensor.Dispose();

            //Assert
            Assert.True(deregisteredEvent);
        }

        [Theory]
        [InlineData("Data1")]
        [InlineData("Data2")]
        [InlineData("Data3")]
        public void DataRecived_ShouldBeExpectedValue(string expected)
        {
            //Arrange

            //Act
            Mock.Get(_serial).Raise(s => s.DataRecived += null, null, expected);
            var lastData = _serialSensor.GetLastData();

            //Assert
            Assert.Equal(expected, lastData);
        }
    }
}
