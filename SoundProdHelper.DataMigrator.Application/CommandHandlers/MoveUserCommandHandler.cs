using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using SoundProdHelper.Common.Extensions;
using SoundProdHelper.DataMigrator.Application.Command;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Read.Entities;
using SoundProdHelper.Domain.Read.Specifications;

using ReadableUser = SoundProdHelper.Domain.Read.Entities.User;
using WritableUser = SoundProdHelper.Domain.Write.Entities.User;

namespace SoundProdHelper.DataMigrator.Application.CommandHandlers
{
    public class MoveUserCommandHandler : CommandHandlerBase<MoveUserCommand, User>
    {
        private readonly IMapper _mapper;
        private readonly IReadOnlyRepository<ReadableUser> _readOnlyRepository;
        private readonly IWriteOnlyRepository<WritableUser> _writeOnlyRepository;

        public MoveUserCommandHandler(
            IUnitOfWork unitOfWork, 
            IEnumerable<IValidator<MoveUserCommand>> validators,
            IMapper mapper, 
            IReadOnlyRepository<ReadableUser> readOnlyRepository, 
            IWriteOnlyRepository<WritableUser> writeOnlyRepository) : 
            base(unitOfWork, validators)
        {
            _readOnlyRepository = readOnlyRepository.ThrowIfNull(nameof(readOnlyRepository));
            _writeOnlyRepository = writeOnlyRepository.ThrowIfNull(nameof(writeOnlyRepository));
            _mapper = mapper.ThrowIfNull(nameof(mapper));
        }

        protected override async Task<ReadableUser> ProcessActionAsync(MoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _readOnlyRepository.GetSingleOrDefaultAsync(new UserFilterSpecifications.ByUid(request.UserUid))
                .ConfigureAwait(false);

            var userForInsert = _mapper.Map<WritableUser>(user);

            await _writeOnlyRepository.AddAsync(userForInsert).ConfigureAwait(false);

            return user;
        }
    }
}