
namespace stockSystem.Dtos
{
    public class CreateUpdateProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string? Image { get; set; }
        public decimal Price { get; set; }

        public int userId { get; set; }

        public IFormFile? file { get; set; }
    }
}
