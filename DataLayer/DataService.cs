
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace DataLayer;

public class DataService : IDataService
{
    //public int AddCategory(string name, string description)
    //{
    //    throw new NotImplementedException();
    //}

    public  List<Category> GetCategories()
    {
        var db = new NortwindContext();
        return db.Categories.ToList();
    }

    public  List<Product> GetProducts()
    {
        var db = new NortwindContext();
        return db.Products.Include(x => x.Category).ToList();
    }

    public Order? GetOrder(int Id)
    {
        var db = new NortwindContext();
        return db.Orders
              .Include(x => x.OrderDetails)
              .ThenInclude(od => od.Product)
              .ThenInclude(odp => odp.Category)
              .FirstOrDefault(x => x.Id == Id);
    }

    public List<Order> GetOrders()
    {
        var db = new NortwindContext();
        return db.Orders
              .Include(x => x.OrderDetails)
              .ThenInclude(od => od.Product)
              .ToList();
    }

    public Order? GetOrderByShippingName(string ShipName)
    {
        var db = new NortwindContext();
        return db.Orders
             .Include(x => x.OrderDetails)
              .FirstOrDefault(x => x.ShipName == ShipName);
    }

    public List<OrderDetails> GetOrderDetailsByOrderId(int OrderId)
    {
        var db = new NortwindContext();
        return db.OrderDetails
              .Include(x => x.Product)
              .ThenInclude(odp => odp.Category)
              .Where(x => x.OrderId == OrderId).ToList();
    }

    public List<OrderDetails> GetOrderDetailsByProductId(int ProductId)
    {
        var db = new NortwindContext();

        return db.OrderDetails
              .Include(x => x.Product)
              .Include(x => x.Order)
              .Where(x => x.ProductId == ProductId)
              .OrderBy(x => x.OrderId)
              .ThenBy(x => x.Order.Date)
              .ToList();
    }

    public ProductWithCategoryName? GetProduct(int ProductId)
    {
        var db = new NortwindContext();

        ProductWithCategoryName productWithCategoryName;

        Product product = db.Products
            .Include(x => x.Category)
            .FirstOrDefault(x => x.Id == ProductId);

        if (product != null)
        {
            productWithCategoryName = new ProductWithCategoryName
            {
                Id = product.Id,
                Name = product.Name,
                UnitPrice = product.UnitPrice,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitsInStock = product.UnitsInStock,
                CategoryName = product.Category?.Name
            };
        }

        else
        {
           productWithCategoryName = new ProductWithCategoryName();
        }

        return productWithCategoryName;

    }

    public List<ProductWithCategoryName> GetProductByCategory(int CategoryId)
    {
        var db = new NortwindContext();
        
        List<ProductWithCategoryName> productsWithCategoryName = new List<ProductWithCategoryName>();

        List<Product> products= db.Products
            .Include(x => x.Category)
            .Where(x => x.CategoryId == CategoryId)
            .ToList();

        products.ForEach(product =>
        {
            productsWithCategoryName.Add(new ProductWithCategoryName
            {
                Id = product.Id,
                Name = product.Name,
                UnitPrice = product.UnitPrice,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitsInStock = product.UnitsInStock,
                CategoryName = product.Category?.Name
            });
        });

        return productsWithCategoryName;
    }

    public List<ProductWithNameAndCategoryOnly> GetProductByName(string substring)
    {
        var db = new NortwindContext();

        List<Product> products = db.Products
            .Include(x => x.Category)
            .Where(x => x.Name.Contains(substring))
            .ToList();

        List<ProductWithNameAndCategoryOnly> ProductsWithNamesOnly = new List<ProductWithNameAndCategoryOnly>();


        products.ForEach(product =>
        {
            ProductsWithNamesOnly.Add(new ProductWithNameAndCategoryOnly
            {
                ProductName = product.Name,
                CategoryName = product.Category.Name 
            });
        });

        return ProductsWithNamesOnly;
}

    public Category? GetCategory(int CategoryId)
    {
        var db = new NortwindContext();
        return db.Categories.FirstOrDefault(x => x.Id == CategoryId);
    }

    public Category CreateCategory(string name, string description)
    {
        var db = new NortwindContext();

        int id = db.Categories.Max(x => x.Id) + 1;
        var category = new Category
        {
            Id = id,
            Name = name,
            Description = description
        };

        db.Categories.Add(category);

        db.SaveChanges();

        return category;

    }

    public bool DeleteCategory(int id)
    {
        var db = new NortwindContext();

        var category = db.Categories.Find(id);

        if (category == null)
        {
            return false;
        }

        db.Categories.Remove(category);

        return db.SaveChanges() > 0;

    }

    public bool UpdateCategory(int id, string name, string description)
    {
        var db = new NortwindContext();

        var category = db.Categories.Find(id);

        if (category == null)
        {
            return false;
        }

        category.Name = name;
        category.Description = description;

        db.Categories.Update(category);

        return db.SaveChanges() > 0;

    }


}
