namespace SMS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SMS.Data.Models;

    // ReSharper disable once InconsistentNaming
    public class SMSDbContext : DbContext
    {
        public SMSDbContext()
        {
            
        }

        public DbSet<User> Users { get; init; }

        public DbSet<Product> Products { get; init; }

        public DbSet<Cart> Carts { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}