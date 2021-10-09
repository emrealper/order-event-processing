using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEventBusService
    {
        Task SendEventBusAsync(string message, string topicName);
    }
}