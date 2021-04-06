using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompleteApp.Mvc.ViewModels
{
    public class SupplierViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(14, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 11)]
        public string Document { get; set; }

        [DisplayName("Type")]
        public int SupplierType { get; set; }

        public AddressViewModel Address { get; set; }

        [DisplayName("Is active?")]
        public bool IsActive { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
