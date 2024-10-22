namespace WebApi.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}