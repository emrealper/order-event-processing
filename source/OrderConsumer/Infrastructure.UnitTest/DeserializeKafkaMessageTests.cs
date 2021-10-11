using System.Collections.Generic;
using Application.Services.Commands.Order;
using Domain.Enums;
using Infrastructure.DataHelpers;
using Newtonsoft.Json;
using Xunit;

namespace Infrastructure.UnitTest
{
    public class DeserializeKafkaMessageTests
    {
        [Theory]
        [InlineData(
            "{\r\n  \"CustomerId\": 23982398,\r\n  \"CustomerName\": \"Emre\",\r\n  \"CustomerLastName\": \"Alper\",\r\n  \"CustomerFullName\": \"Emre Alper\",\r\n  \"CustomerEmail\": \"emrealper@gmail.com\",\r\n  \"ShippingAddress\": \"AgricolaStrasse 35, München, Germany\",\r\n  \"BillingAddress\": \"AgricolaStrasse 35, München, Germany\",\r\n  \"CurrencyType\": 1,\r\n  \"TotalPrice\": 240.0,\r\n  \"PaymentMethodType\": 1,\r\n  \"OrderItems\": [\r\n    {\r\n      \"ItemCode\": \"10293098\",\r\n      \"Brand\": \"Jack Wolfskin\",\r\n      \"Type\": \"Parka\",\r\n      \"Size\": \"XL\",\r\n      \"Colour\": \"Black\",\r\n      \"LongDescription\": \"10293098 Jack Wolfskin Parka Black\",\r\n      \"Quantity\": 1,\r\n      \"Price\": 240.0,\r\n      \"CurrencyType\": 1\r\n    }\r\n  ]\r\n}")]
        public void Should_Correctly_Deserialize_Kafka_Message_To_Create_Order_Command(string kafkaMessage)
        {
            var deserializedKafkaMessage = new DeserializeKafkaMessageToCommand<CreateOrderCommand>();

            var expected = new CreateOrderCommand
            {
                CustomerId = 23982398,
                CustomerName = "Emre",
                CustomerLastName = "Alper",
                CustomerEmail = "emrealper@gmail.com",
                CustomerFullName = "Emre Alper",
                ShippingAddress = "AgricolaStrasse 35, München, Germany",
                BillingAddress = "AgricolaStrasse 35, München, Germany",
                CurrencyType = CurrencyType.Euro,
                PaymentMethodType = PaymentMethodType.Paypal,
                TotalPrice = 240,
                OrderItems = new List<CreateOrderCommand.OrderItemDto>
                {
                    new CreateOrderCommand.OrderItemDto
                    {
                        ItemCode = "10293098",
                        Brand = "Jack Wolfskin",
                        Type = "Parka",
                        Size = "XL",
                        Colour = "Black",
                        Quantity = 1,
                        Price = 240,
                        CurrencyType = CurrencyType.Euro,
                        LongDescription = "10293098 Jack Wolfskin Parka Black"
                    }
                }
            };

            var actual = deserializedKafkaMessage.Deserialize(kafkaMessage);


            var expectedStr = JsonConvert.SerializeObject(expected);
            var actualStr = JsonConvert.SerializeObject(actual);
            Assert.Equal(expectedStr, actualStr);
        }
    }
}