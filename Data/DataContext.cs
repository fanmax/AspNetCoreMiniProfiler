using AspNetCoreMiniProfiler.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMiniProfiler.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Client> Clients { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ClientProduct> ClientProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.ConfigureClient(modelBuilder);
            this.ConfigureProduct(modelBuilder);
            this.ConfigureClientProduct(modelBuilder);

            this.Seed(modelBuilder);
        }

        private void ConfigureClientProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientProduct>()
                .HasKey(x => new { x.ClientId, x.ProductId });
            modelBuilder.Entity<ClientProduct>()
                .HasOne<Client>(x => x.Client)
                .WithMany(x => x.ClientProducts)
                .HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientProduct>()
                .HasOne<Product>(x => x.Product)
                .WithMany(x => x.ClientProducts)
                .HasForeignKey(x => x.ProductId);
        }

        private void ConfigureProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);
        }

        private void ConfigureClient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(x => x.Id);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "MacBook", Price = 1500 },
                new Product { Id = 2, Name = "Iphone", Price = 800 },
                new Product { Id = 3, Name = "Acer Predator Helios 300", Price = 999.99 },
                new Product { Id = 4, Name = "Acer SB220Q", Price = 89.99 },
                new Product { Id = 5, Name = "TP-Link AC1750 Smart Wifi Router", Price = 56.99 },
                new Product { Id = 6, Name = "Logitek MK270 Wireless Keyboard and Mouse", Price = 18.49 }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FirstName = "Will", LastName = "May" },
                new Client { Id = 2, FirstName = "James", LastName = "San" }
            );

            modelBuilder.Entity<ClientProduct>().HasData(
                new ClientProduct { ClientId = 1, ProductId = 1 },
                new ClientProduct { ClientId = 1, ProductId = 2 },
                new ClientProduct { ClientId = 1, ProductId = 5 },
                new ClientProduct { ClientId = 1, ProductId = 6 }
            );

            modelBuilder.Entity<ClientProduct>().HasData(
                new ClientProduct { ClientId = 2, ProductId = 2 },
                new ClientProduct { ClientId = 2, ProductId = 3 },
                new ClientProduct { ClientId = 2, ProductId = 5 },
                new ClientProduct { ClientId = 2, ProductId = 4 }
            );
        }
    }
}
