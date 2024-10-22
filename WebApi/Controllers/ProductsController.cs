using DataLayer;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/products")]

public class ProductsController : ControllerBase
{
    IDataService _dataService;

    public ProductsController(
        IDataService dataService
        )
    {
        _dataService = dataService;
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _dataService.GetProduct(id);

        if (product == null)
        {
            return NotFound();
        }

        var model = CraeteProductModel(product);

        return Ok(model);
    }

    private ProductModel? CraeteProductModel(ProductWithCategoryName? product)
    {
        if(product == null)
        {
            return null;
        }

        return product.Adapt<ProductModel>();
    }

}

