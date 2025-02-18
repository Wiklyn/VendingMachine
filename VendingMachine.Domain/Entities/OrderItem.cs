namespace VendingMachine.Domain.Entities
{
    public class OrderItem : BaseModel
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        // Product Navigation Properties
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
