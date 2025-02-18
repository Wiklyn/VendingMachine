using MediatR;
using OneOf;
using VendingMachine.Domain.Response.Order;

namespace VendingMachine.Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OneOf<Domain.Entities.Order, OrderNotFoundResponse>>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
