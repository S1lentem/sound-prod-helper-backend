using System;
using SoundProdHelper.Domain.Base;

namespace SoundProdHelper.Domain.Write.Entities
{
    public class ListeningRequest : EntityBase
    {
        public DateTime DateCreation { get; set; }

        public Guid DemoUid { get; set; }
        public virtual SoundDemo Demo { get; set; }

        public Guid LabelUid { get; set; }
        public virtual Label Label { get; set; }
    }
}