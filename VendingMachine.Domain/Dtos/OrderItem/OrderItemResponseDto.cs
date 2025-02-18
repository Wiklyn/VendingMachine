namespace VendingMachine.Domain.Dtos.OrderItem
{
    public class OrderItemResponseDto
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Entities.Product Product { get; set; }

    }
}
