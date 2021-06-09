using System;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalog.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Code { get; set; }
    }
}
