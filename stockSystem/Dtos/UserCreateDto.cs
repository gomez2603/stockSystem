using System.ComponentModel.DataAnnotations;

namespace stockSystem.Dtos
{
    public class UserCreateDto
    {
        public int? id { get; set; } = 0;
        public string name { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public int rolId { get; set; }
    }
}
