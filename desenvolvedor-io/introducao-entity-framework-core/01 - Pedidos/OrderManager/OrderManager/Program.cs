using Microsoft.EntityFrameworkCore;
using OrderManager.Data;
using OrderManager.Domain;
using OrderManager.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateData();
            //CreateDataBatch();
            //ReadData();
            //CreateOrder();
            //ReadDataForward();
            //UpdateData();
            //UpdateDataDisconnected();
            //UpdateDataDisconnected2();
            //DeleteData();
            //DeleteDataDisconnected();
        }

        private static void CreateData()
        {
            var product = new Product
            {
                Description = "Product One",
                BarCode = "12345678901234",
                Price = 10M,
                ProductType = ProductType.Sale,
                IsActive = true
            };

            using var db = new AppDbContext();

            // First option
            db.Products.Add(product);

            // Second option
            //db.Set<Product>().Add(product);

            // Third option
            //db.Entry(product).State = EntityState.Added;

            // Fourth option
            //db.Add(product);

            var result = db.SaveChanges();

            Console.WriteLine($"Rows affected: {result}");
        }

        private static void CreateDataBatch()
        {
            var product = new Product
            {
                Description = "Product One",
                BarCode = "12345678901234",
                Price = 10M,
                ProductType = ProductType.Sale,
                IsActive = true
            };

            var customer = new Customer
            {
                Name = "Felipe Esnarriaga",
                PostalCode = "85660000",
                City = "Dois Vizinhos",
                State = "PR",
                Phone = "46991403141"
            };

            var customerList = new[]
            {
                new Customer
                {
                    Name = "Test One",
                    PostalCode = "85660000",
                    City = "Dois Vizinhos",
                    State = "PR",
                    Phone = "46991403141"
                },

                new Customer
                {
                    Name = "Test Two",
                    PostalCode = "85660000",
                    City = "Dois Vizinhos",
                    State = "PR",
                    Phone = "46991403141"
                }
            };

            using var db = new AppDbContext();

            // First option
            db.AddRange(product, customer);

            // Second option
            db.Customers.AddRange(customerList);

            // Third option
            //db.Set<Customer>().AddRange(customerList);

            var result = db.SaveChanges();

            Console.WriteLine($"Rows affected: {result}");
        }

        private static void ReadData()
        {
            using var db = new AppDbContext();

            var syntaxQuery =
                (from customer in db.Customers
                 where customer.Id > 0
                 select customer)
                .AsNoTracking()
                .ToList();

            var extensionQuery =
                db.Customers
                    .Where(x => x.Id > 0)
                    .OrderBy(c => c.Id)
                    .AsNoTracking()
                    .ToList();
        }

        private static void CreateOrder()
        {
            using var db = new AppDbContext();

            var customer = db.Customers.FirstOrDefault();
            var product = db.Products.FirstOrDefault();

            var order = new Order
            {
                CustomerId = customer.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Notes = "Some note about order",
                DeliveryChargeType = DeliveryChargeType.Free,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = product.Id,
                        Discount = 0M,
                        Quantity = 1,
                        Price = 10M
                    }
                }
            };

            db.Orders.Add(order);

            db.SaveChanges();
        }

        private static void ReadDataForward()
        {
            using var db = new AppDbContext();

            var orders =
                db.Orders
                    //.Include("OrderItems")
                    .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                    .ToList();

            Console.WriteLine(orders.Count);
        }

        private static void UpdateData()
        {
            using var db = new AppDbContext();

            var customer = db.Customers.FirstOrDefault();

            customer.Name = "Felipe Duarte";

            // It will make track again, will update entire entity
            //db.Entry(customer).State = EntityState.Modified;

            // Remove this to UPDATE ONLY DIFF
            //db.Customers.Update(customer);

            db.SaveChanges();
        }

        private static void UpdateDataDisconnected()
        {
            using var db = new AppDbContext();

            var customer = db.Customers.FirstOrDefault();

            var disconnectCustomer = new
            {
                Name = "Disconnected Customer",
                Phone = "46991403242"
            };

            db.Entry(customer).CurrentValues.SetValues(disconnectCustomer);

            db.SaveChanges();
        }

        private static void UpdateDataDisconnected2()
        {
            using var db = new AppDbContext();

            var customerEntity =
                db.Customers
                    .AsNoTracking()
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

            var customer = new Customer
            {
                Id = customerEntity.Id
            };

            var disconnectCustomer = new
            {
                Name = "Disconnected Customer 2",
                Phone = "46991403242"
            };

            db.Attach(customer);

            db.Entry(customer).CurrentValues.SetValues(disconnectCustomer);

            db.SaveChanges();
        }

        private static void DeleteData()
        {
            using var db = new AppDbContext();

            var customer =
                db.Customers
                    .ToList()
                    .LastOrDefault();

            db.Customers.Remove(customer);
            //db.Remove(customer);
            //db.Entry(customer).State = EntityState.Deleted;

            db.SaveChanges();
        }

        private static void DeleteDataDisconnected()
        {
            using var db = new AppDbContext();

            var customerEntity =
                db.Customers
                    .AsNoTracking()
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

            var customer = new Customer
            {
                Id = customerEntity.Id
            };

            db.Entry(customer).State = EntityState.Deleted;

            db.SaveChanges();
        }
    }
}
