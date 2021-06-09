using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalog.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} must be greater than or equal {1}")]
        [Required(ErrorMessage = "{0} is required")]
        public int StockAmount { get; set; }

        [Range(0, 9999999999999999.99, ErrorMessage = "{0} must be greater than {1}")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal Width { get; set; }

        [Range(0, 9999999999999999.99, ErrorMessage = "{0} must be greater than {1}")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal Height { get; set; }

        [Range(0, 9999999999999999.99, ErrorMessage = "{0} must be greater than {1}")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal Depth { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Guid CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
