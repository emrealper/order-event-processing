using Domain.Enums;

namespace Domain.AggregateModels.OrderAggregate
{
    public class OrderItem
    {
        protected OrderItem()
        {
        }

        public OrderItem(string itemCode, string brand, string type, string size, string colour, int quantity,
            decimal price, CurrencyType currencyType)
        {
            ItemCode = itemCode;

            Brand = brand;

            Type = type;

            Size = size;

            Colour = colour;

            Quantity = quantity;

            Price = price;

            CurrencyType = currencyType;
        }

        public void SetLongDescription()
        {
            LongDescription = $"{ItemCode} {Brand} {Type} {Colour}";
        }


        public string ItemCode { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }

        public string Size { get; set; }


        public string Colour { get; set; }

        public string LongDescription { get; private set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public CurrencyType CurrencyType { get; set; }
    }
}