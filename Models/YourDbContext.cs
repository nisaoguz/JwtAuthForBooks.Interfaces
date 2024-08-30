

using JwtAuthForBooks.Controllers;
using Microsoft.EntityFrameworkCore;
using JwtAuthForBooks.Models;
using JwtAuthForBooks.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JwtAuthForBooks.Models
{
    //public class YourDbContext : DbContext
    //{
         public class YourDbContext : IdentityDbContext<IdentityUser>
    {
            public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<BookInformations> BookInformations { get; set; }

    }

}
