using DataLayer;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.Product;

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

            var model = CreateProductListModel(products);

            return Ok(model);
        }
    

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    
    {
        var product = _dataService.GetProduct(id);

        if (product == null)
        {
            return NotFound();
        }

        var model = CreateProductModel(product);

        return Ok(model);
    }
    
    [HttpGet]
    public IActionResult GetProductsByName([FromQuery] string name)
    {
        var products = _dataService.GetProductByName(name);

        if (products == null || !products.Any())
        {
            return NotFound(); 
        }

        var model = CreateProductNameAndCategoryModel(products);
        return Ok(model);
    }


    private List<ProductModel> CreateProductListModel(List<ProductWithCategoryName> products)
    {
        if (products == null)
        {
            return null;
        }

        var model = products.Adapt<List<ProductModel>>();

        return model;
    }

    private ProductModel? CreateProductModel(ProductWithCategoryName? product)
    {
        if(product == null)
        {
            return null;
        }

        return product.Adapt<ProductModel>();
    }

    private List<ProductNameAndCategoryModel> CreateProductNameAndCategoryModel(List<ProductWithNameAndCategoryOnly> products)
    {
        if (products == null)
        {
            return null;
        }

        return products.Select(product => new ProductNameAndCategoryModel
        {
            Name = product.ProductName,
            Category = product.CategoryName
        }).ToList();
    }

}

