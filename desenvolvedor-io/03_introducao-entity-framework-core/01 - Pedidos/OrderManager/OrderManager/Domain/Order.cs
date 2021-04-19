using OrderManager.ValueObjects;
using System;
using System.Collections.Generic;

namespace OrderManager.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public DeliveryChargeType DeliveryChargeType { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Notes { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public int CustomerId { get; set; }

        // EF
        public Customer Customer { get; set; }
    }
}
