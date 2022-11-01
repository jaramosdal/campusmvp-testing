using System.Drawing;
using xUnit_Practicas1;

namespace xUnit_Practicas1Tests;

public class FactoriaDeColoresTests
{
    [Theory]
    [InlineData(Color.Red, "rojo")]
    public void GetColorByName_ShouldBeCorrectColor(Color expected, string colorName)
    {
        //Arrange
        // string colorName = "";

        //Act
        var color = FactoriaDeColores.GetColorByName(colorName);

        //Assert
        Assert.Equal(expected, color);
    }
}