using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Dtos;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Bestsellers()
    {
        var bestsellers = _context.Orders
            .Where(o => o.PaymentDate != null)
            .GroupBy(o => o.BookId)
            .Select(s => new
            {
                BookId = s.Key,
                TotalQuantity = s.Sum(o => o.Quantity)
            })
            .OrderByDescending(s => s.TotalQuantity)
            .Take(8)
            .ToList();

        var bestsellerBooks = new List<BookDto>();
        var processedBookIds = new HashSet<int>();

        foreach (var bestseller in bestsellers)
        {


            if (!processedBookIds.Contains(bestseller.BookId))
            {

                var book = _context.Books.Find(bestseller.BookId);

                if (book != null)
                {
                    var bookDto = new BookDto 
                    {
                        Id = book.Id,
                        Title = book.Title,
                        CoverImageUrl = book.CoverImageUrl,
                     
                    };

                    var rating = _context.Orders 
                   .Where(p => p.BookId == book.Id && p.Raiting != null)
                   .Average(p => p.Raiting);

                    bookDto.Raiting = (short)(rating == null ? 0 : Convert.ToInt16(Math.Round((decimal)rating)));

                    bestsellerBooks.Add(bookDto);
                    processedBookIds.Add(bestseller.BookId);


                }
            }
        }
        return Ok(bestsellerBooks);
    }

 }

