using Domain.AggregateModels.OrderAggregate;
using Domain.Enums;
using Xunit;

namespace Domain.UnitTest
{
    public class OrderAggregateTest
    {
        [Fact]
        public void Create_Order_Success()
        {
            //Arrange    
            var customerId = 23982398;
            var customerName = "Emre";
            var customerLastName = "Alper";
            var customerEmail = "emrealper@gmail.com";
            var customerFullName = "Emre Alper";
            var shippingAddress = "AgricolaStrasse 35, München, Germany";
            var billingAddress = "AgricolaStrasse 35, München, Germany";
            var currencyType = CurrencyType.Euro;
            var paymentMethodType = PaymentMethodType.Paypal;
            var totalPrice = 240;
            //Act 
            var fakeOrder = new Order(customerId, customerName, customerLastName, customerFullName,
                customerEmail, shippingAddress, billingAddress, currencyType, totalPrice, paymentMethodType);
            //Assert
            Assert.NotNull(fakeOrder);
        }

        [Fact]
        public void Add_OrderItem_Success()
        {
            //Arrange    
            var customerId = 23982398;
            var customerName = "Emre";
            var customerLastName = "Alper";
            var customerEmail = "emrealper@gmail.com";
            var customerFullName = "Emre Alper";
            var shippingAddress = "AgricolaStrasse 35, München, Germany";
            var billingAddress = "AgricolaStrasse 35, München, Germany";
            var currencyType = CurrencyType.Euro;
            var paymentMethodType = PaymentMethodType.Paypal;
            var totalPrice = 240;
            var itemCode = "10293098";
            var brand = "Jack Wolfskin";
            var type = "Parka";
            var size = "XL";
            var colour = "Black";
            var quantity = 1;
            var longDescription = "10293098 Jack Wolfskin Parka Black";
            var price = 240;
            //Act 
            var fakeOrder = new Order(customerId, customerName, customerLastName, customerFullName,
                customerEmail, shippingAddress, billingAddress, currencyType, totalPrice, paymentMethodType);
            fakeOrder.AddOrderItems(itemCode, brand, type, size, colour, longDescription, quantity, price,
                currencyType);
            //Assert
            Assert.NotNull(fakeOrder.OrderItems);
        }
    }
}