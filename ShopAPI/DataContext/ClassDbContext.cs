using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI.DataContext
{
    public class ClassDbContext : IdentityDbContext
    {
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        {




        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public  DbSet<AppUser> AppUsers { get; set; }

    }


}
