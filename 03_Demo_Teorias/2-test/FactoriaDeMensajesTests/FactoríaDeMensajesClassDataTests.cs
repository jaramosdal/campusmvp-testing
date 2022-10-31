using Demo_Teorias;
using FactoriaDeMensajesTests.InputTestsData;

namespace FactoriaDeMensajesTests;

public class FactoríaDeMensajesClassDataTests
{
    [Theory]
    [ClassData(typeof(FactoriaDeMensajesTestsData))]
    public void ObtenerMensaje_ShouldBeCorrectMessage_ClassData(string expected, int code)
    {
        //Arrange

        //Act
        var resultado = FactoríaDeMensajes.ObtenerMensaje(code);

        //Assert
        Assert.Equal(expected, resultado);
    }
}