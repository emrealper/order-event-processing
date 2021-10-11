using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.AggregateModels.OrderAggregate;

namespace Application.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order> Order { get; set; }
        DbSet<OrderItem> OrderItem { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
    }
}
