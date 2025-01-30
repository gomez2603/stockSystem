namespace stockSystem.Dtos
{
    public class SalesResponseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Total { get; set; }
        public string Username { get; set; }
        public List<SalesDetailResponseDto> SalesDetails { get; set; }

    }
}
