using VendingMachine.Domain.Response.Base;

namespace VendingMachine.Domain.Response.Product
{
    public class ProductNotFoundResponse : ApiNotFoundResponse
    {
        public ProductNotFoundResponse(int id) : base($"A product with id {id} was not found.")
        {
        }

        public ProductNotFoundResponse(string name) : base($"A product with name \"{name}\" was not found.")
        {
        }

        public ProductNotFoundResponse(int id, string name) : base($"A product with id {id} and name '{name}' was not found.")
        {
        }
    }
}
