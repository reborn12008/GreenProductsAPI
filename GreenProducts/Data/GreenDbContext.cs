using GreenProducts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProducts.Data
{
    public class GreenDbContext : DbContext
    {
        public GreenDbContext(DbContextOptions<GreenDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Supermarket> Supermarkets { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Supermarket_Product> Supermarket_Products { get; set; }

        public virtual DbSet<ImpactCategory> ImpactCategories { get; set; }
    }
}
