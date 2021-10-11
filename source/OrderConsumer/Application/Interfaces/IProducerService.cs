using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProducerService
    {
        Task SendEventBusAsync(string message, string topicName);
    }
}