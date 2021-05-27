using NerdStore.Core.DomainObjects.Entities;
using NerdStore.Core.DomainObjects.Exceptions;
using NerdStore.Core.DomainObjects.Interfaces;
using NerdStore.Core.DomainObjects.Validations;
using NerdStore.Core.DomainObjects.ValueObjects;
using System;

namespace NerdStore.Catalog.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public int StockAmount { get; private set; }
        public Dimensions Dimensions { get; set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // FK
        public Guid CategoryId { get; private set; }

        // EF Relations
        public Category Category { get; private set; }

        public Product(
            string name,
            string description,
            decimal price,
            string image,
            Dimensions dimensions,
            bool active,
            DateTime createdAt,
            Guid categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            Image = image;
            Dimensions = dimensions;
            Active = active;
            CreatedAt = createdAt;
            CategoryId = categoryId;

            Validate();
        }

        public void SetDescription(string description)
        {
            Validation.NotEmpty(description, "Description is required");
            Description = description;
        }

        public void Enable() => Active = true;

        public void Disable() => Active = false;

        public void SetCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity < 0)
                quantity *= -1;

            if (!HasStockBalance(quantity))
                throw new DomainException("Insufficient Stock Amount");

            StockAmount -= quantity;
        }

        public void IncreaseStock(int quantity)
        {
            StockAmount += quantity;
        }

        public bool HasStockBalance(int quantity)
        {
            return StockAmount >= quantity;
        }

        public void Validate()
        {
            Validation.NotEmpty(Name, "Name is required");
            Validation.NotEmpty(Description, "Description is required");
            Validation.GreaterThan(Price, 0.01M, "Price must be greater than 0");
            Validation.NotEmpty(Image, "Image is required");
            Validation.NotEqual(CategoryId, Guid.Empty, "CategoryId is required");
        }
    }
}
