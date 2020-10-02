using System;
using MediatR;
using SoundProdHelper.Domain;

namespace SoundProdHelper.Application.Write.Commands
{
    public class CreateUserCommand : IRequest<ResultOf<Guid>>
    {
        public Guid AccountIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
    }
}