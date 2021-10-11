using Application.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace Infrastructure.DataHelpers
{
    public class DeserializeKafkaMessageToCommand<TE> : IDeserializeKafkaMessage<TE>
        where TE : class, IRequest<bool>

    {
        public TE Deserialize(string kafkaMessage)
        {
            return JsonConvert.DeserializeObject<TE>(kafkaMessage);
        }
    }
}