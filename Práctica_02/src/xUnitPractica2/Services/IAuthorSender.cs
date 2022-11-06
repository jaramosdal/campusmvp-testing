using System.Threading.Tasks;
using xUnitPractica2.Entities;

namespace xUnitPractica2.Services
{
    public interface IAuthorSender
    {
        Task SendAuthorAsync(Author author);
    }
}
