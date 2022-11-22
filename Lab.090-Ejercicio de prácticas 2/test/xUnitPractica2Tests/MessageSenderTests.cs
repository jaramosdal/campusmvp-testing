using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using xUnitPractica2.Entities;
using xUnitPractica2.Services;
using xUnitPractica2Tests.Services;

namespace xUnitPractica2Tests
{
    public class MessageSenderTests : IDisposable
    {
        private const int Port = 43256;
        private readonly IMessageSender _messageSender;
        private readonly ServidorTcp _tcpServer;
        private MessageData _messageDataRecived;
        public MessageSenderTests()
        {
            _tcpServer = new ServidorTcp();
            _tcpServer.Escuchar(Port);
            _tcpServer.DataReceived += (string message) => _messageDataRecived = JsonConvert.DeserializeObject<MessageData>(message);
            _messageSender = new MessageSender(Port, IPAddress.Loopback);
        }

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
            Assert.Equal(messageData.Date,_messageDataRecived.Date);
            Assert.Equal(messageData.Author.Id,_messageDataRecived.Author.Id);
            Assert.Equal(messageData.Author.Name,_messageDataRecived.Author.Name);
            Assert.Equal(messageData.Message,_messageDataRecived.Message);
        }

        public void Dispose()
        {
            _tcpServer.Desconectar();
        }
    }
}
