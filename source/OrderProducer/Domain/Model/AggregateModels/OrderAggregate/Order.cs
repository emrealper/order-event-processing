using System.Collections.Generic;
using Domain.AggregateModels.OrderAggregate;
using Domain.Common;
using Domain.Enums;

namespace Domain.Model.AggregateModels.OrderAggregate
{
    public class Order : IAggregateRoot
    {
        private readonly List<OrderItem> _orderItems;


        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(Customer customer) : this()
        {
            Customer = customer;
        }

        // Customer is a Value Object
        public Customer Customer { get; }

        public string ShippingAddress { get; set; }

        public string BillingAddress { get; set; }

        public CurrencyType CurrencyType { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public void AddOrderItems(string itemCode, string brand, string type, string size, string colour, int quantity,
            decimal price, CurrencyType currencyType)
        {
            var orderItem = new OrderItem(itemCode, brand, type, size, colour, quantity, price, currencyType);
            _orderItems.Add(orderItem);
        }
    }
}