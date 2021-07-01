using System;

namespace NerdStore.Core.DomainObjects.Dtos.Order
{
    public class ProductListItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
