using System.ComponentModel.DataAnnotations;

namespace stockSystem.Dtos
{
    public class UserCreateDto
    {
        public int? Id { get; set; } = 0;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int RolId { get; set; }
    }
}
