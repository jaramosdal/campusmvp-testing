using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using xUnitPractica2.Entities;
using xUnitPractica2.Services;
using xUnitPractica2Tests.Fixtures;
using xUnitPractica2Tests.Services;

namespace xUnitPractica2Tests;

[Collection("TcpServer")]
[Trait("Category", "Author")]
public class AuthorSenderTests : IDisposable
{
    private readonly IAuthorSender _authorSender;
    private readonly TcpServerFixture _tcpServerFixture;
    private Author _authorRecived;
    public AuthorSenderTests(TcpServerFixture tcpServerFixture)
    {
        tcpServerFixture.ServidorTcp.DataReceived += AuthorDataRecivedEventHandler;
        _authorSender = new AuthorSender(TcpServerFixture.Port, IPAddress.Loopback);
        _tcpServerFixture = tcpServerFixture;
        _tcpServerFixture.Escuchar();
    }

    private void AuthorDataRecivedEventHandler(string message)
    {
        _authorRecived = JsonConvert.DeserializeObject<Author>(message);
    }

    public void Dispose()
    {
        _tcpServerFixture.ServidorTcp.DataReceived -= AuthorDataRecivedEventHandler;
        _tcpServerFixture.Desconectar();
    }

    [Fact]
    public async Task SendMessageAsync_ShouldSendTheCorrectMessage()
    {
        //Arrange
        var author = new Author(2, "Kant");

        //Act
        await _authorSender.SendAuthorAsync(author);
        await Task.Delay(200); //Damos tiempo a que la comunicación se establezca y recibamos el mensaje

        //Assert
        Assert.NotNull(_authorSender);
        Assert.Equal(author.Id, _authorRecived.Id);
        Assert.Equal(author.Name, _authorRecived.Name);
    }
}
