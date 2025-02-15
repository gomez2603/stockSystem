﻿using Microsoft.EntityFrameworkCore;
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
                new Rol() { id = 1, name = "ADMIN" },
                new Rol() { id = 2, name = "SALESMAN" },
                new Rol() { id = 3, name = "STOCKER" }

                );
        }
    }
}
