using StockSystem.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.DataAccess.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int SalesBy { get; set; }
        [ForeignKey("SalesBy")]
        public virtual User ? User { get; set; }
        public DateTime CreatedAt {  get; set; }   = DateTime.Now;
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Total { get; set; }
        public virtual ICollection<SalesDetail>? SalesDetails { get; set;}
    }
}
