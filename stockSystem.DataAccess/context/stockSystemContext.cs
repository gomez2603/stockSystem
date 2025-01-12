using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using stockSystem.DataAccess.Models;
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
            builder.ApplyConfiguration(new userSeed());

            builder.Entity<SalesDetail>()
                .HasKey(sd => new {sd.SalesId, sd.ProductId});

            builder.Entity<SalesDetail>()
                .HasOne(s => s.Sales).
                WithMany(sd => sd.SalesDetails)
                .HasForeignKey(sd => sd.SalesId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SalesDetail>()
              .HasOne(p => p.Products).
              WithMany(sd => sd.SalesDetails)
              .HasForeignKey(sd => sd.ProductId)
               .OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<SalesDetail>().ToTable("SalesDetails");

        }
    }
}
