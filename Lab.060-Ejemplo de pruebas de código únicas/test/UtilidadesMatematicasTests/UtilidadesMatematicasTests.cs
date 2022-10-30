using DEMO_Pruebas_de_código_únicas;
using System;
using Xunit;

namespace UtilidadesMatematicasTests
{
    public class UtilidadesMatematicasTests
    {
        [Fact]
        public void Sumar_ShouldBe5_IfA3AndB2()
        {
            //Arrange
            var a = 3;
            var b = 2;

            //Act
            var resultado = UtilidadesMatematicas.Sumar(a, b);

            //Assert
            Assert.Equal(5, resultado);
        }

        [Fact]
        public void EsPar_ShouldBeTrue_IfA2()
        {
            //Arrange
            var a = 2;

            //Act
            var resultado = UtilidadesMatematicas.EsPar(a);

            //Assert
            Assert.True(resultado);
        }

        [Fact]
        public void EsPar_ShouldBeFalse_IfA1()
        {
            //Arrange
            var a = 1;

            //Act
            var resultado = UtilidadesMatematicas.EsPar(a);

            //Assert
            Assert.False(resultado);
        }

        [Fact]
        public void Dividir_ShouldBe4_IfA8AndB2()
        {
            //Arrange
            var a = 8;
            var b = 2;

            //Act
            var resultado = UtilidadesMatematicas.Dividir(a, b);

            //Assert
            Assert.Equal(4, resultado);
        }

        [Fact]
        public void Dividir_ShouldThrowDivideByZeroException_IfA8AndB0()
        {
            //Arrange
            var a = 8;
            var b = 0;

            //Act
            Action act = () =>
            {
                var resultado = UtilidadesMatematicas.Dividir(a, b);
            };

            //Assert
            Assert.Throws<DivideByZeroException>(act);
        }
    }
}
