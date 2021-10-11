using System.Collections.Generic;
using Application.Services.Queries.Order.Dto;

namespace Application.Services.Queries.Order.ViewModels
{
    public class OrderListVm
    {
        public IList<OrderDto> Orders { get; set; }
    }
}