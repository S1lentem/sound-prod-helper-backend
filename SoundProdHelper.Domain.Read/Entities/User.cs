using SoundProdHelper.Domain.Base;

namespace SoundProdHelper.Domain.Read.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}