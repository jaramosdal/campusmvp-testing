using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitPractica2Tests.Services;

namespace xUnitPractica2Tests.Fixtures;

public class TcpServerFixture
{
    private readonly ServidorTcp _tcpServer;
    internal const int Port = 43256;

    internal ServidorTcp ServidorTcp => _tcpServer;

    public TcpServerFixture()
    {
        _tcpServer = new ServidorTcp();
    }

    public void Escuchar()
    {
        _tcpServer.Escuchar(Port);
    }

    public void Desconectar()
    {
        _tcpServer.Desconectar();
    }
}
