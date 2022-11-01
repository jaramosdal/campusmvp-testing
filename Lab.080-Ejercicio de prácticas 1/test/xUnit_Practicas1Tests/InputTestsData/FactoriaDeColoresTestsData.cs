using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit_Practicas1Tests.InputTestsData;

public class FactoriaDeColoresTestsData : TheoryData<Color, string>
{
    public FactoriaDeColoresTestsData()
    {
        Add(Color.Red, "rojo");
        Add(Color.Blue, "azul");
        Add(Color.Green, "verde");
        Add(Color.White, "blanco");
        Add(Color.Black, "negro");
        Add(default, "something");
    }
}

public class FactoriaDeColoresGetColorCompositionTestsData
{
    public static IEnumerable<object[]> InvalidData => new List<object[]>
    {
        new object[] { -1, 0, 0 },
        new object[] { 256, 0, 0 },
        new object[] { 0, -1, 0 },
        new object[] { 0, 256, 0 },
        new object[] { 0, 0, -1 },
        new object[] { 0, 0, 256 }
    };

    public static IEnumerable<object[]> ValidData => new List<object[]>
    {
        new object[] { 0, 0, 0 },
        new object[] { 255, 0, 0 },
        new object[] { 0, 255, 0 },
        new object[] { 0, 0, 255 }
    };
}
