using System.Threading.Tasks;

namespace Design.Tests.ExampleAssets
{
    public interface ICommunicator
    {
        Task ConnectAsync();
        bool SendMessage(string message);
        bool IsConnected { get; }
    }
}
