using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IConsumerService
    {
        Task SubscribeServiceBusAsync();
    }
}