using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSystem.dataAccess.Models;
using System.Security.Cryptography;

namespace StockSystem.dataAccess.Seeds
{
 
        public class userSeed : IEntityTypeConfiguration<User>
        {

            public void Configure(EntityTypeBuilder<User> builder)
            {
            using var hmac = new HMACSHA512();
       
                builder.HasData(
                    new User() { Id = 1, Name = "Super",LastName ="Admin", Username="admin", PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin1234")), PasswordSalt = hmac.Key,RolId=1 }
                    
                    );
            }
        }
    }

