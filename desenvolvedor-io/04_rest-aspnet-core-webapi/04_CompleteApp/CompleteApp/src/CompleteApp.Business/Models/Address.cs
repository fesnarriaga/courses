﻿using System;

namespace CompleteApp.Business.Models
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        // FK
        public Guid SupplierId { get; set; }

        // EF Relations
        public Supplier Supplier { get; set; }
    }
}
