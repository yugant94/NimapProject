namespace NimapProject.Migrations
{
    using NimapProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NimapProject.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate(
                c => c.CategoryId,
                new Category { CategoryId = 1, CategoryName = "Electronics" },
                new Category { CategoryId = 2, CategoryName = "Clothing" },
                new Category { CategoryId = 3, CategoryName = "Home Appliances" }
            );

            context.Products.AddOrUpdate(
                p => p.ProductId,
                new Product { ProductId = 1, ProductName = "Laptop", CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "Smartphone", CategoryId = 1 },
                new Product { ProductId = 3, ProductName = "T-Shirt", CategoryId = 2 }
            );

            context.SaveChanges();
        }

    }
}
