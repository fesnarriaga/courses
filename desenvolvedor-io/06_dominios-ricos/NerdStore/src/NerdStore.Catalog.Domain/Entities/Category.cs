using NerdStore.Core.DomainObjects.Entities;
using NerdStore.Core.DomainObjects.Validations;
using System.Collections.Generic;

namespace NerdStore.Catalog.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public string Code { get; private set; }

        // EF Relations
        public ICollection<Product> Products { get; set; }

        public Category(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }

        public void Validate()
        {
            Validation.NotEmpty(Name, "Name is required");
            Validation.NotEmpty(Code, "Code is required");
        }
    }
}
