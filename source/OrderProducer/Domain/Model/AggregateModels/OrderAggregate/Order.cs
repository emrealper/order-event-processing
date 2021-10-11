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

        public Order(long customerId, string customerName, string customerLastName,string customerEmail,
            string shippingAddress, string billingAddress, CurrencyType currencyType,
            decimal totalPrice, PaymentMethodType paymentMethodType) : this()
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerLastName = customerLastName;
            CustomerEmail = customerEmail;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
            CurrencyType = currencyType;
            TotalPrice = totalPrice;
            PaymentMethodType = paymentMethodType;
        }


        public long CustomerId { get; }
        public string CustomerName { get; }
        public string CustomerLastName { get; }

        public string CustomerFullName { get; private set; }
        public string CustomerEmail { get; }

        public string ShippingAddress { get; }

        public string BillingAddress { get; }

        public CurrencyType CurrencyType { get; }
        public decimal TotalPrice { get; }
        public PaymentMethodType PaymentMethodType { get; }
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public void AddOrderItems(string itemCode, string brand, string type, string size, string colour, int quantity,
            decimal price, CurrencyType currencyType)
        {
            var orderItem = new OrderItem(itemCode, brand, type, size, colour, quantity, price, currencyType);
            //concatenate product item properties to LongDescription property
            orderItem.SetLongDescription();
            _orderItems.Add(orderItem);
        }

        public void SetCustomerFullName()
        {
            CustomerFullName = $"{CustomerName} {CustomerLastName}";
        }
    }
}