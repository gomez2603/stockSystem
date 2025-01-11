using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using StockSystem.dataAccess.Models;
using StockSystem.dataAccess.Seeds;


namespace StockSystem.dataAccess.context
{
    public class stockSystemContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
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

        }
    }
}
