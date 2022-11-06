using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DemoRasgosTests.CustomTraits;

public class BugDiscoverer : ITraitDiscoverer
{
    public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
    {
        var bugIds = traitAttribute.GetNamedArgument<string[]>("Ids");

        yield return new KeyValuePair<string, string>("Category", "Bug");

        foreach (var bugId in bugIds)
        {
            yield return new KeyValuePair<string, string>("Bug", bugId);
        }

    }
}
