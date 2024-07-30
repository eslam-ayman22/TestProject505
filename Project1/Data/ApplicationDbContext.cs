using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{
    public class ApplicationDbContext :DbContext
    {
           public DbSet<Models.Product> products  { get; set; }
           public DbSet<Models.Category> categorys { get; set; }
           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connection = builder.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
