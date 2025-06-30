using StockSystem.dataAccess.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace stockSystem.DataAccess.Models
{
    public class SalesDetail
    {
        public int SalesId { get; set; }
        public Sales Sales { get; set; }
        public int ProductId { get; set; }  
        public Product Products { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Quantity { get; set; }

    }
}
