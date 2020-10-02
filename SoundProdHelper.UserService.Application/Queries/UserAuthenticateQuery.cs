using MediatR;
using SoundProdHelper.Domain;
using SoundProdHelper.UserService.Application.Dto;

namespace SoundProdHelper.UserService.Application.Queries
{
    public class UserAuthenticateQuery : IRequest<ResultOf<UserDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}