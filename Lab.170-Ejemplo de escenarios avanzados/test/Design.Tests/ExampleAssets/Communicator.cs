using System;
using System.Threading.Tasks;

namespace Design.Tests.ExampleAssets
{
    [AlarmMonitor]
    public class Communicator : ICommunicator, IDisposable
    {
        [Monitor(2)]
        public bool IsConnected { get; private set; }

        public Communicator()
        {
            IsConnected = false;
        }

        public async Task ConnectAsync()
        {
            await Task.Delay(500);
            IsConnected = true;
        }

        public bool SendMessage(string message)
        {
            //Sending message
            return true;
        }

        public void Dispose()
        {
            
        }
    }
}
