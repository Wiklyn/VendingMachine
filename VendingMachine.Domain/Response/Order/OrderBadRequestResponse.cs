using FluentValidation.Results;
using VendingMachine.Domain.Response.Base;

namespace VendingMachine.Domain.Response.Order
{
    public class OrderBadRequestResponse : ApiBadRequestResponse
    {
        public OrderBadRequestResponse(string message) : base("Invalid Order.")
        {
        }

        public OrderBadRequestResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
    }
}
