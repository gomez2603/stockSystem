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
        public int id { get; set; }
        [Required]
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(5, 2)")]
        public decimal quantity { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal price { get; set; }
        [AllowNull]
        public string? image { get; set; }
        public string? size {  get; set; }
        public int categoryId { get; set; }
        public virtual Category? category { get; set; }
        public string? brand { get; set; }
        public string? model { get; set; }
        public string? barcode {  get; set; }
        public int userId { get; set; }

        [ForeignKey("userId")]
        public virtual User? user { get; set; }
        public virtual ICollection<SalesDetail> salesDetails { get; set;}

    }   
}
