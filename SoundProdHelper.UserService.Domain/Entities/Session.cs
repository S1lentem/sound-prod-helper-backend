using SoundProdHelper.Domain.Base;
using System;

namespace SoundProdHelper.UserService.Domain.Entities
{
    public class Session : EntityBase
    {
        public string Token { get; set; }
        public DateTime DateCreation { get; set; }
        public Guid UserUid { get; set; }

        public virtual User User { get; set; }
        public virtual CryptoKeys CryptoKeys { get; set; }
    }
}
