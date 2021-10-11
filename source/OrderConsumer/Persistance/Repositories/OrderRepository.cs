using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Dapper;
using Domain.AggregateModels.OrderAggregate;

namespace Persistance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _dbConnection = connectionFactory.GetOrderDatabaseConnection;
        }

        public async Task<Order> GetById(long id)
        {
            var query = $"select * from [Order].[dbo].[Order] where Id={id}";
            var result = await _dbConnection.QueryAsync<Order>(query);
            if (result == null)
                throw new KeyNotFoundException("Could not be found.");
            _dbConnection.Dispose();
            return result.First();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var query = "select * from [Order].[dbo].[Order]";
            var result = await _dbConnection.QueryAsync<Order>(query);
            if (result == null)
                throw new KeyNotFoundException("Could not be found.");
            _dbConnection.Dispose();
            return result;
        }

        public async Task<IEnumerable<Order>> CustomerFullTextSearch(string text)
        {
            var query = $"select * from [Order].[dbo].[Order] where CONTAINS(CustomerFullName,'{text}')";
            var result = await _dbConnection.QueryAsync<Order>(query);
            if (result == null)
                throw new KeyNotFoundException("Could not be found.");
            _dbConnection.Dispose();
            return result;
        }
    }
}