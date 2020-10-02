using SoundProdHelper.Domain.Base;

namespace SoundProdHelper.UserService.Domain.Entities
{
    public class CryptoKeys : EntityBase
    {
        public ulong FirstPathPublicKey { get; set; }
        public ulong SecondPartPublicKey { get; set; }
        public ulong FirstPartPrivateKey { get; set; }
        public ulong SecondPartPrivateKey { get; set; }

        public virtual Session Session { get; set; }
    }
}