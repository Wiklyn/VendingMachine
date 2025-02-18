using AutoMapper;
using MediatR;
using VendingMachine.Application.Contracts.Persistence;

namespace VendingMachine.Application.Features.Order.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<Domain.Entities.Order>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var ordersToMap = await _orderRepository.GetAllAsync(cancellationToken);

            var orders = _mapper.Map<List<Domain.Entities.Order>>(ordersToMap);

            return orders;
        }
    }
}
