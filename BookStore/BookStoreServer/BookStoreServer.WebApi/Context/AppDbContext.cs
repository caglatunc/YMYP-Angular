using BookStoreServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace BookStoreServer.WebApi.Context;

public sealed class AppDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=CAGLA\\SQLEXPRESS;Initial Catalog=YMYP_TodoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); // SqlConneciton conneciton = new("");
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }

    public DbSet<BookCategory> BookCategories { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().OwnsOne(p => p.Price, price =>
        {
            price.Property(p => p.Value).HasColumnType("money");
            price.Property(p => p.Currency).HasMaxLength(5);
        });//Value Object

        modelBuilder.Entity<BookCategory>().HasKey(p => new { p.BookId, p.CategoryId });
        //Composite Key

        //Domain Driven Design
        //Value Object

      //Note:Value Object kullanıyorsak Seed Data yapamıyoruz.
       // #region Seed Data
        //List<Category> categories = new();
        //for (int i = 0; i < 10; i++)
        //{
        //    var category = new Category()
        //    {
        //        Id = i + 1,
        //        Name = $"Category {i + 1}",
        //        IsActive = true,
        //        IsDeleted = false,
        //    };

        //    categories.Add(category);
        //}



        //modelBuilder.Entity<Category>().HasData(categories);

        //List<Book> books = new();
        //for (int i = 0; i < 100; i++)
        //{
        //    var book = new Book()
        //    {
        //        Id = i + 1,
        //        Title = $"Book {i + 1}",
        //        Author = $"Author {i + 1}",
        //        ISBN = $"ISBN {i + 1}",
        //        IsActive = true,
        //        IsDeleted = false,
        //        Price = new(i*10,"₺"),
        //        Quantity = 10,
        //        Summary = $"Summary {i + 1}",
        //        CoverImageUrl = $"https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", // BU DEĞİŞECEK
        //        CreateAt = DateTime.Now
        //    };

        //    books.Add(book);
        //}

        //modelBuilder.Entity<Book>().HasData(books);

        //List<BookCategory> bookCategories = new();
        //foreach (var book in books)
        //{
        //    var bookCategory = new BookCategory()
        //    {
        //        BookId = book.Id,
        //        CategoryId = categories[new Random().Next(0, 10)].Id
        //    };
        //    bookCategories.Add(bookCategory);
        //}
        //modelBuilder.Entity<BookCategory>().HasData(bookCategories);

        //#endregion





    }
}
