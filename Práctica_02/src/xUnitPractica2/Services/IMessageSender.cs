using System.Threading.Tasks;
using xUnitPractica2.Entities;

namespace xUnitPractica2.Services
{
    public interface IMessageSender
    {
        Task SendMessageAsync(MessageData message);
    }
}
