namespace VendingMachine.Domain.Entities
{
    public class Order : BaseModel
    {
        public decimal TotalPrice { get; private set; }

        // OrderItem Navigation Property
        public List<OrderItem> OrderProducts { get; set; }

        private Order() { }

        public Order(List<OrderItem> orderProducts)
        {
            OrderProducts = orderProducts ?? [];
            TotalPrice = CalculateTotalPrice(OrderProducts);
        }

        private static decimal CalculateTotalPrice(List<OrderItem> orderProducts)
        {
            decimal sum = 0;

            foreach (var item in orderProducts)
            {
                sum += item.Quantity * item.Product.Price;
            }

            return sum;
        }
    }
}
