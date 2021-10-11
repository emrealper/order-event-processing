using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace Application.Services.Commands.Order
{
    public class NewOrderCommandHandler : IRequestHandler<NewOrderCommand>
    {
        private readonly IEventBusService _eventBus;

        public NewOrderCommandHandler(IEventBusService eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(NewOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Model.AggregateModels.OrderAggregate.Order(request.CustomerId,
                request.CustomerName, request.CustomerLastName, request.CustomerEmail, request.ShippingAddress,
                request.BillingAddress, request.CurrencyType, request.TotalPrice, request.PaymentMethodType);
            order.SetCustomerFullName();
            foreach (var item in request.OrderItems)
                order.AddOrderItems(item.ItemCode,
                    item.Brand, item.Type,
                    item.Size, item.Colour, item.Quantity, item.Price,
                    item.CurrencyType);

            var data = JsonConvert.SerializeObject(order, Formatting.Indented);
            await _eventBus.SendEventBusAsync(data, "order");

            return Unit.Value;
        }
    }
}