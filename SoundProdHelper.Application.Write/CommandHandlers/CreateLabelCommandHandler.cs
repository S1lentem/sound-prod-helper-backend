using FluentValidation;
using SoundProdHelper.Application.Write.Commands;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Write.Entities;
using System.Collections.Generic;
using SoundProdHelper.Application.Write.CommandHandlers.Base;

namespace SoundProdHelper.Application.Write.CommandHandlers
{
    public class CreateLabelCommandHandler : CreateEntityCommandHandlerBase<CreateLabelCommand, Label>
    {
        public CreateLabelCommandHandler(
            IUnitOfWork unitOfWork, 
            IEnumerable<IValidator<CreateLabelCommand>> validators, 
            IWriteOnlyRepository<Label> entityWriteOnlyRepository) : 
            base(unitOfWork, validators, entityWriteOnlyRepository)
        {
        }

        protected override Label CreateEntityFromCommand(CreateLabelCommand command)
        {
            return new Label
            {
                Name = command.Name,
                OwnerUid = command.UserUid,
            };
        }
    }
}
