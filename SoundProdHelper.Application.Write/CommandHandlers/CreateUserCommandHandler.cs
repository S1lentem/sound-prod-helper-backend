using System.Collections.Generic;
using FluentValidation;
using SoundProdHelper.Application.Write.CommandHandlers.Base;
using SoundProdHelper.Application.Write.Commands;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Write.Entities;

namespace SoundProdHelper.Application.Write.CommandHandlers
{
    public class CreateUserCommandHandler : CreateEntityCommandHandlerBase<CreateUserCommand, User>
    {
        public CreateUserCommandHandler(
            IUnitOfWork unitOfWork, 
            IEnumerable<IValidator<CreateUserCommand>> validators, 
            IWriteOnlyRepository<User> entityWriteOnlyRepository) : 
            base(unitOfWork, validators, entityWriteOnlyRepository)
        {
        }

        protected override User CreateEntityFromCommand(CreateUserCommand command)
        {
            return new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                NickName = command.NickName,
                AccountIdentifier = command.AccountIdentifier,
            };
        }
    }
}