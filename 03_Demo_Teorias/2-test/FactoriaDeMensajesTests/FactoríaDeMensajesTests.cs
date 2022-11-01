using Demo_Teorias;
using FactoriaDeMensajesTests.InputTestsData;
using FactoriaDeMensajesTests.DataAttributes;

namespace FactoriaDeMensajesTests;

public class FactoríaDeMensajesTests
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

    public static IEnumerable<object[]> Data1 => new List<object[]>
    {
        new object[] { "Hola", 0 },
        new object[] { "Adiós", 1 },
        new object[] { "CampusMVP", 2 },
        new object[] { "Pruebas", 3 },
        new object[] { "No se ha podido recuperar", -1 }
    };

    [Theory]
    [MemberData(nameof(Data1))]
    public void ObtenerMensaje_ShouldBeCorrectMessage_MemberData(string expected, int code)
    {
        //Arrange

        //Act
        var resultado = FactoríaDeMensajes.ObtenerMensaje(code);

        //Assert
        Assert.Equal(expected, resultado);
    }

    public static IEnumerable<object[]> GetData(int testCount)
    {
        var datos = new List<object[]>
        {
            new object[] { "Hola", 0 },
            new object[] { "Adiós", 1 },
            new object[] { "CampusMVP", 2 },
            new object[] { "Pruebas", 3 },
            new object[] { "No se ha podido recuperar", -1 }
        };

        return datos.Take(testCount);
    }

    [Theory]
    [MemberData(nameof(GetData), parameters: 3)]
    public void ObtenerMensaje_ShouldBeCorrectMessage_MemberData2(string expected, int code)
    {
        //Arrange

        //Act
        var resultado = FactoríaDeMensajes.ObtenerMensaje(code);

        //Assert
        Assert.Equal(expected, resultado);
    }

    [Theory]
    [MemberData(nameof(FactoriaDeMensajesData.Data), MemberType = typeof(FactoriaDeMensajesData ))]
    public void ObtenerMensaje_ShouldBeCorrectMessage_MemberData3(string expected, int code)
    {
        //Arrange

        //Act
        var resultado = FactoríaDeMensajes.ObtenerMensaje(code);

        //Assert
        Assert.Equal(expected, resultado);
    }

    [Theory]
    [MemberData(nameof(FactoriaDeMensajesData.GetData), parameters: 3, MemberType = typeof(FactoriaDeMensajesData ))]
    public void ObtenerMensaje_ShouldBeCorrectMessage_MemberData4(string expected, int code)
    {
        //Arrange

        //Act
        var resultado = FactoríaDeMensajes.ObtenerMensaje(code);

        //Assert
        Assert.Equal(expected, resultado);
    }

    [Theory]
    [CsvData("InputData.csv")]
    public void ObtenerMensaje_ShouldBeCorrectMessage_CsvData(string expected, int code)
    {
        //Arrange

        //Act
        var resultado = FactoríaDeMensajes.ObtenerMensaje(code);

        //Assert
        Assert.Equal(expected, resultado);
    }
}