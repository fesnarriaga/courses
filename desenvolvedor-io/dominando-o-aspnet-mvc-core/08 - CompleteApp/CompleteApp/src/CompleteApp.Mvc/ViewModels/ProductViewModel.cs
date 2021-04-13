using CompleteApp.Mvc.Extensions.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompleteApp.Mvc.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(1000, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("Product Image")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Currency]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Created at")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Is active?")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [DisplayName("Supplier")]
        public Guid SupplierId { get; set; }

        public SupplierViewModel Supplier { get; set; }

        public IEnumerable<SupplierViewModel> Suppliers { get; set; }
    }
}
