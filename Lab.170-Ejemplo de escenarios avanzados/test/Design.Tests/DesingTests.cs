using Design.Tests.ExampleAssets;
using FluentAssertions;
using FluentAssertions.Common;
using FluentAssertions.Types;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Design.Tests
{
    public class DesingTests
    {
        [Fact]
        public void Communicator_ShouldBeDecoratedWithMonitorAttributeWithSeverity3()
        {
            //Arrange
            var communicatorType = typeof(Communicator);
            //Act

            //Assert
            communicatorType.Should().BeDecoratedWithOrInherit<MonitorAttribute>(atr => atr.Severity == 3);
        }

        [Fact]
        public void Communicator_ShouldNoBeStatic()
        {
            //Arrange
            var communicatorType = typeof(Communicator);
            //Act

            //Assert
            communicatorType.Should().NotBeStatic();
        }

        [Fact]
        public void Communicator_ShouldNoImplementICommunicator()
        {
            //Arrange
            var communicatorType = typeof(Communicator);
            //Act

            //Assert
            communicatorType.Should().Implement<ICommunicator>();
        }

        [Fact]
        public void Communicator_ShouldBePublic()
        {
            //Arrange
            var communicatorType = typeof(Communicator);
            //Act

            //Assert
            communicatorType.Should().HaveAccessModifier(CSharpAccessModifier.Public);
        }

        [Fact]
        public void Communicator_ShouldHaveDefaultConstructor()
        {
            //Arrange
            var communicatorType = typeof(Communicator);
            //Act

            //Assert
            communicatorType.Should().HaveDefaultConstructor();
        }

        [Fact]
        public void CommunicatorConnect_ShouldBeAsyncAndReturnTask()
        {
            //Arrange
            var connectMethod = typeof(Communicator).GetMethod("ConnectAsync");
            //Act

            //Assert
            connectMethod.Should().BeAsync();
            connectMethod.Should().Return<Task>();
        }

        [Fact]
        public void CommunicatorSend_ShouldBeReturnBool()
        {
            //Arrange
            var sendMethod = typeof(Communicator).GetMethod("SendMessage");
            //Act

            //Assert
            sendMethod.Should().Return<bool>();
        }

        [Fact]
        public void CommunicatorIsConnected_ShouldBeReadable()
        {
            //Arrange
            var sendMethod = typeof(Communicator).GetProperty("IsConnected");
            //Act

            //Assert
            sendMethod.Should().BeReadable();
        }

        [Fact]
        public void CommunicatorIsConnected_ShouldBeWritable()
        {
            //Arrange
            var sendMethod = typeof(Communicator).GetProperty("IsConnected");
            //Act

            //Assert
            sendMethod.Should().BeWritable();
        }

        [Fact]
        public void AllTypes_ShouldHaveSeverityGreaterThan0_IfDecoratedWithAnyMonitorAttribute()
        {
            //Arrange
            var types = AllTypes.From(typeof(ICommunicator).Assembly)
                                .ThatAreDecoratedWithOrInherit<MonitorAttribute>();
            //Act

            //Assert
            types.Should().BeDecoratedWithOrInherit<MonitorAttribute>(atr => atr.Severity > 0);
        }

        [Fact]
        public void AllProperties_ShouldBeDecoratedWithMonitorAttribute_IfImplementsICommunicator()
        {
            //Arrange
            var properties = AllTypes.From(typeof(ICommunicator).Assembly)
                                .ThatImplement<ICommunicator>()
                                .Properties();
            //Act

            //Assert
            properties.Should().BeDecoratedWith<MonitorAttribute>();
        }
    }
}
