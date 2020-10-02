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
    public class CreateLabelCommandValidator : AbstractValidator<CreateLabelCommand>
    {
        private readonly IReadOnlyRepository<Label> _labelReadOnlyRepository;

        public CreateLabelCommandValidator(IReadOnlyRepository<Label> labelReadOnlyRepository)
        {
            _labelReadOnlyRepository = labelReadOnlyRepository.ThrowIfNull(nameof(labelReadOnlyRepository));

            RuleFor(x => x.Name)
                .MustAsync(LabelDoesNotExist)
                .WithMessage(LabelValidationMessages.AlreadyExistWithName);

            RuleFor(x => x.UserUid)
                .MustAsync(OwnerIsExist)
                .WithMessage(LabelValidationMessages.OwnerDoesNotExist);
        }

        private async Task<bool> LabelDoesNotExist(string name, CancellationToken cancellationToken)
        {
            return await _labelReadOnlyRepository.AnyAsync(new LabelFilterSpecifications.ByName(name))
                .ConfigureAwait(false);
        }

        private async Task<bool> OwnerIsExist(Guid ownerUid, CancellationToken cancellationToken)
        {
            return await _labelReadOnlyRepository.AnyAsync(new LabelFilterSpecifications.ByOwnerUid(ownerUid))
                .ConfigureAwait(false);
        }
    }
}