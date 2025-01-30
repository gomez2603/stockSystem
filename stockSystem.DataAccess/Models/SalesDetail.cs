using StockSystem.dataAccess.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace stockSystem.DataAccess.Models
{
    public class SalesDetail
    {
        public int salesId { get; set; }
        public Sales sales { get; set; }
        public int productId { get; set; }  
        public Product products { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal quantity { get; set; }

    }
}
