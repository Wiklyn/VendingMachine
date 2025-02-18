namespace VendingMachine.Domain.Dtos.Order
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem.OrderItemResponseDto> OrderProducts { get; set; } = [];
    }
}
