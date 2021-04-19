using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicApp.Models
{
    public class Product : Entity
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(1000, ErrorMessage = "Field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        [DisplayName("Image Path")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        [Display(Name = "Is active?")]
        public bool IsActive { get; set; }

        // Foreign Keys
        public Guid SupplierId { get; set; }

        // EF Relations
        public Supplier Supplier { get; set; }
    }
}
