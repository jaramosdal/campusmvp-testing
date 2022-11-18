using Demo_propiedades;
using Moq;
using System;
using Xunit;

namespace Demo_propiedades_Tests
{
    public class ConsumidorPropiedadesTests
    {
        private readonly ConsumidorPropiedades _consumidor;

        public ConsumidorPropiedadesTests()
        {
            //var propiedadesMock = new Mock<IPropiedades>();
            //propiedadesMock.SetupGet(prop => prop.Prop1).Returns(10);
            //propiedadesMock.SetupSet(prop => prop.Prop1 = It.IsAny<int>());
            //propiedadesMock.SetupAllProperties();
            //propiedadesMock.SetupProperty(prop => prop.Prop1, 10);
            //_consumidor = new ConsumidorPropiedades(propiedadesMock.Object);

            // Mock.Of llama automáticamente a SetupAllProperties, 
            // a no ser que especifiquemos MockBehavior.Strict.
            var propiedades = Mock.Of<IPropiedades>(MockBehavior.Strict);
            Mock.Get(propiedades).SetupProperty(prop => prop.Prop1, 10);
            Mock.Get(propiedades).SetupProperty(prop => prop.Prop2);

            _consumidor = new ConsumidorPropiedades(propiedades);
        }

        [Fact]
        public void GetPropiedad2_ShouldBe11_If11IsSettedWithMethod()
        {
            //Arrange
            var value = 11;

            //Act
            _consumidor.SetPropiedad2(value);
            var result = _consumidor.GetPropiedad2();

            //Assert
            Assert.Equal(value, result);
        }

        [Fact]
        public void GetPropiedad1_ShouldBe10_If10IsSetted()
        {
            //Arrange

            //Act
            var result = _consumidor.GetPropiedad1();

            //Assert
            Assert.Equal(10, result);
        }
    }
}
