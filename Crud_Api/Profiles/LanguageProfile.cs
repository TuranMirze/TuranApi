using AutoMapper;
using Crud_Api.DTO.Languages;
using Crud_Api.Entities;

namespace Crud_Api.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>()
                .ForMember(l => l.Icon, lcd => lcd.MapFrom(x=>x.IconUrl));
            CreateMap<LanguageGetDto,Language>()
                .ForMember(l => l.Icon, lcd => lcd.MapFrom(x => x.Icon));
            CreateMap<LanguageUpdateDto,Language>().ReverseMap();

        }
    }
}
    