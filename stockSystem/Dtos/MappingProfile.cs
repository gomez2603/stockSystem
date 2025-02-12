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


            CreateMap<Sales, SalesResponseDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.created_at))
           .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total))
           .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.user.Name + " " + src.user.LastName))
           .ForMember(dest => dest.SalesDetails, opt => opt.MapFrom(src => src.salesDetails));

            // Mapeo de SalesDetail a SalesDetailResponseDto
            CreateMap<SalesDetail, SalesDetailResponseDto>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.quantity))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.products.id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.products.name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.products.price))
                  .ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => src.products.image));
        }
    }
}
