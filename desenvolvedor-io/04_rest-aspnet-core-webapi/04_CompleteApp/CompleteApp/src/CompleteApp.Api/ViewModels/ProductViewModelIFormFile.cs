using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompleteApp.Api.ViewModels
{
    public class ProductViewModelIFormFile
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(200, ErrorMessage = "{0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(1000, ErrorMessage = "{0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        public string Image { get; set; }

        public IFormFile ImageIFormFile { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Guid SupplierId { get; set; }

        [ScaffoldColumn(false)]
        public string SupplierName { get; set; }
    }
}
