using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderManager.Domain;
using System;
using System.Linq;

namespace OrderManager.Data
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=OrderManagerDB;Integrated Security=true";
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(x => x.AddConsole());

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    ConnectionString,
                    option =>
                        option
                            .EnableRetryOnFailure(
                                maxRetryCount: 3,
                                maxRetryDelay: TimeSpan.FromSeconds(5),
                                errorNumbersToAdd: null)
                            //.MigrationsHistoryTable("MIGRATION_TABLE_NAME")
                    );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

            // MOVED TO CONFIGURATION FILES
            //modelBuilder.Entity<Customer>(builder =>
            //{
            //    builder.ToTable("Customers");

            //    builder.HasKey(x => x.Id);

            //    builder.Property(x => x.Name)
            //        .HasColumnType("VARCHAR(80)")
            //        .IsRequired();

            //    builder.Property(x => x.Phone)
            //        .HasColumnType("CHAR(11)");

            //    builder.Property(x => x.PostalCode)
            //        .HasColumnType("CHAR(8)")
            //        .IsRequired();

            //    builder.Property(x => x.State)
            //        .HasColumnType("CHAR(2)")
            //        .IsRequired();

            //    builder.Property(x => x.City)
            //        .HasMaxLength(60)
            //        .IsRequired();

            //    builder.HasIndex(x => x.Phone)
            //        .HasDatabaseName("IDX_CUSTOMER_PHONE");
            //});

            //modelBuilder.Entity<Product>(builder =>
            //{
            //    builder.HasKey(x => x.Id);

            //    builder.Property(x => x.BarCode)
            //        .HasColumnType("VARCHAR(14)")
            //        .IsRequired();

            //    builder.Property(x => x.Description)
            //        .HasColumnType("VARCHAR(60)");

            //    builder.Property(x => x.Price)
            //        .IsRequired();

            //    builder.Property(x => x.ProductType)
            //        .HasConversion<string>();
            //});

            //modelBuilder.Entity<Order>(builder =>
            //{
            //    builder.HasKey(x => x.Id);

            //    builder.Property(x => x.StartDate)
            //        .HasDefaultValue("GETDATE()")
            //        .ValueGeneratedOnAdd();

            //    builder.Property(x => x.OrderStatus)
            //        .HasConversion<string>();

            //    builder.Property(x => x.DeliveryChargeType)
            //        .HasConversion<int>();

            //    builder.Property(x => x.Notes)
            //        .HasColumnType("VARCHAR(512)");

            //    builder.HasMany(x => x.OrderItems)
            //        .WithOne(i => i.Order)
            //        .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<OrderItem>(builder =>
            //{
            //    builder.HasKey(x => x.Id);

            //    builder.Property(x => x.Quantity)
            //        .HasDefaultValue(1)
            //        .IsRequired();

            //    builder.Property(x => x.Price)
            //        .IsRequired();

            //    builder.Property(x => x.Discount)
            //        .IsRequired();
            //});

            // CAN BE ANY CLASS IN ASSEMBLY
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            SetDefaultValueForStringProperties(modelBuilder);
        }

        private static void SetDefaultValueForStringProperties(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var properties =
                    entity.GetProperties().Where(x => x.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    {
                        // This property do not sets type
                        //property.SetMaxLength(100);
                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }
    }
}
