using GreenProducts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProductsAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProducts.Data
{
    public class GreenDbContext : IdentityDbContext<ApplicationUser>
    {
        public GreenDbContext(DbContextOptions<GreenDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Supermarket> Supermarkets { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Supermarket_Product> Supermarket_Products { get; set; }

        public virtual DbSet<ImpactCategory> ImpactCategories { get; set; }
    }
}
