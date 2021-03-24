using Microsoft.AspNetCore.Http;
using System;
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

        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Is active?")]
        public bool IsActive { get; set; }

        public SupplierViewModel Supplier { get; set; }
    }
}
