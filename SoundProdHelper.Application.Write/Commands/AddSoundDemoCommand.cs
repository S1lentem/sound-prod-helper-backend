using System;
using MediatR;
using SoundProdHelper.Domain;

namespace SoundProdHelper.Application.Write.Commands
{
    public class AddSoundDemoCommand : IRequest<ResultOf<Guid>>
    {
        public Guid AuthorUid { get; set; }
        public Guid FileUid { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}