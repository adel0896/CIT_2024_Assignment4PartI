using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer;
internal class NortwindContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

        string Host = "localhost";
        string Db = "nortwind";
        string Uid = "postgres";
        string Pwd = "13041968AdeStefi@";
        string ConnectionString = $"host={Host};db={Db};uid={Uid};pwd={Pwd}";
        optionsBuilder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        MapCategories(modelBuilder);
        MapProducts(modelBuilder);
        MapOrders(modelBuilder);
        MapOrderDetails(modelBuilder);
    }

    private static void MapCategories(ModelBuilder modelBuilder)
    {
        // Categories
        modelBuilder.Entity<Category>().ToTable("categories");
        modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid").HasColumnType("int"); ;
        modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
        modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");
    }
    private static void MapProducts(ModelBuilder modelBuilder)
    {
        // Products
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
        modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("productname");
        modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("unitprice");
        modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");
        modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName("unitsinstock");
        modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");
    }

    private static void MapOrders(ModelBuilder modelBuilder)
    {
        // Orders
        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
        //this converstion here is neccessary because this is type date in the database, DateOnly in the entity and the framework does not support this
        modelBuilder.Entity<Order>()
            .Property(x => x.Date)
            .HasColumnName("orderdate");

        modelBuilder.Entity<Order>()
           .Property(x => x.Required)
           .HasColumnName("requireddate");

        modelBuilder.Entity<Order>()
          .Property(x => x.Shipped)
          .HasColumnName("shippeddate");
   
        modelBuilder.Entity<Order>().Property(x => x.Freight).HasColumnName("freight");
        modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname");
        modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");
    }

    private static void MapOrderDetails(ModelBuilder modelBuilder)
    {
        // Order Details
        modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
        // Configure the composite primary key (OrderId + ProductId)
        modelBuilder.Entity<OrderDetails>()
            .HasKey(od => new { od.OrderId, od.ProductId });
        modelBuilder.Entity<OrderDetails>().Property(x => x.OrderId).HasColumnName("orderid");
        //this converstion here is neccessary because this is type date in the database, DateOnly in the entity and the framework does not support this
        modelBuilder.Entity<OrderDetails>().Property(x => x.UnitPrice).HasColumnName("unitprice");
        modelBuilder.Entity<OrderDetails>().Property(x => x.Quantity).HasColumnName("quantity");
        modelBuilder.Entity<OrderDetails>().Property(x => x.Discount).HasColumnName("discount");
        modelBuilder.Entity<OrderDetails>().Property(x => x.ProductId).HasColumnName("productid");
    }
}