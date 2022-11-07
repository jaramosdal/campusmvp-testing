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
    internal const int MessageSenderPort = 43256;
    internal const int AuthorSenderPort = 43257;

    internal ServidorTcp ServidorTcp => _tcpServer;

    public TcpServerFixture()
    {
        _tcpServer = new ServidorTcp();
        _tcpServer.Escuchar(MessageSenderPort);
        _tcpServer.Escuchar(AuthorSenderPort);
    }

    public void Dispose()
    {
        _tcpServer.Desconectar();
    }
}
