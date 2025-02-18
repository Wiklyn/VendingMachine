using AutoMapper;
using VendingMachine.Application.Features.Order.Commands.CreateOrder;
using VendingMachine.Domain.Dtos.Order;

namespace VendingMachine.Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderRequestDto, Domain.Entities.Order>().ReverseMap();
            CreateMap<CreateOrderCommand, Domain.Entities.Order>().ReverseMap();
        }
    }
}
