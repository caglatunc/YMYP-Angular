using BookStoreServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace BookStoreServer.WebApi.Context;

public sealed class AppDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Data Source=CAGLA\\SQLEXPRESS;Initial Catalog=YMYP_BookStoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); // SqlConneciton conneciton = new("");
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=admin;Database=BookStoreDb");
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShoppingCart>().OwnsOne(p => p.Price, price =>
        {
            price.Property(p => p.Value).HasColumnType("money");
            price.Property(p => p.Currency).HasMaxLength(5);
        });
        modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique(); //Unique Index

        modelBuilder.Entity<User>().HasIndex(p => p.Username).IsUnique(); //Unique Index

        modelBuilder.Entity<OrderStatus>().HasIndex(p=> new{ p.Status, p.OrderNumber}).IsUnique(); //Unique Index

        modelBuilder.Entity<Book>().OwnsOne(p => p.Price, price =>
        {
            price.Property(p => p.Value).HasColumnType("money");
            price.Property(p => p.Currency).HasMaxLength(5);
        }); //Value Object

        modelBuilder.Entity<Order>().OwnsOne(p => p.Price, price =>
        {
            price.Property(p => p.Value).HasColumnType("money");
            price.Property(p => p.Currency).HasMaxLength(5);
        });

        modelBuilder.Entity<BookCategory>().HasKey(p => new { p.BookId, p.CategoryId });  //Composite Key

        modelBuilder.Entity<Category>().HasData( //Seed Data
            new Category { Id = 1, Name = "Horror", IsActive = true, IsDeleted = false },
            new Category { Id = 2, Name = "Science fiction", IsActive = true, IsDeleted = false },
            new Category { Id = 3, Name = "History", IsActive = true, IsDeleted = false },
            new Category { Id = 4, Name = "Literature", IsActive = true, IsDeleted = false },
            new Category { Id = 5, Name = "Child", IsActive = true, IsDeleted = false },
            new Category { Id = 6, Name = "Psychology", IsActive = true, IsDeleted = false },
            new Category { Id = 7, Name = "Religion", IsActive = true, IsDeleted = false },
            new Category { Id = 8, Name = "Philosophy", IsActive = true, IsDeleted = false },
            new Category { Id = 9, Name = "Science", IsActive = true, IsDeleted = false },
            new Category { Id = 10, Name = "Art", IsActive = true, IsDeleted = false },
            new Category { Id = 11, Name = "Sport", IsActive = true, IsDeleted = false },
            new Category { Id = 12, Name = "Travel", IsActive = true, IsDeleted = false },
            new Category { Id = 13, Name = "Magazine", IsActive = true, IsDeleted = false },
            new Category { Id = 14, Name = "Humor", IsActive = true, IsDeleted = false },
            new Category { Id = 15, Name = "Personal development", IsActive = true, IsDeleted = false },
            new Category { Id = 16, Name = "Food", IsActive = true, IsDeleted = false },
            new Category { Id = 17, Name = "Hobby", IsActive = true, IsDeleted = false },
            new Category { Id = 18, Name = "Reference", IsActive = true, IsDeleted = false },
            new Category { Id = 19, Name = "Education", IsActive = true, IsDeleted = false });
    }
}
