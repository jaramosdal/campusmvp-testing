using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit_Practicas1Tests.InputTestsData;

//public class FactoriaDeColoresTestsData : TheoryData<int, int, int>
//{
//    public FactoriaDeColoresTestsData()
//    {
//        Add(-1, 0, 0);
//        Add(256, 0, 0);
//        Add(0, -1, 0);
//        Add(0, 256, 0);
//        Add(0, 0, -1);
//        Add(0, 0, 256);
//    }
//}

public class FactoriaDeColoresTestsData 
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
        new object[] { 0, 0, 0 },
        new object[] { 0, 255, 0 },
        new object[] { 0, 0, 0 },
        new object[] { 0, 0, 255 }
    };
}
