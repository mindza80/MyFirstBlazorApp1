using Microsoft.EntityFrameworkCore;
using MyFirstServerSideBlazor.Database.Entities;

namespace MyFirstServerSideBlazor.Database
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
                var connectionString = _configuration.GetConnectionString("WebConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
