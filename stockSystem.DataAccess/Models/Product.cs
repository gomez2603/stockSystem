using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.dataAccess.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual User? Rol { get; set; }

    }   
}
