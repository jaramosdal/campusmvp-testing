using System;
using System.Linq;
using Xunit.Sdk;

namespace EjemploRasgoPersonalizadoTests.CustomTrait
{
    [TraitDiscoverer(BugDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class BugAttribute : Attribute, ITraitAttribute
    {
        public BugAttribute(params string[] ids)
        {
            Ids = ids;
        }

        public BugAttribute(params long[] ids)
        {
            Ids = ids.Select(x => x.ToString()).ToArray();
        }

        public BugAttribute()
        {

        }

        public string[] Ids { get; private set; }
    }
}
