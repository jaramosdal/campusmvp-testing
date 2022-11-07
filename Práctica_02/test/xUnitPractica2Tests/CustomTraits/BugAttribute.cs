using System;
using Xunit.Sdk;

namespace xUnitPractica2Tests.CustomTraits;

[TraitDiscoverer("DemoRasgosTests.CustomTraits.BugDiscoverer", "DemoRasgosTests")]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class BugAttribute : Attribute, ITraitAttribute
{
    public string[] Ids { get; private set; }

    public BugAttribute(params string[] ids)
    {
        Ids = ids;
    }
}
