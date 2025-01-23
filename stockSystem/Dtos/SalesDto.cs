namespace stockSystem.Dtos
{
   
        public class SalesDto
        {
          
            public decimal Total { get; set; }
            public List<SalesDetailDto> SalesDetails { get; set; } 
        }
    
}
