using System.Data;

namespace Application.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetOrderDatabaseConnection { get; }
    }
}