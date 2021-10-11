using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IOrderRepository orderRepository
            )
        {
            Orders = orderRepository;
        }
        public IOrderRepository Orders { get; }
    }
}
