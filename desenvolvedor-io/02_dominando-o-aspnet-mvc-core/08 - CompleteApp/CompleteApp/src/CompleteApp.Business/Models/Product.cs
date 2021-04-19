using System;

namespace CompleteApp.Business.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        // Foreign Keys
        public Guid SupplierId { get; set; }

        // EF Relations
        public Supplier Supplier { get; set; }
    }
}
