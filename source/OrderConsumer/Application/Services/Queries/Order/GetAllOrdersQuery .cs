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
    public class GetAllOrdersQuery : IRequest<OrderListVm>
    {
    }

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery,
        OrderListVm>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderListVm> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Orders.GetAll();
            var orderList = _mapper.Map<List<OrderDto>>(result);
            var vm = new OrderListVm
            {
                Orders = orderList
            };
            return vm;
        }
    }
}