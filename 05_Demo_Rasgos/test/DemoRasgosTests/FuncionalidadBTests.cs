using DemoRasgos;
using DemoRasgosTests.CustomTraits;
using Xunit;

namespace DemoRasgosTests;

[Trait("Category", "FuncionalidadB")]
public class FuncionalidadBTests
{
    [Fact]
    [Trait("Trabajo", "72")]
    public void FuncionalidadBUnoi_ShouldBeUno()
    {
        //Arrange
        FuncionalidadB funcionalidadB = new();

        //Act
        var result = funcionalidadB.FuncionalidadBUno();

        //Assert
        Assert.Equal(1, result);
    }

    [Fact]
    [Bug("T27-Z7", "T27-Z8", "T27-Z9")]
    public void FuncionalidadBDos_ShouldBeDos()
    {
        //Arrange
        FuncionalidadB funcionalidadB = new();

        //Act
        var result = funcionalidadB.FuncionalidadBDos();

        //Assert
        Assert.Equal(2, result);
    }
}