using AutoMapper;
using VendingMachine.Domain.Dtos.OrderItem;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.MappingProfiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            //CreateMap<OrderItem, OrderItem>()
            //    .ForMember(dest => dest.Product, opt => opt.Ignore())
            //    .ForMember(dest => dest.Id, opt => opt.Ignore())
            //    .ReverseMap();

            CreateMap<OrderItemRequestDto, OrderItem>().ReverseMap();
        }
    }
}
