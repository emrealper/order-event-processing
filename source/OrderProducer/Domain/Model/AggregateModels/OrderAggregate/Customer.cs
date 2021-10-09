using Domain.Common;

namespace Domain.Model.AggregateModels.OrderAggregate
{
    public class Customer : ValueObject
    {
        public Customer()
        {
        }

        public Customer(long id, string name, string lastName, string email)
        {
            CustomerId = id;
            CustomerName = name;
            CustomerLastName = lastName;
            CustomerEmail = email;
        }

        public long CustomerId { get; }
        public string CustomerName { get; }
        public string CustomerLastName { get; }
        public string CustomerEmail { get; }
    }
}