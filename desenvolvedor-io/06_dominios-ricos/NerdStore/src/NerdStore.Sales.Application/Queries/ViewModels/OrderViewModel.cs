using System;

namespace NerdStore.Sales.Application.Queries.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public decimal Total { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
