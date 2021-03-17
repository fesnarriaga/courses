using System;
using System.ComponentModel.DataAnnotations;

namespace BasicApp.Models
{
    public class Address : Entity
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(50, ErrorMessage = "Field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string Number { get; set; }

        [MaxLength(200, ErrorMessage = "Field {0} must have until {1} characters")]
        public string Complement { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(8, ErrorMessage = "Field {0} must have {1} characters", MinimumLength = 8)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(100, ErrorMessage = "Field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(100, ErrorMessage = "Field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(50, ErrorMessage = "Field {0} must have between {2} and {1} characters", MinimumLength = 2)]
        public string State { get; set; }

        // Foreign Keys
        public Guid SupplierId { get; set; }

        // EF Relations
        public Supplier Supplier { get; set; }
    }
}
