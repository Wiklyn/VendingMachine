using FluentValidation.Results;
using VendingMachine.Domain.Response.Base;

namespace VendingMachine.Domain.Response.Product
{
    public class ProductBadRequestResponse : ApiBadRequestResponse
    {
        public ProductBadRequestResponse() : base("Invalid Product.")
        {
        }

        public ProductBadRequestResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
    }
}
