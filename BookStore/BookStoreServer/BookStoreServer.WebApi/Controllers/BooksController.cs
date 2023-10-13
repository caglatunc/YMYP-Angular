using BookStoreServer.WebApi.Dtos;
using BookStoreServer.WebApi.Models;
using GSF.FuzzyStrings;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BookStoreServer.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BooksController : ControllerBase
{
    public BooksController()
    {  
    }
    [HttpPost] // Methodun tipi 

    public IActionResult GetAll(RequestDto request)
    {
        ResponseDto<List<Book>> response = new();
       // string replaceSearch = request.Search.Replace("İ", "i").ToLower();
        var newBooks = new List<Book>();//Boş bir liste oluşturdum

        if (request.CategoryId != null) //
        {
            newBooks = SeedData.BookCategories
           .Where(p => p.CategoryId == request.CategoryId)
           .Select(s => s.Book)
           .ToList();
        }
        else
        {
            newBooks = SeedData.Books;//Tüm kitapları göndermek istersem, CategoryId göndermiycem null göndericem. Kategorisiz arama yapacaksam, Books dan yapıcam.Kategorisiz arama için bana lazım olan liste.
        }
       
        if (!string.IsNullOrEmpty(request.Search))
        {
            newBooks = newBooks
           .Where(p => p.Title.ApproximatelyEquals(request.Search, FuzzyStringComparisonOptions.UseJaccardDistance, FuzzyStringComparisonTolerance.Strong) ||
            p.Author.ApproximatelyEquals(request.Search, FuzzyStringComparisonOptions.UseJaccardDistance, FuzzyStringComparisonTolerance.Strong) ||
            p.ISBN.ApproximatelyEquals(request.Search, FuzzyStringComparisonOptions.UseJaccardDistance, FuzzyStringComparisonTolerance.Strong))

        .ToList();
        }

        

        response.Data = newBooks
        .Skip((request.PageNumber - 1) * request.PageSize)
        .Take(request.PageSize)
        .ToList();

        response.PageNumber = request.PageNumber;
        response.PageSize = request.PageSize;
        response.TotalPageCount = (int)Math.Ceiling(newBooks.Count / (double)request.PageSize);
        response.IsFirstPage = request.PageNumber == 1;
        response.IsLastPage = request.PageNumber == response.TotalPageCount;

        return Ok(response);
    }
}
public static class SeedData
{
    public static List<Book> Books = new();
    public static List<Category> Categories = new();
    public static List<BookCategory> BookCategories = new();
}





    