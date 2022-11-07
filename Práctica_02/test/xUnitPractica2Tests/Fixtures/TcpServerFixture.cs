using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitPractica2Tests.Services;

namespace xUnitPractica2Tests.Fixtures;

public class TcpServerFixture : IDisposable
{
    private readonly ServidorTcp _tcpServer;

    internal ServidorTcp ServidorTcp => _tcpServer;

    public TcpServerFixture()
    {
        _tcpServer = new ServidorTcp();
    }

    public void Dispose()
    {
        _tcpServer.Desconectar();
    }
}
