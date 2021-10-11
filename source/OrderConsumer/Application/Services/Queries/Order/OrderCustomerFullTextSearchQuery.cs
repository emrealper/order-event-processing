using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Queries.Order.Dto;
using Application.Services.Queries.Order.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Services.Queries.Order
{
    public class OrderCustomerFullTextSearchQuery : IRequest<OrderListVm>
    {
        public string SearchText { get; set; }
    }

    public class OrderCustomerFullTextSearchQueryHandler : IRequestHandler<OrderCustomerFullTextSearchQuery,
        OrderListVm>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderCustomerFullTextSearchQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderListVm> Handle(OrderCustomerFullTextSearchQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Orders.CustomerFullTextSearch(request.SearchText);
            var orderList = _mapper.Map<List<OrderDto>>(result);
            var vm = new OrderListVm
            {
                Orders = orderList
            };
            return vm;
        }
    }
}