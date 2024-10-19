using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataService
    {
        List<Category> GetCategories();
        //int AddCategory(string name, string description);
        List<Product> GetProducts();
        Order? GetOrder(int id);

        List<Order> GetOrders();

        Order? GetOrderByShippingName(string ShipName);

        List<OrderDetails> GetOrderDetailsByOrderId(int OrderId);

        List<OrderDetails> GetOrderDetailsByProductId(int ProductId);

        ProductWithCategoryName? GetProduct(int ProductId);

        List<ProductWithCategoryName> GetProductByCategory(int CategoryId);

        List<ProductWithNameAndCategoryOnly> GetProductByName(string substring);

       Category? GetCategory(int CategoryId);

       Category CreateCategory(string name, string description);

       bool DeleteCategory(int id);

        bool UpdateCategory(int id, string name, string description);


    }
}
