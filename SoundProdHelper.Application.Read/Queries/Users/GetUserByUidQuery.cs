using System;
using MediatR;
using SoundProdHelper.Application.Read.Dto;
using SoundProdHelper.Common;
using SoundProdHelper.Domain;

namespace SoundProdHelper.Application.Read.Queries.Users
{
    public class GetUserByUidQuery : IRequest<ResultOf<UserDto>>
    {
        public Guid Uid { get; set; }
    }
}