using System;
using MediatR;
using SoundProdHelper.Domain;

namespace SoundProdHelper.Application.Write.Commands
{
    public class CreateListeningRequestCommand : IRequest<ResultOf<Guid>>
    {
        public Guid DemoUid { get; set; }
        public Guid LabelUId { get; set; }
    }
}