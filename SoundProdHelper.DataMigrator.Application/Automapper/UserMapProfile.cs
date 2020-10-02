using AutoMapper;
using WritableUser = SoundProdHelper.Domain.Read.Entities.User;
using ReadableUser = SoundProdHelper.Domain.Write.Entities.User;

namespace SoundProdHelper.DataMigrator.Application.Automapper
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<WritableUser, ReadableUser>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.Nickname));
        }
    }
}