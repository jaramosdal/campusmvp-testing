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
public class AuthorSenderTests
{
    private const int Port = 43257;
    private readonly IAuthorSender _authorSender;
    private Author _authorRecived;
    public AuthorSenderTests(TcpServerFixture tcpServerFixture)
    {
        tcpServerFixture.ServidorTcp.Escuchar(Port);
        tcpServerFixture.ServidorTcp.DataReceived += (string message) => _authorRecived = JsonConvert.DeserializeObject<Author>(message);
        _authorSender = new AuthorSender(Port, IPAddress.Loopback);
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
