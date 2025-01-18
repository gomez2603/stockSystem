using StockSystem.dataAccess.Models;

namespace stockSystem.DataAccess.Models
{
    public class SalesDetail
    {
        public int salesId { get; set; }
        public Sales sales { get; set; }
        public int productId { get; set; }  
        public Product products { get; set; }
        public int quantity { get; set; }

    }
}
