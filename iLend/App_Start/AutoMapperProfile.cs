using AutoMapper;
using iLend.Models;
using iLend.Models.Dtos;

namespace iLend.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Domain to Dto
            CreateMap<Recipient, RecipientDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<UserGroup, UserGroupDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<HandOver, HandoverDto>();

            // Dto to Domain
            CreateMap<RecipientDto, Recipient>()
                .ForMember(r => r.Id, opt => opt.Ignore());

            CreateMap<ProductDto, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}