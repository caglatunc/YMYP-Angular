namespace BookStoreServer.WebApi.Models;

public sealed class BookCategory
{
    public int id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int CategoryId { get; set; }
}
