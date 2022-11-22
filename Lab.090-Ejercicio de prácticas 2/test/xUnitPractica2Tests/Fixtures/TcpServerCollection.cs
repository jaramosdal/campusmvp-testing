using Xunit;

namespace xUnitPractica2Tests.Fixtures;

[CollectionDefinition("TcpServer")]
public class TcpServerCollection : ICollectionFixture<TcpServerFixture>
{
}
