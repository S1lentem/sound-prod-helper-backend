using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.UserService.Application.Dto;
using SoundProdHelper.UserService.Application.Queries;

namespace SoundProdHelper.UserService.Application.QueryHandlers
{
    public class UserAuthenticateQueryHandler : QueryHandlerBase<UserAuthenticateQuery, UserDto>
    {
        public UserAuthenticateQueryHandler(IMapper mapper, IEnumerable<IValidator<UserAuthenticateQuery>> validators) : base(mapper, validators)
        {
        }

        protected override Task<UserDto> ProcessQueryAsync(UserAuthenticateQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}