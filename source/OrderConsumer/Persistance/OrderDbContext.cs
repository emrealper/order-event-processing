using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Common;
using Domain.AggregateModels.OrderAggregate;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        private readonly IDateTime _dateTime;

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public OrderDbContext(
            DbContextOptions<OrderDbContext> options,
            IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "test-user";
                        entry.Entity.UpdatedBy = "test-user";
                        entry.Entity.UpdatedDate = _dateTime.Now;
                        entry.Entity.CreatedDate = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = "test-user";
                        entry.Entity.UpdatedDate = _dateTime.Now;
                        break;
                }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
        }
    }
}