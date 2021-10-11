using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;


namespace Application.Services.Commands.Order
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderDbContext _context;
        public CreateOrderCommandHandler(IOrderDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.AggregateModels.OrderAggregate.Order(request.CustomerId, request.CustomerName,request.CustomerLastName,request.CustomerFullName,
                request.CustomerEmail,request.ShippingAddress,request.BillingAddress,request.CurrencyType,request.TotalPrice,
                request.PaymentMethodType
                );
            foreach (var orderItem in request.OrderItems)
            {
                order.AddOrderItems(orderItem.ItemCode,orderItem.Brand,orderItem.Type,
                   orderItem.Size,orderItem.Colour,orderItem.LongDescription,orderItem.Quantity,
                   orderItem.Price,orderItem.CurrencyType);
            }
            _context.Order.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}