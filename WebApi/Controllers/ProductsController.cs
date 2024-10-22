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


        [HttpGet("category/{id}")]
        public IActionResult GetProductsByCategory(int id)
        {
            var products = _dataService.GetProductByCategory(id);

            if (products == null || !products.Any())
            {
                return NotFound();
            }

            var model = CreateProductModel(products);

            return Ok(model);
        }

        private List<ProductModel> CreateProductModel(List<ProductWithCategoryName> products)
        {
            if (products == null)
            {
                return null;
            }

            var model = products.Adapt<List<ProductModel>>();

            return model;
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

