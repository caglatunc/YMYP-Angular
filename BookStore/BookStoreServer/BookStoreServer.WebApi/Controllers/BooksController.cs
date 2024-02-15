using AutoMapper;
using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Dtos;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookStoreServer.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public BooksController(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult GetAll(RequestDto request)
    {
       
        List<Book> books = new();
        if (request.CategoryId == null)
        {
            books = _context.Books
           .Where(p => p.IsActive == true && p.IsDeleted == false)
           .Where(p => p.Title.ToLower().Contains(request.Search.ToLower()) || p.ISBN.Contains(request.Search))//Kitabın isminden ,ISBN den arayabiliriz.
           .OrderByDescending(p => p.CreateAt)//Kayıt tarihine göre tersten sırala
           .Take(request.PageSize)
           .ToList();
        }
        else
        {   
            books = _context.BookCategories
               .Where(p => p.CategoryId == request.CategoryId)//Verdiğim kategori hangsi ie onun listesini al
               .Include(p => p.Book)//Arkasına bu kategoriye bağlı kitaplarımı getir.
               .Select(s => s.Book)//Bu kitapları bana seç.
               .Where(p => p.IsActive == true && p.IsDeleted == false)
               .Where(p => p.Title.ToLower().Contains(request.Search.ToLower()) || p.ISBN.Contains(request.Search))
               .OrderByDescending(p => p.CreateAt)
               .Take(request.PageSize)
               .ToList();

        }
        List<BookDto> requestDto = new();
        foreach (var book in books)
        {
            BookDto bookDto = _mapper.Map<BookDto>(book);
            bookDto.Categories = _context.BookCategories
                                .Where(p => p.BookId == book.Id)
                                .Include(p => p.Category)
                                .Select(s => s.Category.Name)
                                .ToList();
            var raiting = _context.Orders.Where(p => p.BookId == book.Id && p.Raiting != null).Average(p=> p.Raiting);
            bookDto.Raiting = (short)(raiting == null ? 0 : Convert.ToInt16(Math.Round((decimal)raiting)));

            //var bookDto = new BookDto()
            //{
            //    Title = book.Title,
            //    ISBN = book.ISBN,
            //    Id = book.Id,
            //    Author = book.Author,
            //    Categories =
            //        context.BookCategories
            //        .Where(p => p.BookId == book.Id)
            //        .Include(p => p.Category)
            //        .Select(s => s.Category.Name)
            //        .ToList(),
            //    CoverImageUrl = book.CoverImageUrl,
            //    CreateAt = book.CreateAt,
            //    IsActive = book.IsActive,
            //    IsDeleted = book.IsDeleted,
            //    Price = book.Price,
            //    Quantity = book.Quantity,
            //    Summary = book.Summary
            //};
            requestDto.Add(bookDto);
        }
        return Ok(requestDto);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _context.Books.Find(id);
        return Ok(book);
    }
}




    