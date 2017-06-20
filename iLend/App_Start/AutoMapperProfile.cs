using AutoMapper;
using iLend.Models;
using iLend.Models.Dtos;

namespace iLend.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipient, RecipientDto>();
            CreateMap<RecipientDto, Recipient>();
        }
    }
}