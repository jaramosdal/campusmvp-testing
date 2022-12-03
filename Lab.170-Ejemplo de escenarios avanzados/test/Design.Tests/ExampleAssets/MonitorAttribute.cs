using System;

namespace Design.Tests.ExampleAssets
{
    public class MonitorAttribute : Attribute
    {
        public int Severity { get; private set; }
        public MonitorAttribute(int severity)
        {
            Severity = severity;
        }
    }
}
