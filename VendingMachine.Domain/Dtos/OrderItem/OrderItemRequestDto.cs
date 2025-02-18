namespace VendingMachine.Domain.Dtos.OrderItem
{
    public class OrderItemRequestDto
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
