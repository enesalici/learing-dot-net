using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrates.EntityFramework
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=EXAMPLE; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //MODEL ÖZELLİKLERİ
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasOne(p => p.Category);
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("Name").HasMaxLength(50);

            //seed data sahte veri
            Category category1 = new Category(100, "giyimsel");
            Category category2 = new Category(200, "elektronik");

            Product product1 = new Product(1,"tüşört", "açıklama", 500, 50, 100);

            modelBuilder.Entity<Category>().HasData(category1, category2);
            modelBuilder.Entity<Product>().HasData(product1);



            base.OnModelCreating(modelBuilder);
        }


    }
}
