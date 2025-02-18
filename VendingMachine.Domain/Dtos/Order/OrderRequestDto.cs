using VendingMachine.Domain.Dtos.OrderItem;

namespace VendingMachine.Domain.Dtos.Order
{
    public class OrderRequestDto
    {
        public List<OrderItem.OrderItemResponseDto> OrderProducts { get; set; } = [];
    }
}
