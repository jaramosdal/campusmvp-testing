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
[Trait("Category", "Message")]
public class MessageSenderTests : IDisposable
{
    private readonly IMessageSender _messageSender;
    private readonly TcpServerFixture _tcpServerFixture;
    private MessageData _messageDataRecived;

    public MessageSenderTests(TcpServerFixture tcpServerFixture)
    {
        tcpServerFixture.ServidorTcp.DataReceived += MessageDataRecivedEventHandler;
        _messageSender = new MessageSender(TcpServerFixture.Port, IPAddress.Loopback);
        _tcpServerFixture = tcpServerFixture;
        _tcpServerFixture.Escuchar();
    }

    private void MessageDataRecivedEventHandler(string message)
    {
        _messageDataRecived = JsonConvert.DeserializeObject<MessageData>(message);
    }

    public void Dispose()
    {
        _tcpServerFixture.ServidorTcp.DataReceived -= MessageDataRecivedEventHandler;
        _tcpServerFixture.Desconectar();
    }

    //[Fact(Skip = "No funciona")]
    [Fact]
    public async Task SendMessageAsync_ShouldSendTheCorrectMessage()
    {
        //Arrange
        var messageData = new MessageData(DateTime.Now, new Author(1, "Pedro"), "TestMessage");

        //Act
        await _messageSender.SendMessageAsync(messageData);
        await Task.Delay(200); //Damos tiempo a que la comunicación se establezca y recibamos el mensaje

        //Assert
        Assert.NotNull(_messageDataRecived);
        Assert.Equal(messageData.Date, _messageDataRecived.Date);
        Assert.Equal(messageData.Author.Id, _messageDataRecived.Author.Id);
        Assert.Equal(messageData.Author.Name, _messageDataRecived.Author.Name);
        Assert.Equal(messageData.Message, _messageDataRecived.Message);
    }
}
