using System.Drawing;
using xUnit_Practicas1;
using xUnit_Practicas1Tests.InputTestsData;

namespace xUnit_Practicas1Tests;

public class FactoriaDeColoresTests
{
    [Theory]
    [InlineData("Red", "rojo")]
    [InlineData("Blue", "azul")]
    [InlineData("Green", "verde")]
    [InlineData("White", "blanco")]
    [InlineData("Black", "negro")]
    [InlineData("0", "something")]
    public void GetColorByName_ShouldBeCorrectColor(string expected, string colorName)
    {
        //Arrange
        // string colorName = "";

        //Act
        var color = FactoriaDeColores.GetColorByName(colorName);

        //Assert
        Assert.Equal(expected, color.Name);
    }

    //[Theory]
    //[ClassData(typeof(FactoriaDeColoresTestsData))]
    //public void GetColorComposition_ShouldThrowArgumentOutOfRangeException_IfAnyNotIn0To255(int red, int green, int blue)
    //{
    //    //Arrange
    //    // string colorName = "";

    //    //Act
    //    Action act = () =>
    //    {
    //        var resultado = FactoriaDeColores.GetColorComposition(red, green, blue);
    //    };

    //    //Assert
    //    Assert.Throws<ArgumentOutOfRangeException>(act);
    //}

    [Theory]
    [MemberData(nameof(FactoriaDeColoresTestsData.InvalidData), MemberType = typeof(FactoriaDeColoresTestsData))]
    public void GetColorComposition_ShouldThrowArgumentOutOfRangeException_IfAnyNotIn0To255(int red, int green, int blue)
    {
        //Arrange
        // string colorName = "";

        //Act
        Action act = () =>
        {
            var resultado = FactoriaDeColores.GetColorComposition(red, green, blue);
        };

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Theory]
    [MemberData(nameof(FactoriaDeColoresTestsData.ValidData), MemberType = typeof(FactoriaDeColoresTestsData))]
    public void GetColorComposition_ShouldBeCorrectColor_IfAllIn0To255(int red, int green, int blue)
    {
        //Arrange
        // string colorName = "";

        //Act
        var color = FactoriaDeColores.GetColorComposition(red, green, blue);

        //Assert
        // TODO
    }
}