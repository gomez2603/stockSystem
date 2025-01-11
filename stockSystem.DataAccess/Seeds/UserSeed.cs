using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSystem.dataAccess.Models;

namespace StockSystem.dataAccess.Seeds
{
 
        public class userSeed : IEntityTypeConfiguration<User>
        {

            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasData(
                    new User() { Id = 1, Name = "Admin" }
                    
                    );
            }
        }
    }

