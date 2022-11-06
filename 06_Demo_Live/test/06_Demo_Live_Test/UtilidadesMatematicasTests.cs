using _06_Demo_Live;

namespace _06_Demo_Live_Test
{
    public class UtilidadesMatematicasTests
    {
        [Fact]
        public void Sumar_ShouldBe33_IfA20AndB13()
        {
            //Arrange
            int a = 20;
            int b = 13;

            //Act
            var result = UtilidadesMatematicas.Sumar(a, b);

            //Assert
            Assert.Equal(33, result);
        }

        [Fact]
        public void Dividir_ShouldBe2_IfA10AndB5()
        {
            //Arrange
            int a = 10;
            int b = 5;

            //Act
            var result = UtilidadesMatematicas.Dividir(a, b);

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Dividir_ShouldThrowDividedByZeroException_IfA10AndB0()
        {
            //Arrange
            int a = 10;
            int b = 0;

            //Act
            Action act = () =>
            {
                _ = UtilidadesMatematicas.Dividir(a, b);
            };

            //Assert
            Assert.Throws<DivideByZeroException>(act);
        }
    }
}