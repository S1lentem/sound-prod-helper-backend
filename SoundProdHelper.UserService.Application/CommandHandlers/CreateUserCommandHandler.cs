using FluentValidation;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.UserService.Application.Command;
using SoundProdHelper.UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SoundProdHelper.Crypto.Interfaces;

namespace SoundProdHelper.UserService.Application.CommandHandlers
{
    public class CreateUserCommandHandler : CommandHandlerBase<CreateUserCommand, Guid>
    {
        private readonly IHashManager _hashManager;
        private readonly IWriteOnlyRepository<User> _userWirteOnlyRepository;

        public CreateUserCommandHandler(
            IUnitOfWork unitOfWork, 
            IEnumerable<IValidator<CreateUserCommand>> validators,
            IWriteOnlyRepository<User> userWriteOnlyRepository,
            IHashManager hashManager) :
            base(unitOfWork, validators)
        {
            _userWirteOnlyRepository = userWriteOnlyRepository.ThrowIfNull(nameof(userWriteOnlyRepository));
            _hashManager = hashManager.ThrowIfNull(nameof(hashManager));
        }

        protected override async Task<Guid> ProcessActionAsync(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                Password = _hashManager.GetHash(request.Password),
            };

            var entity = await _userWirteOnlyRepository.AddAsync(user).ConfigureAwait(false);
            
            
            return entity.Uid;
        }

       
    }
}
