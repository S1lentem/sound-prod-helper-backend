using System;
using MediatR;
using SoundProdHelper.Common;
using SoundProdHelper.Domain;
using SoundProdHelper.Domain.Read.Entities;

namespace SoundProdHelper.DataMigrator.Application.Command
{
    public class MoveUserCommand : IRequest<ResultOf<User>>
    {
        public Guid UserUid { get; set; }
    }
}