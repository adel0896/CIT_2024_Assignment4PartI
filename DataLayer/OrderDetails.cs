﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer;

public class OrderDetails
{
    public double UnitPrice { get; set; } = 0.0;
    public double Quantity { get; set; } = 0.0;
    public double Discount { get; set; } = 0.0;
    public int OrderId { get; set; } = 0;
    public int ProductId { get; set; } = 0;
    public Order? Order { get; set; }
    public Product? Product { get; set; }


  

}
