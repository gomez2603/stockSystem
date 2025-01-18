using stockSystem.DataAccess.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace stockSystem.Dtos
{
    public class userResponseDto
    {
        public int id { get; set; }
    
        public string name { get; set; }
    
        public string lastName { get; set; }

        public string username { get; set; }
        public int rolId { get; set; }
        public string rolNombre { get; set; }
    }
}
