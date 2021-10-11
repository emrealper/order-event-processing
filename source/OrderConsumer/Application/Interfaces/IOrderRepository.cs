
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.AggregateModels.OrderAggregate;

namespace Application.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetById(long id);
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> CustomerFullTextSearch(string text);

    }
}
