using StockSystem.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Services.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(User user);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPassword(string Password, byte[] passwordHash, byte[] passwordSalt);

    }
}
