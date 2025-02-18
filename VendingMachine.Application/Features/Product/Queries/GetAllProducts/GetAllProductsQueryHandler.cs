using AutoMapper;
using MediatR;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Domain.Dtos.Product;

namespace VendingMachine.Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);

            var productDtos = _mapper.Map<List<ProductResponseDto>>(products);

            return productDtos;
        }
    }
}

