using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using stockSystem.DataAccess.Models;
using stockSystem.DataAccess.Seeds;
using StockSystem.dataAccess.Models;
using StockSystem.dataAccess.Seeds;
using System.Reflection.Emit;


namespace StockSystem.dataAccess.context
{
    public class stockSystemContext : DbContext
    {


        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetail> SalesDetail { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Category> Category { get; set; }

        public stockSystemContext(DbContextOptions<stockSystemContext> options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RolSeed());
            builder.ApplyConfiguration(new userSeed());
            builder.ApplyConfiguration(new CategorySeed());
            builder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

            builder.Entity<Product>()
       .Property(p => p.price)
       .HasComputedColumnSql("[Cost]  * (1 + [Margin])");

            builder.Entity<Stock>()
          .HasIndex(s => new { s.WarehouseId, s.ProductId })
          .IsUnique(); 

            builder.Entity<Stock>()
                .Property(s => s.Quantity)
                .HasColumnType("decimal(10,3)");

            builder.Entity<SalesDetail>()
                .HasKey(sd => new {sd.salesId, sd.productId});

            builder.Entity<SalesDetail>()
                .HasOne(s => s.sales).
                WithMany(sd => sd.salesDetails)
                .HasForeignKey(sd => sd.salesId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SalesDetail>()
              .HasOne(p => p.products).
              WithMany(sd => sd.salesDetails)
              .HasForeignKey(sd => sd.productId)
               .OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<SalesDetail>().ToTable("SalesDetails");

        }
    }
}
