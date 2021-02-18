namespace OrderManager.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        // EF
        public Product Product { get; set; }

        public Order Order { get; set; }
    }
}
