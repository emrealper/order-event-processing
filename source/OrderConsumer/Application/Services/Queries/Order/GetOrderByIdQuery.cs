using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Queries.Order.Dto;
using AutoMapper;
using MediatR;

namespace Application.Services.Queries.Order
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public long Id { get; set; }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery,
        OrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Orders.GetById(request.Id);
            var order = _mapper.Map<OrderDto>(result);
            return order;
        }
    }
}