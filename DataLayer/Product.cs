using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UnitPrice { get; set; }
    public string QuantityPerUnit { get; set; }
    public int UnitsInStock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; }


}

public class ProductWithNameAndCategoryOnly

{

    public string ProductName { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;
}

public class ProductWithCategoryName : Product
{
    public string CategoryName { get; set; } = string.Empty;
}
