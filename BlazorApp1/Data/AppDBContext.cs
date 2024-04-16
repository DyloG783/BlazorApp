using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class AppDbContext : DbContext
    {
        public IConfiguration _config { get; set; }
        public AppDbContext(IConfiguration config) 
        { 
            _config = config;
        }

        // connection string currently defined in 'appsettings.json'
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DevelopmentDatabase"));
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
