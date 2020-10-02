using MediatR;
using SoundProdHelper.Domain;
using System;
using SoundProdHelper.UserService.Application.Dto;

namespace SoundProdHelper.UserService.Application.Command
{
    public class AuthenticateCommand : IRequest<ResultOf<AuthenticateResultDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
