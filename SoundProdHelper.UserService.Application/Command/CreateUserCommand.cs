using MediatR;
using SoundProdHelper.Common;
using SoundProdHelper.Domain;
using System;

namespace SoundProdHelper.UserService.Application.Command
{
    public class CreateUserCommand : IRequest<ResultOf<Guid>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
