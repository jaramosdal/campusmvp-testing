using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitPractica2Tests.Fixtures;

[CollectionDefinition("TcpServer")]
public class TcpServerCollection : ICollectionFixture<TcpServerFixture>
{
}
