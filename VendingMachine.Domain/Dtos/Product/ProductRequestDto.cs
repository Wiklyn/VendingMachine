namespace VendingMachine.Domain.Dtos.Product
{
    public class ProductRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}
