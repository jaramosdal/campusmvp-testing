using Newtonsoft.Json;
using System;
using xUnitPractica2Tests.Services;

namespace xUnitPractica2Tests.Fixtures;

public class TcpServerFixture<T> : IDisposable
{
    private readonly ServidorTcp _tcpServer;
    private int _port = 43256;
    private T _dataReceived;

    public T DataReceived => _dataReceived;

    public TcpServerFixture()
    {
        _tcpServer = new ServidorTcp();
        _tcpServer.Escuchar(_port);
        _tcpServer.DataReceived += (string message) => _dataReceived = JsonConvert.DeserializeObject<T>(message);
    }

    public void Dispose()
    {
        _tcpServer.Desconectar();
    }
}
