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
        public int id { get; set; }
        public int salesBy { get; set; }
        [ForeignKey("salesBy")]
        public virtual User ? user { get; set; }
        public DateTime created_at {  get; set; }   = DateTime.Now;
        public decimal total { get; set; }
        public virtual ICollection<SalesDetail>? salesDetails { get; set;}
    }
}
