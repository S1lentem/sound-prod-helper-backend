using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using SoundProdHelper.Application.Read.Dto;
using SoundProdHelper.Application.Read.Queries.Users;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Read.Entities;
using SoundProdHelper.Domain.Read.Specifications;

namespace SoundProdHelper.Application.Read.QueryHandlers.Users
{
    public class GetUserByUidQueryHandler : QueryHandlerBase<GetUserByUidQuery, UserDto>
    {
        private readonly IReadOnlyRepository<User> _userRepository;

        public GetUserByUidQueryHandler(
            IMapper mapper, 
            IEnumerable<IValidator<GetUserByUidQuery>> validators, 
            IReadOnlyRepository<User> userRepository) : 
            base(mapper, validators)
        {
            _userRepository = userRepository.ThrowIfNull(nameof(userRepository));
        }

        protected override async Task<UserDto> ProcessQueryAsync(GetUserByUidQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetSingleOrDefaultAsync(new UserFilterSpecifications.ByUid(request.Uid))
                .ConfigureAwait(false);

            return Mapper.Map<UserDto>(user);
        }
    }
}