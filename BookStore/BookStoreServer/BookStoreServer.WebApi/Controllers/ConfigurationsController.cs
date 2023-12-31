﻿using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ConfigurationsController : ControllerBase
{
    private readonly AppDbContext context = new();

    [HttpGet]
    public IActionResult SeedData()
    {
        List<Book> books = new();
        for (int i = 0; i < 10000; i++)
        {
            var book = new Book()
            {
                Title = $"Book {i}",
                Author = $"Author {i}",
                Summary = $"Lorem ipsum dolor sit amet consectetur adipisicing elit. Laudantium facere porro vitae quas! Nam, iure? Incidunt, delectus reprehenderit quo est quae praesentium similique minus aliquid voluptates expedita dolorem nisi provident!",
                CoverImageUrl = $"https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg",
                Price = new(i * 2, "₺"),
                Quantity = i * 1,
                IsActive = true,
                IsDeleted = false,
                ISBN = $"ISBN {i}",
                CreateAt = DateTime.UtcNow
            };
            books.Add(book);
        }
        context.Books.AddRange(books);
        context.SaveChanges();

        List<Category> categories = context.Categories.ToList(); //Kategori listemi alıyorum.

        List<BookCategory> bookCategories = new();
        foreach (var book in books)
        {
            var bookCategory = new BookCategory()
            {
                BookId = book.Id,
                CategoryId = categories[new Random().Next(0, categories.Count)].Id
            };
            bookCategories.Add(bookCategory);
        }
        context.BookCategories.AddRange(bookCategories);

        context.SaveChanges();

        return NoContent();
    }
}
