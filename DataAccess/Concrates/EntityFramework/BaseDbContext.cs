using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrates.EntityFramework
{
    public class BaseDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=ENESDB; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
