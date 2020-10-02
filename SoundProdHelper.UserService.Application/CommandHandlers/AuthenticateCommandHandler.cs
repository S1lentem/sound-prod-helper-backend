using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Crypto.Interfaces;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.UserService.Application.Command;
using SoundProdHelper.UserService.Application.Dto;
using SoundProdHelper.UserService.Domain.Entities;
using SoundProdHelper.UserService.Domain.Specifications.UserSpecs;

namespace SoundProdHelper.UserService.Application.CommandHandlers
{
    public class AuthenticateCommandHandler : CommandHandlerBase<AuthenticateCommand, AuthenticateResultDto>
    {
        private readonly IReadOnlyRepository<User> _userReadOnlyRepository;
        private readonly IHashManager _hashManager;
        private readonly IRSACryptoEngine _cryptoEngine;

        public AuthenticateCommandHandler(
            IUnitOfWork unitOfWork, 
            IEnumerable<IValidator<AuthenticateCommand>> validators, 
            IHashManager hashManager, 
            IReadOnlyRepository<User> userReadOnlyRepository, 
            IRSACryptoEngine cryptoEngine) : 
            base(unitOfWork, validators)
        {
            _cryptoEngine = cryptoEngine.ThrowIfNull(nameof(cryptoEngine));
            _userReadOnlyRepository = userReadOnlyRepository.ThrowIfNull(nameof(userReadOnlyRepository));
            _hashManager = hashManager.ThrowIfNull(nameof(hashManager));
        }

        protected override async Task<AuthenticateResultDto> ProcessActionAsync(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userReadOnlyRepository
                .GetSingleOrDefaultAsync(new UserFilteringSpecs.ByEmail(request.Email))
                .ConfigureAwait(false);

            if (_hashManager.VerifyHash(user.Password, request.Password))
            {
                var (publicKey, privateKey) = _cryptoEngine.GenerateKeys();

                return new AuthenticateResultDto
                {
                    UserUid = user.Uid,
                    PublicKey = publicKey,
                    PrivateKey = privateKey,
                };
            }

            AddCommandFail("User password is not valid");
            return null;
        }
    }
}