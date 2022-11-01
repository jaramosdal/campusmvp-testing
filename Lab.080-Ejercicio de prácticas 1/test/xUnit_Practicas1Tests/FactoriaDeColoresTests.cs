using System.Drawing;
using xUnit_Practicas1;
using xUnit_Practicas1Tests.InputTestsData;

namespace xUnit_Practicas1Tests;

public class FactoriaDeColoresTests
{
    [Theory]
    [ClassData(typeof(FactoriaDeColoresTestsData))]
    public void GetColorByName_ShouldBeCorrectColor(Color expected, string colorName)
    {
        //Arrange
        // string colorName = "";

        //Act
        var color = FactoriaDeColores.GetColorByName(colorName);

        //Assert
        Assert.Equal(expected, color);
    }

    [Theory]
    [MemberData(nameof(FactoriaDeColoresGetColorCompositionTestsData.InvalidData), MemberType = typeof(FactoriaDeColoresGetColorCompositionTestsData))]
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
    [MemberData(nameof(FactoriaDeColoresGetColorCompositionTestsData.ValidData), MemberType = typeof(FactoriaDeColoresGetColorCompositionTestsData))]
    public void GetColorComposition_ShouldBeCorrectColor_IfAllIn0To255(int red, int green, int blue)
    {
        //Arrange

        //Act
        var color = FactoriaDeColores.GetColorComposition(red, green, blue);

        //Assert
        Assert.True(red == color.R && green == color.G && blue == color.B);
        //Assert.Equal(red, color.R);
        //Assert.Equal(green, color.G);
        //Assert.Equal(blue, color.A);
    }
}