using DataLayer;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    IDataService _dataService;

    public CategoriesController(
        IDataService dataService
        )
    {
        _dataService = dataService;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = _dataService
            .GetCategories()
            .Select(CreateCategoryModel);
        return Ok(categories);
    }

    [HttpGet("{id}", Name = nameof(GetCategory))]
    public IActionResult GetCategory(int id)
    {
        var category = _dataService.GetCategory(id);

        if (category == null)
        {
            return NotFound();
        }
        var model = CreateCategoryModel(category);

        return Ok(model);
    }

    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryModel model)
    {
        var category = _dataService.CreateCategory(model.Name, model.Description??string.Empty);
        return Ok(CreateCategoryModel(category));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var result = _dataService.DeleteCategory(id);

        if (result)
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, UpdateCategoryModel model)
    {
        var category = _dataService.GetCategory(id);

        if(category == null)
        {
            return NotFound();
        }

        

        category.Name = model.Name;
        category.Description = model.Description;


        _dataService.UpdateCategory(id, model.Name, model.Description??string.Empty);

        return NoContent();
    }



    private CategoryModel? CreateCategoryModel(Category? category)
    {
        if(category == null)
        {
            return null;
        }

        var model = category.Adapt<CategoryModel>();

        return model;
    }

    
}