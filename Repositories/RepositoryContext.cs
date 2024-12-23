using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoryContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>()
            .HasData(
            new Product() { ProductId = 1, ProductName = "computer", Price = 18_000 },
            new Product() { ProductId = 2, ProductName = "klavye", Price = 20_000 },
            new Product() { ProductId = 3, ProductName = "fare", Price = 30_000 },
            new Product() { ProductId = 4, ProductName = "ekran", Price = 50_000 },
            new Product() { ProductId = 5, ProductName = "deck", Price = 17_000 }

            );

        modelBuilder.Entity<Category>()
            .HasData(
            new Category() { CategoryId = 1, CategoryName ="Meyve"},
            new Category() { CategoryId = 2, CategoryName = "Sebze" }
            );

    }

}