
//using BookStoreServer.WebApi.Context;
//using BookStoreServer.WebApi.Dtos;
//using BookStoreServer.WebApi.Models;
using Azure.Core;
using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Dtos;
using BookStoreServer.WebApi.Models;
using GSF.FuzzyStrings;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : ControllerBase
{

    [HttpPost]
    public IActionResult Create(CreateCategoryDto request)
    {
        AppDbContext context = new();
        var checkNameIsUnique = context.Categories.Any(p => p.Name == request.Name);
        if (checkNameIsUnique)
        {
            return BadRequest("Kategori adı daha önce kullanılmıştır.");
        }

        Category category = new()
        {
            Name = request.Name,
            IsActive = true,
            IsDeleted = false
        };

        
        context.Categories.Add(category);
        context.SaveChanges();
        return Ok(category);
    }

    [HttpGet("{id}")]
    public IActionResult RemoveById(int id)
    {
        AppDbContext context = new();
        Category category = context.Categories.Find(id);
        if (category == null) //Böle bir kategori yoksa hata fırlattırdım. 
        {
            return NotFound();
        }
        category.IsDeleted = true;
        context.SaveChanges();
        return NoContent();
    }

    [HttpPost]
    public IActionResult Update(UpdateCategoryDto request)
    {
        AppDbContext context = new();
        Category category = context.Categories.Find(request.Id);
        if(category == null)
        {
            return NotFound();
        }
        category.Name = request.Name;
        context.SaveChanges();
        return NoContent();
    }



    [HttpGet]
    public IActionResult GetAll()
    {
        AppDbContext context = new();//connection açtım.

        var categories = context.Categories
            .Where(p=> p.IsActive == true && p.IsDeleted == false)
            .OrderBy(o=> o.Name)
            .ToList();  //Select*From Categories Where IsActive = 1 and IsDeleted = 0 Order By Name

        return Ok(categories);
    }
}


