using stockSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [AllowNull]
        public string? Image { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual User? user { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set;}

    }   
}
