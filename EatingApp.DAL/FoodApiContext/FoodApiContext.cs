using EatingApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EatingApp.DAL
{
    public class FoodApiContext : DbContext
    {
       
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        public FoodApiContext(DbContextOptions<FoodApiContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>(entity =>
                {
                    entity.HasOne(p => p.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.ProductTypeId);

                    entity.Property(e => e.Id).ValueGeneratedOnAdd();
                });

            modelBuilder
               .Entity<OrderItem>(entity =>
               {
                   entity.HasOne(p => p.Product)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(p => p.ProductId);

                   entity.Property(e => e.Id).ValueGeneratedOnAdd();
               });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(e => e.User)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(e => e.Order)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.OrderId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<User>().HasData(new User() { Id = 1, FirstName = "Admin", LastName = "Admin" });
            modelBuilder.Entity<ProductType>().HasData(new ProductType() { Id = 1, Name = "Kebab" }, new ProductType() { Id = 2, Name = "Pizza" }, new ProductType() { Id = 3, Name = "Sushi" });
        }
    }
}
