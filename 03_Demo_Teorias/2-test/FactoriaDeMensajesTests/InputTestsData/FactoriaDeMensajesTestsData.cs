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