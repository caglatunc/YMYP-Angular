using BookStoreServer.WebApi.NewFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

private static List<Book> books = new();

public BooksController()
{

    for (int i = 0; i < 100; i++)
    {
        var book = new Book()
        {
            Id = i + 1,
            Title = $"DDD {i + 1}",
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

[HttpGet]

public IActionResult GetAll()
{
    return Ok(books);
}

}