using BookStoreServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace BookStoreServer.WebApi.Context;

public sealed class AppDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=CAGLA\\SQLEXPRESS;Initial Catalog=YMYP_BookStoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); // SqlConneciton conneciton = new("");
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
        }); //Value Object

        modelBuilder.Entity<BookCategory>().HasKey(p => new { p.BookId, p.CategoryId });  //Composite Key










    }
}
