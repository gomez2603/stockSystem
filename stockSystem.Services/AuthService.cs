using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using stockSystem.Services.Interfaces;
using StockSystem.dataAccess.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace stockSystem.Services
{
    public class AuthService:IAuthService
    {

        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.UserData,user.Username),
                   new Claim("id",user.Id.ToString()),
               new Claim(ClaimTypes.Role,user.Rol.name)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }



        public bool isSameUser(ClaimsIdentity claimsIdentity, int userid)
        {
            try
            {
                if (claimsIdentity.Claims.Count() == 0)
                {

                    return false;
                }
                var tokenid = claimsIdentity.Claims.FirstOrDefault(x => x.Type == "id").Value;
                if (userid.ToString().Equals(tokenid))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool VerifyPassword(string Password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHAsh = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));
                return computedHAsh.SequenceEqual(passwordHash);
            }
        }
    }
}
