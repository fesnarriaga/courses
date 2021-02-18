using OrderManager.ValueObjects;

namespace OrderManager.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string BarCode { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }

        public bool IsActive { get; set; }
    }
}
