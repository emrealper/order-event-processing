using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Enums;
using MediatR;

namespace Application.Services.Commands.Order
{
    public class NewOrderCommand : IRequest
    {
        [DataMember] public long CustomerId { get; set; }

        [DataMember] public string CustomerName { get; set; }

        [DataMember] public string CustomerLastName { get; set; }

        [DataMember] public string CustomerEmail { get; set; }

        [DataMember] public string ShippingAddress { get; set; }

        [DataMember] public string BillingAddress { get; set; }

        [DataMember] public CurrencyType CurrencyType { get; set; }

        [DataMember] public decimal TotalPrice { get; set; }

        [DataMember] public PaymentMethodType PaymentMethodType { get; set; }

        [DataMember] public List<OrderItemDto> OrderItems { get; set; }


        public class OrderItemDto
        {
            public string ItemCode { get; set; }

            public string Brand { get; set; }

            public string Type { get; set; }

            public string Size { get; set; }

            public string Colour { get; set; }

            public int Quantity { get; set; }

            public decimal Price { get; set; }

            public CurrencyType CurrencyType { get; set; }
        }
    }
}