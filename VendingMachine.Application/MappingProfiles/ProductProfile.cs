using AutoMapper;
using VendingMachine.Application.Features.Product.Commands.CreateProduct;
using VendingMachine.Application.Features.Product.Commands.UpdateProduct;
using VendingMachine.Domain.Dtos.Product;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Definitivamente tem mais mappings do que o necessário
            CreateMap<ProductResponseDto, Product>().ReverseMap();
            CreateMap<ProductRequestDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ProductRequestDto, ProductResponseDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<CreateProductCommand, ProductRequestDto>().ReverseMap();
            CreateMap<CreateProductCommand, ProductResponseDto>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductRequestDto>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductResponseDto>().ReverseMap();

        }
    }
}
