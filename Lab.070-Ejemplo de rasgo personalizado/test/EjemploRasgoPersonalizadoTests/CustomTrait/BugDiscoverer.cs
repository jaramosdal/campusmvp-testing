using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace EjemploRasgoPersonalizadoTests.CustomTrait
{
    public class BugDiscoverer : ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.FullNamespace + "." + nameof(BugDiscoverer);

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var bugIds = traitAttribute.GetNamedArgument<string[]>("Ids");

            yield return new KeyValuePair<string, string>("Category", "Bug");

            foreach (var bugId in bugIds)
            {
                if (!string.IsNullOrWhiteSpace(bugId))
                {
                    yield return new KeyValuePair<string, string>("Bug", bugId);
                }
            }


        }
    }
}
