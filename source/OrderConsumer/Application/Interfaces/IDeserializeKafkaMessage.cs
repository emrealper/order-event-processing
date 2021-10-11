using MediatR;

namespace Application.Interfaces
{
    public interface IDeserializeKafkaMessage<TE>
        where TE : class, IRequest<bool>

    {
        TE Deserialize(string line);
    }
}