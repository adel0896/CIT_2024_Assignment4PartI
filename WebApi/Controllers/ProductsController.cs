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



}

