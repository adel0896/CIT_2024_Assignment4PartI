using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer;

public class OrderDetails
{
    public string UnitPrice { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int Discount { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Order Order { get; set; } 
    public Product Product { get; set; }

}
