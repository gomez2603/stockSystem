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


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetail> SalesDetail { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Category> Category { get; set; }

        public stockSystemContext(DbContextOptions<stockSystemContext> options) : base(options)
        {

            

            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreator != null)
                {
                    if (!dbCreator.CanConnect())
                        dbCreator.Create();
                    if (!dbCreator.HasTables())
                        dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RolSeed());
            builder.ApplyConfiguration(new userSeed());
            builder.ApplyConfiguration(new CategorySeed());
            builder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

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
