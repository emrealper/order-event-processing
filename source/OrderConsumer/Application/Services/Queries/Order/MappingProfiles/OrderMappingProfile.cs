using Application.Services.Queries.Order.Dto;
using AutoMapper;

namespace Application.Services.Queries.Member.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Domain.AggregateModels.OrderAggregate.Order, OrderDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerId))
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.CustomerName))
                .ForMember(d => d.CustomerLastName, opt => opt.MapFrom(s => s.CustomerLastName))
                .ForMember(d => d.CustomerFullName, opt => opt.MapFrom(s => s.CustomerFullName))
                .ForMember(d => d.CustomerEmail, opt => opt.MapFrom(s => s.CustomerEmail))
                .ForMember(d => d.ShippingAddress, opt => opt.MapFrom(s => s.ShippingAddress))
                .ForMember(d => d.BillingAddress, opt => opt.MapFrom(s => s.BillingAddress))
                .ForMember(d => d.CurrencyType, opt => opt.MapFrom(s => s.CurrencyType))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(s => s.TotalPrice))
                .ForMember(d => d.PaymentMethodType, opt => opt.MapFrom(s => s.PaymentMethodType));
        }
    }
}