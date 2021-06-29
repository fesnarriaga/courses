using System;
using System.Collections.Generic;

namespace NerdStore.Core.DomainObjects.Dtos
{
    public class OrderProductList
    {
        public Guid OrderId { get; set; }
        public ICollection<OrderProductListItem> Items { get; set; }
    }

    public class OrderProductListItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
