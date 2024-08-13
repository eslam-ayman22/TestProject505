using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{
    public class ApplicationDbContext :DbContext
    {
           public DbSet<Models.Product> products  { get; set; }
           public DbSet<Models.Category> categorys { get; set; }

           public DbSet<Models.Company> companys { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public ApplicationDbContext()
        {
            
        }

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
