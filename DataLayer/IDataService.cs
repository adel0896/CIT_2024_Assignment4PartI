using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataService
    {
        IList<Category> GetCategories();
        //int AddCategory(string name, string description);
        IList<Product> GetProducts();
        Order? GetOrderById(int id);

    }
}
