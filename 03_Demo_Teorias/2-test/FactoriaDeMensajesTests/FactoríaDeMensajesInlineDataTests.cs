using Demo_Teorias;

namespace FactoriaDeMensajesTests;

public class FactoríaDeMensajesInlineDataTests
{
    [Theory]
    [InlineData("Hola", 0)]
    [InlineData("Adiós", 1)]
    [InlineData("CampusMVP", 2)]
    [InlineData("Pruebas", 3)]
    [InlineData("De", 4)]
    [InlineData("Código", 5)]
    [InlineData("No se ha podido recuperar", 6)]
    public void ObtenerMensaje_ShouldBeCorrectMessage_InlineData(string expected, int code)
    {
        //Arrange

        //Act
        var resultado = FactoríaDeMensajes.ObtenerMensaje(code);

        //Assert
        Assert.Equal(expected, resultado);
    }
}