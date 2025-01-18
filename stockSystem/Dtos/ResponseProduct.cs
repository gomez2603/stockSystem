using StockSystem.dataAccess.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace stockSystem.Dtos
{
    public class ResponseProduct
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    
        public string image { get; set; }
        public int userId { get; set; }
        public string userUsername { get; set; }
        public string categoryId { get; set; }  
        public string categoryName { get; set; }
        public string? size { get; set; }
        public string? brand { get; set; }
        public string? model { get; set; }
        public string? barcode { get; set; }
    }
}
