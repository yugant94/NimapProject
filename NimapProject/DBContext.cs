using NimapProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NimapProject
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("con") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}