using Domain.Common;
using Domain.Enums;

namespace Domain.AggregateModels.OrderAggregate
{
    public class OrderItem : BaseAuditableEntity
    {
        protected OrderItem()
        {
        }

        public OrderItem(string itemCode, string brand, string type, string size, string colour, string longDescription,
            int quantity,
            decimal price, CurrencyType currencyType)
        {
            ItemCode = itemCode;

            Brand = brand;

            Type = type;

            Size = size;

            Colour = colour;

            Quantity = quantity;

            LongDescription = longDescription;

            Price = price;

            CurrencyType = currencyType;
        }


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