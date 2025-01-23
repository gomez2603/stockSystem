
namespace stockSystem.Dtos
{
    public class CreateUpdateProduct
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int quantity { get; set; }

        public string? image { get; set; }
        public decimal price { get; set; }

       
        public int categoryId { get; set; }
        public string? size { get; set; }
        public string? brand { get; set; }
        public string? model { get; set; }
        public string? barcode { get; set; }

        public IFormFile? file { get; set; }
    }
}
