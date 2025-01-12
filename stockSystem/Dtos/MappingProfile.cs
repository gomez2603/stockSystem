using AutoMapper;
using StockSystem.dataAccess.Models;

namespace stockSystem.Dtos
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            CreateMap<Product,ResponseProduct>();
            CreateMap<CreateUpdateProduct, Product>();


        }
    }
}
