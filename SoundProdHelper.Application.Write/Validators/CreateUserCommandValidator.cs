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
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

        public CreateUserCommandValidator(IReadOnlyRepository<User> userReadOnlyRepository)
        {
            _userReadOnlyRepository = userReadOnlyRepository.ThrowIfNull(nameof(userReadOnlyRepository));

            RuleFor(x => x.NickName)
                .MustAsync(UserNotExist)
                .WithMessage(UserValidationMessages.AlreadyExistWithNickname);
        }

        private async Task<bool> UserNotExist(string nickname, CancellationToken cancellationToken)
        {
            return await _userReadOnlyRepository.AnyAsync(new UserFilterSpecificationses.ByNickname(nickname))
                .ConfigureAwait(false);
        }
    }
}