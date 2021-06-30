using System;
using System.Collections.Generic;

namespace NerdStore.Core.DomainObjects.Dtos
{
    public class ProductList
    {
        public Guid OrderId { get; set; }
        public ICollection<ProductListItem> Items { get; set; }
    }
}
