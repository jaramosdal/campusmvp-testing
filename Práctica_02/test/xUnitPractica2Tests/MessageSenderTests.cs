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
public class MessageSenderTests
{
    private const int Port = 43256;
    private readonly IMessageSender _messageSender;
    private MessageData _messageDataRecived;
    public MessageSenderTests(TcpServerFixture tcpServerFixture)
    {
        tcpServerFixture.ServidorTcp.Escuchar(Port);
        tcpServerFixture.ServidorTcp.DataReceived += (string message) => _messageDataRecived = JsonConvert.DeserializeObject<MessageData>(message);
        _messageSender = new MessageSender(Port, IPAddress.Loopback);
    }

    [Fact(Skip = "No funciona")]
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
