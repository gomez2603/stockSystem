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

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Cost { get; set; }

        public decimal Margin { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Price { get; private set; }
        [AllowNull]
        public string? Image { get; set; }
        public string? Size {  get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
            
        public int SupplierId { get; set; }
        public virtual Supplier? Supplier { get; set; } 

        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Barcode {  get; set; }
        public int CreatedBy { get; set; }

        [ForeignKey("createdBy")]
        public virtual User? User { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set;}

        public ICollection<Stock> Stock { get; set; } = new List<Stock>();

    }   
}
