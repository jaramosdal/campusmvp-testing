using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using xUnitPractica2.Entities;

namespace xUnitPractica2.Services
{
    public class MessageSender : IMessageSender
    {
        private readonly IPAddress _ipAddress;
        private readonly int _port;
        public MessageSender(int port, IPAddress ipAddress)
        {
            _port = port;
            _ipAddress = ipAddress;
        }

        public async Task SendMessageAsync(MessageData message)
        {
            using (var tcpClient = new TcpClient())
            {
                tcpClient.Connect(_ipAddress, _port);
                using (var writter = new StreamWriter(tcpClient.GetStream()))
                {
                    var json = JsonConvert.SerializeObject(message);
                    await writter.WriteLineAsync(json);
                    await writter.FlushAsync();
                }
            }
        }
    }
}
