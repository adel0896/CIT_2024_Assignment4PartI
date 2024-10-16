namespace DataLayer;
public class Order
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly Require { get; set; } 
    public DateOnly Shipped { get; set; }
    public int Freight { get; set; }
    public string ShipName { get; set; } = string.Empty;
    public string ShipCity { get; set; } = string.Empty;
    public ICollection<OrderDetails> OrderDetails { get; set; }
}
