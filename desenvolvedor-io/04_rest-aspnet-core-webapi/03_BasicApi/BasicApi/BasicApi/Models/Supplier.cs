using System;
using System.ComponentModel.DataAnnotations;

namespace BasicApi.Models
{
    public class Supplier
    {
        [Key]
        public Guid id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(14, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 11)]
        public string Document { get; set; }

        public int SupplierType { get; set; }

        public bool IsActive { get; set; }
    }
}
