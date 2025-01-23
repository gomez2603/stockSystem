using AutoMapper;
using stockSystem.DataAccess.Models;
using StockSystem.dataAccess.Models;

namespace stockSystem.Dtos
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ResponseProduct>();
            CreateMap<CreateUpdateProduct, Product>();
            CreateMap<UserCreateDto, User>();
            CreateMap<User, userLoginResponse>();
            CreateMap<User, userResponseDto>();
            CreateMap<SalesDto, Sales>()
           .ForMember(dest => dest.salesDetails, opt => opt.MapFrom(src => src.SalesDetails));
            CreateMap<SalesDetailDto, SalesDetail>();
        }
    }
}
