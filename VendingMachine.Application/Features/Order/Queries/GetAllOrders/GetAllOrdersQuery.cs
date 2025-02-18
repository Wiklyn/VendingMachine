using MediatR;

namespace VendingMachine.Application.Features.Order.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<List<Domain.Entities.Order>>
    {
    }
}
