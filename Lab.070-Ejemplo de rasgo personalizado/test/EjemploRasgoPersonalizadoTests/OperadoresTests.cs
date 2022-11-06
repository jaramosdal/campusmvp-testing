using EjemploRasgoPersonalizado;
using EjemploRasgoPersonalizadoTests.CustomTrait;
using Xunit;

namespace EjemploRasgoPersonalizadoTests
{
    public class OperadoresTests
    {
        [Fact]
        [Bug(10, 32, 47)]
        public void Suma_ShouldBe3_IfA1AndB2()
        {
            //Arrange
            var a = 1;
            var b = 2;

            //Act
            var result = Operadores.Suma(a, b);

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        [Trait("Category", "Bug")]
        [Trait("Bug", "10")]
        [Trait("Bug", "32")]
        [Trait("Bug", "47")]
        public void Resta_ShouldBe1_IfA2AndB1()
        {
            //Arrange
            var a = 2;
            var b = 1;

            //Act
            var result = Operadores.Resta(a, b);

            //Assert
            Assert.Equal(1, result);
        }
    }
}
