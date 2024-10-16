
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class DataService : IDataService
{
    //public int AddCategory(string name, string description)
    //{
    //    throw new NotImplementedException();
    //}

    public IList<Category> GetCategories()
    {
        var db = new NortwindContext();
        return db.Categories.ToList();
    }

    public IList<Product> GetProducts()
    {
        var db = new NortwindContext();
        return db.Products.Include(x => x.Category).ToList();
    }

    public Order? GetOrderById(int Id)
    {
        var db = new NortwindContext();
        return db.Orders.Find(Id);
    }
}
