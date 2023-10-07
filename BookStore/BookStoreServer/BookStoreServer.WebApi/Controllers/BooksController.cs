using BookStoreServer.WebApi.Dtos;
using BookStoreServer.WebApi.NewFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BooksController : ControllerBase
{
    private static List<Book> books = new()
    {
        new Book()
        {

        }
    };

    public BooksController()
    {
        for(int i = 0; i < 100; i++)
        {
            var book = new Book()
            {
                Id = i + 1,
                Title = $"Kitap {i + 1}" ,
                Author = "Yazar" + (i + 1),
                Summary = "",
                CoverImageUrl = "https://m.media-amazon.com/images/I/41BKx1AxQWL.jpg",
                CreateAt = DateTime.Now,
                IsActive = true,
                ISBN = "978-0321125217",
                Price = 5 * (i + 1),
                Quantity = i + 1
            };
            books.Add(book);
        }
    }

    [HttpGet("{pageNumber}/{pageSize}")] // Methodun tipi 

    public IActionResult GetAll(int pageNumber, int pageSize)
    {
        ResponseDto<List<Book>> response = new();

        response.Data = books
            .Skip((pageNumber-1) * pageSize)
            .Take(pageSize)
            .ToList();

        response.PageNumber = pageNumber;
        response.PageSize = pageSize;
        response.TotalPageCount = (int)Math.Ceiling(books.Count / (double)pageSize);
        response.IsFirstPage = pageNumber == 1;
        response.IsLastPage = pageNumber == response.TotalPageCount; 


        return Ok(response);
    }

}