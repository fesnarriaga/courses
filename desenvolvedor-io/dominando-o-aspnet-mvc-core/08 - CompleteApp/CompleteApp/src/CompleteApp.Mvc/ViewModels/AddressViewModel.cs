using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompleteApp.Mvc.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(50, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 1)]
        public string Number { get; set; }

        public string Complement { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(8, ErrorMessage = "Field {0} must be {1} characters", MinimumLength = 8)]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(100, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string City { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(50, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string State { get; set; }

        [HiddenInput]
        public Guid SupplierId { get; set; }
    }
}
