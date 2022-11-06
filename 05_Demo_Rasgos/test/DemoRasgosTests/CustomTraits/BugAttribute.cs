namespace DemoRasgosTests.CustomTraits;
using Xunit.Sdk;

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