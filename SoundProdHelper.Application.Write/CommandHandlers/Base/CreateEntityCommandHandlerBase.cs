using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.Domain;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.Application.Write.CommandHandlers.Base
{
    public abstract class CreateEntityCommandHandlerBase<TCommand, TEntity> : CommandHandlerBase<TCommand, Guid>
        where TCommand: IRequest<ResultOf<Guid>>
        where TEntity : EntityBase
    {
        private readonly IWriteOnlyRepository<TEntity> _entityWriteOnlyRepository;

        protected CreateEntityCommandHandlerBase(
            IUnitOfWork unitOfWork, 
            IEnumerable<IValidator<TCommand>> validators, 
            IWriteOnlyRepository<TEntity> entityWriteOnlyRepository) : 
            base(unitOfWork, validators)
        {
            _entityWriteOnlyRepository = entityWriteOnlyRepository.ThrowIfNull(nameof(entityWriteOnlyRepository));
        }

        protected override async Task<Guid> ProcessActionAsync(TCommand request, CancellationToken cancellationToken)
        {
            var entity = CreateEntityFromCommand(request);
            var result = await _entityWriteOnlyRepository.AddAsync(entity)
                .ConfigureAwait(false);

            return result.Uid;
        }

        protected abstract TEntity CreateEntityFromCommand(TCommand command);
    }
}