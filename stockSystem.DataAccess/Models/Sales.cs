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
        public virtual User ? user { get; set; }
        public DateTime Created {  get; set; }   = DateTime.Now;
        public decimal Total { get; set; }

          public virtual ICollection<SalesDetail> SalesDetails { get; set;}

    }
}
