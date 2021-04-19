using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BasicApp.Models
{
    public class Supplier : Entity
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(100, ErrorMessage = "Field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(14, ErrorMessage = "Field {0} must have between {2} or {1} characters", MinimumLength = 11)]
        public string Document { get; set; }

        public SupplierType SupplierType { get; set; }

        public Address Address { get; set; }

        [Display(Name = "Is active?")]
        public bool IsActive { get; set; }

        // EF Relations
        public IEnumerable<Product> Products { get; set; }
    }
}
