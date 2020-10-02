using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using SoundProdHelper.Application.Write.Commands;
using SoundProdHelper.Application.Write.Messages.ValidationMessages;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Write.Entities;
using SoundProdHelper.Domain.Write.FilterSpecifications;

namespace SoundProdHelper.Application.Write.Validators
{
    public class AddSoundDemoCommandValidator : AbstractValidator<AddSoundDemoCommand>
    {
        private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

        public AddSoundDemoCommandValidator(IReadOnlyRepository<User> userReadOnlyRepository)
        {
            _userReadOnlyRepository = userReadOnlyRepository.ThrowIfNull(nameof(userReadOnlyRepository));

            RuleFor(x => x.AuthorUid)
                .MustAsync(AuthorExist)
                .WithMessage(UserValidationMessages.UserWithUidDoesNotExists);
        }

        private async Task<bool> AuthorExist(Guid authorUid, CancellationToken cancellationToken)
        {
            return await _userReadOnlyRepository.AnyAsync(new UserFilterSpecificationses.ByUid(authorUid))
                .ConfigureAwait(false);
        }
    }
}