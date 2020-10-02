using MediatR;
using SoundProdHelper.Domain;
using System;

namespace SoundProdHelper.Application.Write.Commands
{
    public class CreateLabelCommand : IRequest<ResultOf<Guid>>
    {
        public string Name { get; set; }
        public Guid UserUid { get; set; }
    }
}
