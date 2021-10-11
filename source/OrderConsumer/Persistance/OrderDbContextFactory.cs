using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Persistance
{
    public class OrderDbContextFactory : DesignTimeDbContextFactoryBase<OrderDbContext>
    {
        protected override OrderDbContext CreateNewInstance(DbContextOptions<OrderDbContext> options)
        {
            return new OrderDbContext(options);
        }
    }
}