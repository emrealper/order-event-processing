using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
    }
}
