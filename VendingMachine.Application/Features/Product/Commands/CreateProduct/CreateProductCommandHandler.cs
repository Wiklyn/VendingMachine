using AutoMapper;
using MediatR;
using OneOf;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Application.Features.Product.Queries;
using VendingMachine.Domain.Dtos.Product;
using VendingMachine.Domain.Response.Product;

namespace VendingMachine.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, OneOf<ProductResponseDto, ProductBadRequestResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OneOf<ProductResponseDto, ProductBadRequestResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                return new ProductBadRequestResponse(validationResult);
            
            var productToCreate = _mapper.Map<Domain.Entities.Product>(request);

            var product = await _productRepository.CreateAsync(productToCreate, cancellationToken);

            var productDto = _mapper.Map<ProductResponseDto>(product);

            return productDto;
        }
    }
}
