using SoundProdHelper.Domain.Base;
using System;
using System.Collections.Generic;

namespace SoundProdHelper.Domain.Write.Entities
{
    public class User : EntityBase
    {
        public Guid AccountIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        public virtual ICollection<ListeningRequest> ListeningRequests { get; set; }
    }
}