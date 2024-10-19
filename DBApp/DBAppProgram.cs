
using DataLayer;
var dataservice = new DataService();

//PrintCategories(dataservice);
//PrintProducts(dataservice);
GetOrderDetailsByProductId(dataservice);

static void PrintProducts(IDataService dataService)
{
    foreach (var e in dataService.GetProducts())
    {
        Console.WriteLine($"{e.Id}, {e.Name}, {e.Category.Name}");
    }
}

static void PrintCategories(IDataService dataService)
{
    foreach (var e in dataService.GetCategories())
    {
        Console.WriteLine($"{e.Id}, {e.Name}, {e.Description}");
    }
}

static void GetOrderDetailsByOrderId(IDataService dataService)
{
    var e = dataService.GetOrderDetailsByOrderId(10248);
    if (e != null)
    {
        foreach (var orderDetail in e)
        {
            Console.WriteLine($"OrderID: {orderDetail.OrderId}, Product: {orderDetail.Product.Name}, Quantity: {orderDetail.Quantity}");
        }
    }
}

static void GetOrderById(IDataService dataService)
{
    var e = dataService.GetOrder(10248);
    if (e != null)
    {
        Console.WriteLine($"OrderID: {e.Id}, Date: {e.Date}, Require: {e.Required}, ShipName: {e.ShipName}, ShipDate: {e.Shipped}");
        foreach (var orderDetail in e.OrderDetails)
        {
            Console.WriteLine($"OrderID: {orderDetail.OrderId}, Product: {orderDetail.Product.Name}, Quantity: {orderDetail.Quantity}");
        }
    }
}


static void GetOrderDetailsByProductId(IDataService dataService)
{
    var e = dataService.GetOrderDetailsByProductId(11);

    if(e != null)
    {
        foreach(var orderDetail in e)
        {
            Console.WriteLine($"OrderID: {orderDetail.OrderId}, Product: {orderDetail.Product.Name}, Quantity: {orderDetail.Quantity}");
        }
    }

}
