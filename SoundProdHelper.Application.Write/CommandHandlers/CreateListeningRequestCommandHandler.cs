using System.Collections.Generic;
using FluentValidation;
using SoundProdHelper.Application.Write.CommandHandlers.Base;
using SoundProdHelper.Application.Write.Commands;
using SoundProdHelper.Common;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Write.Entities;

namespace SoundProdHelper.Application.Write.CommandHandlers
{
    public class CreateListeningRequestCommandHandler : 
        CreateEntityCommandHandlerBase<CreateListeningRequestCommand, ListeningRequest>
    {
        private readonly DateTimeProvider _dateTimeProvider;
        public CreateListeningRequestCommandHandler(
            IUnitOfWork unitOfWork, 
            IEnumerable<IValidator<CreateListeningRequestCommand>> validators, 
            IWriteOnlyRepository<ListeningRequest> entityWriteOnlyRepository, 
            DateTimeProvider dateTimeProvider) : 
            base(unitOfWork, validators, entityWriteOnlyRepository)
        {
            _dateTimeProvider = dateTimeProvider.ThrowIfNull(nameof(dateTimeProvider));
        }

        protected override ListeningRequest CreateEntityFromCommand(CreateListeningRequestCommand command)
        {
            return new ListeningRequest
            {
                DemoUid = command.DemoUid,
                LabelUid = command.LabelUId,
                DateCreation = _dateTimeProvider.UtcNow,
            };
        }
    }
}