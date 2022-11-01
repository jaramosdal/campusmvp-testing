using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace FactoriaDeMensajesTests.InputTestsData;

public class FactoriaDeMensajesTestsData : TheoryData<string, int>
{
    public FactoriaDeMensajesTestsData()
    {
        Add("Hola", 0);
        Add("Adiós", 1);
        Add("CampusMVP", 2);
        Add("Pruebas", 3);
        Add("No se ha podido recuperar", -1);
    }
}

public class FactoriaDeMensajesData
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { "Hola", 0 },
        new object[] { "Adiós", 1 },
        new object[] { "CampusMVP", 2 },
        new object[] { "Pruebas", 3 },
        new object[] { "No se ha podido recuperar", -1 }
    };

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
}

// public class FactoriaDeMensajesTestsData : IEnumerable<object[]>
// {
//     public IEnumerator<object[]> GetEnumerator()
//     {
//         yield return new object[] { "Hola", 0 };
//         yield return new object[] { "Adiós", 1 };
//         yield return new object[] { "CampusMVP", 2 };
//         yield return new object[] { "Pruebas", 3 };
//         yield return new object[] { "No se ha podido recuperar", -1 };
//     }

//     IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
// }