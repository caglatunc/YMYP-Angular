using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreServer.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class OrdersController : Controller
{
   private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}")]
    public IActionResult GetAllByUserId(int userId)
    {
        List<OrderListDto> orders =
            _context.Orders
            .Where(p => p.UserId == userId)
            .Include(p=> p.Book)
            .AsNoTracking()
            .Select(s => new OrderListDto()
            {
                Id = s.Id,
                Raiting = s.Raiting,
                Book = s.Book,
                Comment = s.Comment,
                CreatedAt = s.CreatedAt,
                OrderNumber = s.OrderNumber,
                PaymentDate = s.PaymentDate,
                PaymentNumber = s.PaymentNumber,
                PaymentType = s.PaymentType,
                Price = s.Price,
                Quantity = s.Quantity,
                OrderStatuses =_context.OrderStatuses.Where(p=>p.OrderNumber==s.OrderNumber).ToList()
            })
            .OrderByDescending(p => p.CreatedAt)
            .ToList();

        return Ok(orders);
    }
}
