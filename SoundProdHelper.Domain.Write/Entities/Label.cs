using SoundProdHelper.Domain.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SoundProdHelper.Domain.Write.Entities
{
    public class Label : EntityBase
    {
        public string Name { get; set; }

        public Guid OwnerUid { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<ListeningRequest> ListeningRequests { get; set; }
    }
}
