namespace DataLayer;
public class Order
{
    public int Id { get; set; } = 0;
    public DateTime Date { get; set; } = DateTime.MinValue;
    public DateTime? Required { get; set; } = DateTime.MinValue;
    public DateTime? Shipped { get; set; } = DateTime.MinValue;
    public int? Freight { get; set; } = 0;
    public string? ShipName { get; set; }
    public string? ShipCity { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; }


}


