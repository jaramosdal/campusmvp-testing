using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit.Sdk;
using xUnit_Practicas1Tests.InputTestsData;

namespace xUnit_Practicas1Tests.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class JsonDataAttribute : DataAttribute
{
    private readonly string _fileName;

    public JsonDataAttribute(string fileName)
    {
        _fileName = fileName;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        string json = File.ReadAllText(_fileName);
        var colors = JsonSerializer.Deserialize<ColorsRGB>(json);

        foreach (var color in colors.GetColorCompositionData)
        {
            yield return new object[] { 
                Color.FromArgb(color.R, color.G, color.B), 
                color.R,
                color.G,
                color.B 
            };
        }
    }
}
