using DemoRasgos;
using DemoRasgosTests.CustomTraits;
using Xunit;

namespace DemoRasgosTests;

public class FuncionalidadATests
{
    [Fact]
    [Trait("Category", "FuncionalidadA")]
    [Trait("Trabajo", "72")]
    public void FuncionalidadATrue_ShouldBeTrue()
    {
        //Arrange
        FuncionalidadA funcionalidadA = new();

        //Act
        var result = funcionalidadA.FuncionalidadATrue();

        //Assert
        Assert.True(result);
    }

    [Fact]
    [Trait("Category", "FuncionalidadA")]
    [Bug("A27-Z2", "A22-Z7")]
    public void FuncionalidadAFalse_ShouldBeFalse()
    {
        //Arrange
        FuncionalidadA funcionalidadA = new();

        //Act
        var result = funcionalidadA.FuncionalidadATrue();

        //Assert
        Assert.False(result);
    }
}