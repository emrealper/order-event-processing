using System.Collections.Generic;
using Domain.Common;
using Domain.Enums;

namespace Domain.AggregateModels.OrderAggregate
{
    public class Order : BaseAuditableEntity, IAggregateRoot
    {
        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so MemberAccount cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method OrderAggregateRoot.AddOrderItem() which includes behaviour.
        private readonly List<OrderItem> _orderItems;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(long customerId, string customerName, string customerLastName, string customerFullName,string customerEmail,
            string shippingAddress, string billingAddress, CurrencyType currencyType,
            decimal totalPrice, PaymentMethodType paymentMethodType) : this()
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerLastName = customerLastName;
            CustomerFullName = customerFullName;
            CustomerEmail = customerEmail;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
            CurrencyType = currencyType;
            TotalPrice = totalPrice;
            PaymentMethodType = paymentMethodType;
        }

        // DDD Patterns comment
        // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
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
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        // DDD Patterns comment
        // This Member AggregateRoot's method "AddOrderItem()" should be the only way to add Product Item to the Order
        public void AddOrderItems(string itemCode, string brand, string type, string size, string colour,
            string longDescription, int quantity,
            decimal price, CurrencyType currencyType)
        {
            var orderItem = new OrderItem(itemCode, brand, type, size, colour, longDescription, quantity, price,
                currencyType);
            _orderItems.Add(orderItem);
        }
    }
}