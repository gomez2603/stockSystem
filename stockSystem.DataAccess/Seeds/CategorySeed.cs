using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stockSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.DataAccess.Seeds
{
    public class CategorySeed :IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category() { id = 1, name = "Alimento" },
                new Category() { id = 2, name = "Ropa" },
                new Category() { id = 3, name = "Juguetes" }

                );
        }

        
    }
}
