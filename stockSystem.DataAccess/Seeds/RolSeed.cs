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
    public class RolSeed : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(
                new Rol() { Id = 1, Nombre = "ADMIN" },
                new Rol() { Id = 2, Nombre = "SALESMAN" },
                new Rol() { Id = 3, Nombre = "STOCKER" }

                );
        }
    }
}
