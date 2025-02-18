using AutoMapper;
using MediatR;
using OneOf;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Application.Features.Product.Queries;
using VendingMachine.Domain.Dtos.Product;
using VendingMachine.Domain.Response.Product;

namespace VendingMachine.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, OneOf<ProductResponseDto, ProductNotFoundResponse, ProductBadRequestResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OneOf<ProductResponseDto, ProductNotFoundResponse, ProductBadRequestResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productExists = await _productRepository.CheckIfExists(request.Name);

            if (!productExists)
                return new ProductNotFoundResponse(request.Id, request.Name);

            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                return new ProductBadRequestResponse(validationResult);

            var productToUpdate = _mapper.Map<ProductRequestDto>(request);

            await _productRepository.UpdateAsync(request.Id, productToUpdate, cancellationToken);

            // É válido consultar o registro no banco e retornar o resultado da consulta
            // em vez de mapear o objeto direto daqui de dentro?

            var product = _mapper.Map<ProductResponseDto>(productToUpdate);

            return product;
        }
    }
}
