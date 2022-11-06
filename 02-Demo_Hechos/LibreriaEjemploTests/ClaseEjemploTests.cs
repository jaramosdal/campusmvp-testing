using LibreriaEjemplo;
using Xunit;

namespace LibreriaEjemploTests;

public class ClaseEjemploTests
{
    [Fact]
    public void SiempreDevuelvoTrue_RetornaTrue()
    {
        //Arrange
        var claseEjemplo = new ClaseEjemplo();

        //Act
        var result = claseEjemplo.SiempreDevuelvoTrue();

        //Assert
        Assert.True(result);
    }
}