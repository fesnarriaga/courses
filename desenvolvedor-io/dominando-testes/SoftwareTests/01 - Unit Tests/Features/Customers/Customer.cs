using Features.Core;
using System;

namespace Features.Customers
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        protected Customer() { }

        public Customer(
            Guid id,
            string name,
            string lastName,
            DateTime birth,
            string email,
            bool isActive,
            DateTime createdAt
            )
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Birth = birth;
            Email = email;
            IsActive = isActive;
            CreatedAt = createdAt;
        }

        public string FullName()
        {
            return $"{Name} {LastName}";
        }

        public bool IsSpecial()
        {
            return CreatedAt < DateTime.Now.AddYears(-3) && IsActive;
        }

        public void Disable()
        {
            IsActive = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
