using StockSystem.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.DataAccess.Models
{
    public class SalesDetail
    {
        public int SalesId { get; set; }
        public Sales Sales { get; set; }
        public int ProductId { get; set; }  
        public Product Products { get; set; }
        public int Quantity { get; set; }

    }
}
