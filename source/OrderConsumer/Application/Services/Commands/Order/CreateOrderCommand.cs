using System.Collections.Generic;
using Domain.Enums;
using MediatR;

namespace Application.Services.Commands.Order
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerEmail { get; set; }

        public string ShippingAddress { get; set; }

        public string BillingAddress { get; set; }

        public CurrencyType CurrencyType { get; set; }

        public decimal TotalPrice { get; set; }

        public PaymentMethodType PaymentMethodType { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }


        public class OrderItemDto
        {
            public string ItemCode { get; set; }

            public string Brand { get; set; }

            public string Type { get; set; }

            public string Size { get; set; }

            public string Colour { get; set; }

            public string LongDescription { get; set; }

            public int Quantity { get; set; }

            public decimal Price { get; set; }

            public CurrencyType CurrencyType { get; set; }
        }
    }
}