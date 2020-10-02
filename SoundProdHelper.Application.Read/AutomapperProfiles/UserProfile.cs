using AutoMapper;
using SoundProdHelper.Application.Read.Dto;
using SoundProdHelper.Domain.Read.Entities;

namespace SoundProdHelper.Application.Read.AutomapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Uid, opt => opt.MapFrom(src => src.Uid))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.Nickname));
        }
    }
}