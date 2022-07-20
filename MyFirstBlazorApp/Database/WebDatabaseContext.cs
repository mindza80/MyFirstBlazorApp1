using Microsoft.EntityFrameworkCore;
using MyFirstBlazorApp.Database.Entities;

namespace MyFirstBlazorApp.Database
{
    public class WebDatabaseContext : DbContext
    {
        private IConfiguration _configuration;

        public WebDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<BlazorUser> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration is not null)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("WebConnection"));
            }
        }

    }
}
