using stockSystem.DataAccess.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace stockSystem.Dtos
{
    public class userResponseDto
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public string LastName { get; set; }

        public string Username { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
    }
}
