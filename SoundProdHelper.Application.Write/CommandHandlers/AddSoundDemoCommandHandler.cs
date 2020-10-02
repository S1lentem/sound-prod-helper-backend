using System.Collections.Generic;
using FluentValidation;
using SoundProdHelper.Application.Write.CommandHandlers.Base;
using SoundProdHelper.Application.Write.Commands;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Write.Entities;

namespace SoundProdHelper.Application.Write.CommandHandlers
{
    public class AddSoundDemoCommandHandler : CreateEntityCommandHandlerBase<AddSoundDemoCommand, SoundDemo>
    {
        public AddSoundDemoCommandHandler(
            IUnitOfWork unitOfWork, 
            IEnumerable<IValidator<AddSoundDemoCommand>> validators, 
            IWriteOnlyRepository<SoundDemo> entityWriteOnlyRepository) : 
            base(unitOfWork, validators, entityWriteOnlyRepository)
        {
        }

        protected override SoundDemo CreateEntityFromCommand(AddSoundDemoCommand command)
        {
            return new SoundDemo
            {
                AuthorUid = command.AuthorUid,
                Title = command.Title,
                Description = command.Description,
                FileUid = command.FileUid,
            };
        }
    }
}