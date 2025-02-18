using AutoMapper;
using MediatR;
using OneOf;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Domain.Response.Order;

namespace VendingMachine.Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OneOf<Domain.Entities.Order, OrderNotFoundResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OneOf<Domain.Entities.Order, OrderNotFoundResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null)
                return new OrderNotFoundResponse(request.Id);

            return order;
        }
    }
}
