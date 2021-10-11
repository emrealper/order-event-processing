using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Application.Services.Queries.Order.Dto
{
    public class OrderDto
    {
        public long Id { get; set; }
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
    }
}
