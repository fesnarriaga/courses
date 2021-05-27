using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.DomainObjects.Exceptions;
using NerdStore.Core.DomainObjects.ValueObjects;
using System;
using Xunit;

namespace NerdStore.Catalog.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Validate_ShouldThrowExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Product(
                    string.Empty,
                    "Description",
                    1M,
                    "Image",
                    new Dimensions(1M, 1M, 1M),
                    true,
                    DateTime.Now,
                    Guid.NewGuid()));
            Assert.Equal("Name is required", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(
                    "Name",
                    string.Empty,
                    1M,
                    "Image",
                    new Dimensions(1M, 1M, 1M),
                    true,
                    DateTime.Now,
                    Guid.NewGuid()));
            Assert.Equal("Description is required", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(
                    "Name",
                    "Description",
                    0,
                    "Image",
                    new Dimensions(1M, 1M, 1M),
                    true,
                    DateTime.Now,
                    Guid.NewGuid()));
            Assert.Equal("Price must be greater than 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(
                    "Name",
                    "Description",
                    1M,
                    string.Empty, 
                    new Dimensions(1M, 1M, 1M),
                    true,
                    DateTime.Now,
                    Guid.NewGuid()));
            Assert.Equal("Image is required", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(
                    "Name",
                    "Description",
                    1M,
                    "Image",
                    new Dimensions(0, 1M, 1M),
                    true,
                    DateTime.Now,
                    Guid.NewGuid()));
            Assert.Equal("Width must be greater than 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(
                    "Name",
                    "Description",
                    1M,
                    "Image",
                    new Dimensions(1M, 1M, 1M),
                    true,
                    DateTime.Now,
                    Guid.Empty));
            Assert.Equal("CategoryId is required", ex.Message);
        }
    }
}
