using Microsoft.EntityFrameworkCore;

namespace SalesAPI.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Purchase)
                .WithOne(i => i.Product)
                .HasForeignKey<Purchase>(p => p.ProductId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(p => p.Purchase)
                .WithOne(i => i.User)
                .HasForeignKey<Purchase>(p => p.ProductId)
                .IsRequired();
        }

        public DbSet<Purchase> Purchases { get; set; }
    }
}
